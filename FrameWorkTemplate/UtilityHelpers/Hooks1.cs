using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FrameWorkTemplate.Variable;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameWorkTemplate.UtilityHelpers
{
    [Binding]
    public class Hooks1: TechTalk.SpecFlow.Steps
    {
        
        public static IWebDriver driver;

        //settings for the configuration file
        public static ConfigSetting config;
        static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName 
            + Path.DirectorySeparatorChar + "Configuration/configsetting.json";

        //implemention for the extentreport
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, step;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Results"
            + Path.DirectorySeparatorChar + "Results" + DateTime.Now.ToString("ddMMyyyy HHmmss");
            

        

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Below for extent report generation
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlreport);

            // below are the code for the configuration file
            config = new ConfigSetting();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configsettingpath);
            IConfiguration configuration = builder.Build();
            configuration.Bind(config);

            if (config.BrowserType.ToLower() == "chrome")
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            else if(config.BrowserType.ToLower() == "firefox")
            {
                new DriverManager().SetUpDriver(new FirefoxConfig()); 
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
            } 
            else if(config.BrowserType.ToLower() == "edge")
            {
                new DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();
                driver.Manage().Window.Maximize();
            }

        }

        [BeforeFeature]
        public static void BeforeFeatureRun(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if(context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            {
                driver.Quit();
                driver.Dispose();
                
            }
        }
    }
}