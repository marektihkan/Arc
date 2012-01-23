require 'albacore'

desc 'Creates nupsecs & packages'
task :nuget => ['nuget:clean', 'nuget:prepare', 'nuget:copy_assemblies','nuget:package']


namespace :nuget do

  task :clean do
	Delete.directory "#{CONFIG[:directories][:nuget]}"
	Ensure.path "#{CONFIG[:directories][:nuget]}"
	Ensure.path "#{CONFIG[:directories][:nuget]}/packages"
  end

  task :prepare do
	Ensure.path "#{CONFIG[:directories][:nuget]}/Arc/lib"
	Ensure.path "#{CONFIG[:directories][:nuget]}/Arc.Data/lib"
	Ensure.path "#{CONFIG[:directories][:nuget]}/Arc.Log4Net/lib"
	Ensure.path "#{CONFIG[:directories][:nuget]}/Arc.StructureMap/lib"
	Ensure.path "#{CONFIG[:directories][:nuget]}/Arc.AutoMapper/lib"
	Ensure.path "#{CONFIG[:directories][:nuget]}/Arc.FluentValidation/lib"
  end

  task :package do
	version = Version.get
  
	Rake::Task["nuget:prepare_package"].reenable
	Rake::Task["nuget:prepare_package"].invoke("Arc")
	Rake::Task["nuget:create_package"].reenable
	Rake::Task["nuget:create_package"].invoke("Arc")
	
	Rake::Task["nuget:prepare_package"].reenable
	Rake::Task["nuget:prepare_package"].invoke("Arc.Data", "Arc", [{"Arc" => version}, {"FluentNHibernate" => "1.2.0.712"}])
	Rake::Task["nuget:create_package"].reenable
	Rake::Task["nuget:create_package"].invoke("Arc.Data")
	
	Rake::Task["nuget:prepare_package"].reenable
	Rake::Task["nuget:prepare_package"].invoke("Arc.Log4Net", "Arc", [{"Arc" => version}, {"log4net" => "[1.2.10]"}])
	Rake::Task["nuget:create_package"].reenable
	Rake::Task["nuget:create_package"].invoke("Arc.Log4Net")
	
	Rake::Task["nuget:prepare_package"].reenable
	Rake::Task["nuget:prepare_package"].invoke("Arc.StructureMap", "Arc", [{"Arc" => version}, {"structuremap" => "2.6.3"}])
	Rake::Task["nuget:create_package"].reenable
	Rake::Task["nuget:create_package"].invoke("Arc.StructureMap")
	
	Rake::Task["nuget:prepare_package"].reenable
	Rake::Task["nuget:prepare_package"].invoke("Arc.AutoMapper", "Arc", [{"Arc" => version}, {"AutoMapper" => "2.0.0"}])
	Rake::Task["nuget:create_package"].reenable
	Rake::Task["nuget:create_package"].invoke("Arc.AutoMapper")
	
	Rake::Task["nuget:prepare_package"].reenable
	Rake::Task["nuget:prepare_package"].invoke("Arc.FluentValidation", "Arc", [{"Arc" => version}, {"FluentValidation" => "3.2.0.0"}])
	Rake::Task["nuget:create_package"].reenable
	Rake::Task["nuget:create_package"].invoke("Arc.FluentValidation")
	
  end
  
  desc "Create NuSpec files"
  nuspec :prepare_package, [:package_id, :description, :dependencies] do |nuspec, args|
	args.with_defaults(:description => args.package_id, :dependencies => [])
  
	nuspec.id = args.package_id
	nuspec.version = Version.get
	nuspec.authors = CONFIG[:owner]
	nuspec.owners = CONFIG[:owner]
	nuspec.description = args.description
	nuspec.licenseUrl = 'http://www.apache.org/licenses/LICENSE-2.0'
	nuspec.projectUrl = 'http://github.com/marektihkan/arc'
	nuspec.working_directory =  "#{CONFIG[:directories][:nuget]}/#{args.package_id}"
	nuspec.output_file = "#{args.package_id}.nuspec"
	
	args.dependencies.each do |d|
		d.each do |name,version|
			nuspec.dependency name, version
		end
	end
  end
  
  desc "Create NuGet packages"
  nugetpack :create_package, [:package_id] do |nugetpack, args|
	nugetpack.command = "#{CONFIG[:paths][:nuget]}"
	nugetpack.nuspec = "#{CONFIG[:directories][:nuget]}/#{args.package_id}/#{args.package_id}.nuspec"
	nugetpack.base_folder = "#{CONFIG[:directories][:nuget]}/#{args.package_id}"
	nugetpack.output = "#{CONFIG[:directories][:nuget]}/packages"
  end
  
  task :copy_assemblies => [:copy_arc, :copy_data, :copy_structuremap, :copy_logging, :copy_automapper, :copy_validation]
  
  task :copy_arc do
	Copy.assemblies.matching('Arc.Domain,Arc.Infrastructure').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:nuget]}/Arc/lib")
  end
  
  task :copy_data do
	Copy.assemblies.matching('Arc.Infrastructure.Data.NHibernate').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:nuget]}/Arc.Data/lib")
  end
  
  task :copy_logging do
	Copy.assemblies.matching('Arc.Infrastructure.Logging.Log4Net').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:nuget]}/Arc.Log4Net/lib")
  end
  
  task :copy_structuremap do
	Copy.assemblies.matching('Arc.Infrastructure.Dependencies.StructureMap').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:nuget]}/Arc.StructureMap/lib")
  end
  
  task :copy_automapper do
	Copy.assemblies.matching('Arc.Infrastructure.Mapping.AutoMapper').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:nuget]}/Arc.AutoMapper/lib")
  end
  
  task :copy_validation do
	Copy.assemblies.matching('Arc.Infrastructure.Validation.FluentValidation').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:nuget]}/Arc.FluentValidation/lib")
  end

end