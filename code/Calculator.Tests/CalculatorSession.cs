using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;

namespace Fabrikam.Appium
{
  public class CalculatorSession
  {
    protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
    private static string CalculatorAppId;

    protected static WindowsDriver<WindowsElement> session;
    protected static WindowsElement display, key_clear, key_1, key_2, key_plus, key_minus, key_times, key_dividedBy, key_equals;

    public static void Setup(TestContext context)
    {
      // Launch a new instance of Calculator application
      if (session == null)
      {
        // Determine AssemblyPath

        string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        string assemblyPath = System.IO.Path.GetDirectoryName(path);
        CalculatorAppId = assemblyPath + @"\" + "calculator.exe";

        // Create a new session to launch Calculator application
        DesiredCapabilities appCapabilities = new DesiredCapabilities();
        appCapabilities.SetCapability("app", CalculatorAppId);
        session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

        Assert.IsNotNull(session);
        Assert.IsNotNull(session.SessionId);

        // Verify that Calculator is started with untitled new file
        Assert.AreEqual("Fabrikam Calculator", session.Title);

        // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
        session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

        // Keep track of the main display box to be used throughout the session
        display = session.FindElementByAccessibilityId("txt_Main");
        Assert.IsNotNull(display);

        key_clear = session.FindElementByAccessibilityId("btn_Clear");
        Assert.IsNotNull(key_clear);

        key_1 = session.FindElementByAccessibilityId("btn_N1");
        Assert.IsNotNull(key_1);

        key_2 = session.FindElementByAccessibilityId("btn_N2");
        Assert.IsNotNull(key_2);

        key_plus = session.FindElementByAccessibilityId("btn_O4");
        Assert.IsNotNull(key_plus);

        key_minus = session.FindElementByAccessibilityId("btn_O3");
        Assert.IsNotNull(key_minus);

        key_times = session.FindElementByAccessibilityId("btn_O2");
        Assert.IsNotNull(key_times);

        key_dividedBy = session.FindElementByAccessibilityId("btn_O1");
        Assert.IsNotNull(key_dividedBy);

        key_equals = session.FindElementByAccessibilityId("btn_Equal");
        Assert.IsNotNull(key_equals);
      }
    }

    public static void TearDown()
    {
      // Close the application and delete the session
      if (session != null)
      {
        session.Close();
        try
        {
          // Dismiss Save dialog if it is blocking the exit
          session.FindElementByName("Don't Save").Click();
        }
        catch { }
        session.Quit();
        session = null;
      }
    }
  }
}