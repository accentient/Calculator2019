using System;
using OpenQA.Selenium;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fabrikam.Appium
{
  [TestClass]
  public class AppiumTests : CalculatorSession
  {
    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
      Setup(context);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
      TearDown();
    }

    [TestInitialize]
    public void TestInitialize()
    {
      // Clear calculator
      key_clear.Click();
      Assert.AreEqual("0", display.Text);
    }

    [TestMethod]
    [TestCategory("Appium")]
    public void Addition()
    {
      key_1.Click();
      key_plus.Click();
      key_1.Click();
      key_equals.Click();
      Assert.AreEqual("2", display.Text);
    }

    [TestMethod]
    [TestCategory("Appium")]
    public void Subtraction()
    {
      key_2.Click();
      key_minus.Click();
      key_1.Click();
      key_equals.Click();
      Assert.AreEqual("1", display.Text);
    }

    [TestMethod]
    [TestCategory("Appium")]
    public void Multiplication()
    {
      key_2.Click();
      key_times.Click();
      key_2.Click();
      key_equals.Click();
      Assert.AreEqual("4", display.Text);
    }

    [TestMethod]
    [TestCategory("Appium")]
    public void Division()
    {
      key_2.Click();
      key_dividedBy.Click();
      key_1.Click();
      key_equals.Click();
      Assert.AreEqual("2", display.Text);
    }

  }
}
