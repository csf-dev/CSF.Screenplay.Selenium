#!/bin/bash

NUGET_LATEST_DIST="https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
NUNIT_CONSOLE_VERSION="3.7.0"
TRAVIS_TEST_CONFIG_SOURCE="Tests/CSF.Screenplay.Web.Tests/App.Travis.config"
TEST_CONFIG_DESTINATION="Tests/CSF.Screenplay.Web.Tests/App.config"
NUGET_PATH=".nuget/nuget.exe"

stop_if_failure()
{
  code="$1"
  process="$2"
  if [ "$code" -ne "0" ]
  then
    echo "The process '${process}' failed with exit code $code"
    exit "$code"
  fi
}

install_latest_nuget()
{
  echo "Downloading the latest version of NuGet ..."

  # Travis uses Xamarin's apt repo which has an ancient nuget version
  mkdir -p .nuget
  wget -O "$NUGET_PATH" "$NUGET_LATEST_DIST"
  stop_if_failure $? "Download NuGet"
}

echo_nuget_version_to_console()
{
  mono "$NUGET_PATH"
}

setup_travis_test_config()
{
  echo "Copying Travis-specific test configs ..."
  cp "$TRAVIS_TEST_CONFIG_SOURCE" "$TEST_CONFIG_DESTINATION"
  stop_if_failure $? "Setup Travis configuration"
}

install_test_runner()
{
  echo "Downloading an NUnit test runner ..."
  mono "$NUGET_PATH" install \
    "NUnit.ConsoleRunner" \
    -Version "$NUNIT_CONSOLE_VERSION" \
    -OutputDirectory testrunner
  stop_if_failure $? "Download NUnit test runner"
}

restore_solution_nuget_packages()
{
  echo "Restoring NuGet packages for the solution ..."
  mono "$NUGET_PATH" restore CSF.Screenplay.sln
  stop_if_failure $? "Restore NuGet packages"
}

install_latest_nuget
echo_nuget_version_to_console
setup_travis_test_config
install_test_runner
restore_solution_nuget_packages

exit 0