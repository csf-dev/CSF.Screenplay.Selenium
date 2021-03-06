﻿//
// StoredScriptBuilderExtensions.cs
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
using CSF.Screenplay.Selenium.Actions;
using CSF.Screenplay.Selenium.ScriptResources;

namespace CSF.Screenplay.Selenium.Builders
{
  /// <summary>
  /// Extension methods for a <see cref="ExecuteJavaScriptBuilder"/>, related to building performables which use the
  /// <see cref="GetALocalisedDate"/> JavaScript.
  /// </summary>
  public static class GetALocalisedDateScriptExtensions
  {
    /// <summary>
    /// Gets a performable which represents an invocation of the <see cref="GetALocalisedDate"/> JavaScript, using the
    /// given parameters.
    /// </summary>
    /// <returns>The JavaScript question performable.</returns>
    /// <param name="builder">Builder.</param>
    /// <param name="date">The date.</param>
    public static IPerformableJavaScriptWithResult WhichGetsALocaleFormattedVersionOf(this ExecuteJavaScriptBuilder builder,
                                                                                      DateTime date)
    {
      if(builder == null)
        throw new ArgumentNullException(nameof(builder));

      int
        year = date.Year,
        // Months in JavaScript start with zero, because reasons
        month = date.Month - 1,
        day = date.Day;

      return builder.AsPerformableBuilder.BuildQuestion<GetALocalisedDate>(year, month, day);
    }
  }
}
