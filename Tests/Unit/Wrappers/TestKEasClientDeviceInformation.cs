/**
 * TestKEasClientDeviceInformation.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using KanoComputing.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Security.ExchangeActiveSyncProvisioning;


namespace KanoComputing.Tests.Unit.Wrappers {

    [TestClass]
    public class TestKEasClientDeviceInformation {

        [TestMethod]
        public void TestSystemManufacturer() {
            string expected = "PearShapedInc";

            IKEasClientDeviceInformation wrapper = new KEasClientDeviceInformation(systemManufacturer: expected);
            EasClientDeviceInformation easClient = new EasClientDeviceInformation();

            Assert.AreEqual(
                expected, wrapper.SystemManufacturer,
                "Property was not initialised correctly");
            Assert.AreNotEqual(
                wrapper.SystemManufacturer, easClient.SystemManufacturer,
                "Property was not wrapped correctly");
        }

        [TestMethod]
        public void TestSystemProductName() {
            string expected = "iWrapper";

            IKEasClientDeviceInformation wrapper = new KEasClientDeviceInformation(systemProductName: expected);
            EasClientDeviceInformation easClient = new EasClientDeviceInformation();

            Assert.AreEqual(
                expected, wrapper.SystemProductName,
                "Property was not initialised correctly");
            Assert.AreNotEqual(
                wrapper.SystemProductName, easClient.SystemProductName,
                "Property was not wrapped correctly");
        }

        [TestMethod]
        public void TestSystemSku() {
            string expected = "TheresSomethingAskewAboutThis";

            IKEasClientDeviceInformation wrapper = new KEasClientDeviceInformation(systemSku: expected);
            EasClientDeviceInformation easClient = new EasClientDeviceInformation();

            Assert.AreEqual(
                expected, wrapper.SystemSku,
                "Property was not initialised correctly");
            Assert.AreNotEqual(
                wrapper.SystemSku, easClient.SystemSku,
                "Property was not wrapped correctly");
        }
    }
}
