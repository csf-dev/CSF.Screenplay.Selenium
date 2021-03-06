﻿//
// WebDriverCreationTracker.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2018 Craig Fowler
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using OpenQA.Selenium;

namespace CSF.Screenplay.Selenium
{
  /// <summary>
  /// A simple shared wrapper around a lazy web driver, used to track whether or not it has been initialised.
  /// </summary>
  public class LazyWebDriverCreationTracker : ITracksWebDriverCreation
  {
    readonly Lazy<IWebDriver> lazyWebDriver;

    /// <summary>
    /// Gets a value indicating whether the web driver has been created or not.
    /// </summary>
    /// <value><c>true</c> if the web driver has been created; otherwise, <c>false</c>.</value>
    public bool HasWebDriverBeenCreated => lazyWebDriver.IsValueCreated;

    /// <summary>
    /// Gets the web driver.
    /// </summary>
    /// <returns>The web driver.</returns>
    public IWebDriver GetWebDriver() => lazyWebDriver.Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:CSF.Screenplay.Selenium.WebDriverCreationTracker"/> class.
    /// </summary>
    /// <param name="lazyWebDriver">Lazy web driver.</param>
    public LazyWebDriverCreationTracker(Lazy<IWebDriver> lazyWebDriver)
    {
      if(lazyWebDriver == null)
        throw new ArgumentNullException(nameof(lazyWebDriver));
      this.lazyWebDriver = lazyWebDriver;
    }
  }
}
