﻿using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay.Selenium.ScriptResources;

namespace CSF.Screenplay.Selenium.Tasks
{
  /// <summary>
  /// A task which gets the representation of a <c>System.DateTime</c> in a format compatible with the web browser's
  /// current localisation.
  /// </summary>
  public class GetTheLocaleFormattedDate : Question<string>
  {
    readonly DateTime date;

    /// <summary>
    /// Gets the report of the current instance, for the given actor.
    /// </summary>
    /// <returns>The human-readable report text.</returns>
    /// <param name="actor">An actor for whom to write the report.</param>
    protected override string GetReport(INamed actor)
      => $"{actor.Name} gets the locale-formatted representation of the date {date.ToString("yyyy-MM-dd")}";

    /// <summary>
    /// Performs this operation, as the given actor.
    /// </summary>
    /// <returns>The response or result.</returns>
    /// <param name="actor">The actor performing this task.</param>
    protected override string PerformAs(IPerformer actor)
    {
      return (string) actor.Perform(Execute.JavaScript.WhichGetsALocaleFormattedVersionOf(date));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:CSF.Screenplay.Selenium.Tasks.GetTheLocaleFormattedDate"/> class.
    /// </summary>
    /// <param name="date">Date.</param>
    public GetTheLocaleFormattedDate(DateTime date)
    {
      this.date = date;
    }
  }
}
