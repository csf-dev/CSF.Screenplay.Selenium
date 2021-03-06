﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Screenplay.ReportFormatting;
using CSF.Screenplay.Selenium.Models;

namespace CSF.Screenplay.Selenium.Reporting
{
  /// <summary>
  /// Formatter for collections of options (as would appear in an HTML <c>select</c> element).
  /// </summary>
  public class OptionCollectionFormatter : ObjectFormattingStrategy<IEnumerable<Option>>
  {
    /// <summary>
    /// Formats the given object.
    /// </summary>
    /// <param name="obj">Object.</param>
    public override string FormatForReport(IEnumerable<Option> obj)
    {
      var options = obj.Select(x => x.Text);
      return $"The options {String.Join(", ", options)}";
    }
	}
}
