require 'albacore'

desc "Runs all tests"
task :tests => ['tests:unit', 'tests:integration']

namespace :tests do   
  desc "Runs all unittests"
  nunit :unit do |test_runner|
    test_runner.path_to_command = CONFIG[:paths][:nunit]
    test_runner.assemblies = "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:tests]}/#{CONFIG[:solution]}.Unit.Tests.dll"
    test_runner.options "/xml=#{CONFIG[:directories][:build]}/results/Unit.Tests.xml"
  end

  desc "Runs all integration tests"
  nunit :integration do |test_runner|
    test_runner.path_to_command = CONFIG[:paths][:nunit]
    test_runner.assemblies = "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:tests]}/#{CONFIG[:solution]}.Integration.Tests.dll"
    test_runner.options "/xml=#{CONFIG[:directories][:build]}/results/Integration.Tests.xml"
  end
end