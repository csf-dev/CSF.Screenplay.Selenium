﻿using System;
using CSF.Screenplay.Scenarios;

namespace CSF.Screenplay.Integration
{
  /// <summary>
  /// Factory type for the creation of a sceeenplay integration.
  /// </summary>
  public class IntegrationFactory
  {
    /// <summary>
    /// Factory method which creates a new implementation of <see cref="IScreenplayIntegration"/>
    /// from a given configuration type.
    /// </summary>
    /// <param name="configType">Config type.</param>
    public IScreenplayIntegration Create(Type configType)
    {
      var config = GetConfig(configType);
      var builder = GetBuilder(config);
      var registry = GetServiceRegistry(builder);

      return new ScreenplayIntegration(builder, registry);
    }

    IIntegrationConfig GetConfig(Type configType)
    {
      if(configType == null)
        throw new ArgumentNullException(nameof(configType));

      if(!typeof(IIntegrationConfig).IsAssignableFrom(configType))
      {
        throw new ArgumentException($"Configuration type must implement `{typeof(IIntegrationConfig).Name}'.",
                                    nameof(configType));
      }

      return (IIntegrationConfig) Activator.CreateInstance(configType);
    }

    IIntegrationConfigBuilder GetBuilder(IIntegrationConfig config)
    {
      var output = new IntegrationConfigurationBuilder();
      config.Configure(output);
      return output;
    }

    Lazy<IServiceRegistry> GetServiceRegistry(IIntegrationConfigBuilder configBuilder)
    {
      if(configBuilder == null)
        throw new ArgumentNullException(nameof(configBuilder));

      var registryFactory = new ServiceRegistryFactory(configBuilder);
      return new Lazy<IServiceRegistry>(registryFactory.GetServiceRegistry);
    }

  }
}