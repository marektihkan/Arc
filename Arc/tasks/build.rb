$: << File.expand_path(File.dirname(__FILE__))

require 'albacore'

desc "Cleans solution build files"
task :clean do
  Delete.directory CONFIG[:directories][:build]
end

desc "Builds solution"
task :build => ["build:prepare", "build:solutioninfo", "build:compile", "build:copybinaries", "build:copytests"]

namespace :build do
  desc "Generates assembly info"
  assemblyinfo :solutioninfo do |info|
    info.product_name = CONFIG[:solution]
    info.title = CONFIG[:solution]
    info.company_name = CONFIG[:owner]
    info.copyright = "Copyright #{Date.today.year} by #{CONFIG[:owner]}"
    info.output_file = "#{CONFIG[:directories][:src]}/CommonAssemblyInfo.cs"

    info.version = Version.get
  end

  desc "Compiles solution"
  msbuild :compile do |compiler|
    compiler.properties :configuration => CONFIG[:build_configuration]
    compiler.targets :Clean, :Build
    compiler.solution = "#{CONFIG[:solution]}.sln"
  end
  
  task :copybinaries do
    Copy.assemblies.
      from("#{CONFIG[:directories][:src]}/**/#{CONFIG[:build_configuration]}").
      to("#{CONFIG[:directories][:build]}/bin")
  end
  
  task :copytests do 
    Copy.binaries.
      from("#{CONFIG[:directories][:tests]}/**/#{CONFIG[:build_configuration]}").
      to("#{CONFIG[:directories][:build]}/tests")
  end

  task :prepare do 
    Create.directory CONFIG[:directories][:build]
    Create.directory "#{CONFIG[:directories][:build]}/bin"
    Create.directory "#{CONFIG[:directories][:build]}/tests"
    Create.directory "#{CONFIG[:directories][:build]}/results"
  end
end