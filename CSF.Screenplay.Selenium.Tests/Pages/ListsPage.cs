﻿//
// ListsPage.cs
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
using CSF.Screenplay.Selenium.Models;

namespace CSF.Screenplay.Selenium.Tests.Pages
{
  public class ListsPage : Page
  {
    public override string GetName() => "the lists testing page";

    public override IUriProvider GetUriProvider() => new AppUri("Lists");

    public static ITarget SingleSelectionList => new CssSelector("#single_selection", "the single selection list");

    public static ITarget SingleSelectionValue => new CssSelector("#single_selected_value", "the single-selection value");

    public static ITarget MultiSelectionList => new CssSelector("#multiple_selection", "the multi selection list");

    public static ITarget MultiSelectionValue => new CssSelector("#multiple_selected_value", "the multi-selection value");

    public static ITarget ListOfItems => new CssSelector("#list_of_items", "the list of items");

    public static ILocatorBasedTarget ItemsInTheList => new CssSelector("#list_of_items li", "items in the list");
  }
}
