using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTest
{
    [TestClass]
    public class AutoTest
    {
        [DataTestMethod]
        [DataRow("A", true)]
        [DataRow("B", true)]
        [DataRow("Op", true)]
        [DataRow("Res", true)]
        [DataRow("Btn", true)]
        public void Test_Enabled(string id, bool exp)
        {
            var driver = new ChromeDriver();
            string fullPath = Path.GetFullPath(@"../../../WebCalc/Calc.html");
            driver.Navigate().GoToUrl("file:///" + fullPath);

            bool res = driver.FindElementById(id).Enabled;
            Assert.AreEqual(exp, res);

            driver.Close();
        }

        [DataTestMethod]
        [DataRow("A", "5", "5")]
        [DataRow("B", "5", "5")]
        [DataRow("Op", "+", "+")]
        public void Test_SimpleCheck(string id, string key, string exp)
        {
            var driver = new ChromeDriver();
            string fullPath = Path.GetFullPath(@"../../../WebCalc/Calc.html");
            driver.Navigate().GoToUrl("file:///" + fullPath);

            driver.FindElementById(id).SendKeys(key);
            string res = driver.FindElementById(id).GetAttribute("value");
            Assert.AreEqual(exp, res);

            driver.Close();
        }

        [DataTestMethod]
        [DataRow("A", "50", "50")]
        [DataRow("B", "505", "505")]
        [DataRow("A", "5050", "5050")]
        [DataRow("B", "50501", "50501")]
        public void Test_ComplexCheck(string id, string key, string exp)
        {
            var driver = new ChromeDriver();
            string fullPath = Path.GetFullPath(@"../../../WebCalc/Calc.html");
            driver.Navigate().GoToUrl("file:///" + fullPath);

            driver.FindElementById(id).SendKeys(key);
            string res = driver.FindElementById(id).GetAttribute("value");
            Assert.AreEqual(exp, res);

            driver.Close();
        }

        [DataTestMethod]
        [DataRow("11", "7", "p", "18")]
        [DataRow("14", "3", "-", "11")]
        [DataRow("15", "6", "*", "90")]
        [DataRow("80", "20", "/", "4")]
        public void Calc_RealJob(string a, string b, string op, string exp)
        {
            var driver = new ChromeDriver();
            string fullPath = Path.GetFullPath(@"../../../WebCalc/Calc.html");
            driver.Navigate().GoToUrl("file:///" + fullPath);

            driver.FindElementById("A").SendKeys(a);
            driver.FindElementById("B").SendKeys(b);
            driver.FindElementById("Op").SendKeys(op);
            driver.FindElementById("Btn").Click();
            string res = driver.FindElementById("Res").GetAttribute("value");
            driver.Close();
            Assert.AreEqual(exp, res);
        }
    }
}