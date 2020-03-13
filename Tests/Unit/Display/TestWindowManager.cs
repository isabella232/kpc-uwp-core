/**
 * TestWindowManager.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Windows.Foundation;

using KanoComputing.Display;


namespace Tests.Unit.Display {

    [TestClass]
    public class TestWindowManager {

        private static IEnumerable<object[]> GetEffectiveScreenSizes() {
            yield return new object[] { new Size(27, 28) };
            yield return new object[] { new Size(50, 0) };
            yield return new object[] { new Size(9001, 9001) };
        }
        
        [DataTestMethod]
        [DynamicData(nameof(GetEffectiveScreenSizes), DynamicDataSourceType.Method)]
        public void TestMaximiseWindow(Size windowSize) {

            // Create a mock.
            WindowManager windowManager = Mock.Of<WindowManager>();
            Mock<WindowManager> mockWindowManager = Mock.Get(windowManager);
            
            // We want to test the underlyning implementation of the function while
            // avoiding the invocation of other methods on the object.
            mockWindowManager.CallBase = true;
            mockWindowManager
                .Setup(obj => obj.GetEffectiveScreenSize())
                .Returns(windowSize);
            mockWindowManager
                .Setup(obj => obj.SetWindowSize(windowSize));

            // Call the function under test.
            windowManager.MaximiseWindow();

            // Assert the correct calls were made.
            mockWindowManager
                .Verify(
                    obj => obj.GetEffectiveScreenSize(),
                    Times.Once,
                    "The function is expected to use the effective screen size"
                );
            mockWindowManager
                .Verify(
                    obj => obj.SetWindowSize(windowSize),
                    Times.Once,
                    "The function is expected to set the effective screen size as given"
                );
        }
    }
}
