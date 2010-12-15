require 'albacore'

desc 'Publishes framework'
task :publish => ['publish:clean', 'publish:prepare', 'publish:copy']


namespace :publish do

  task :clean do
    Delete.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}"
  end

  task :prepare do
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/ServiceLocators"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/ServiceLocators/Ninject"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/ServiceLocators/Structuremap"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/ServiceLocators/Windsor"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Data"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Data/NHibernate"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Logging"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Logging/Log4Net"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Mappers"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Mappers/AutoMapper"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Validation"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Validation/NHibernateValidator"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Validation/FluentValidation"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Presentation"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Presentation/MVC"
    Create.directory "#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Presentation/MVP"
  end

  task :copy => [:copy_binaries, :copy_servicelocators, :copy_data, :copy_validation, :copy_logging, :copy_presentation]
  task :copy_servicelocators => [:copy_structuremap, :copy_ninject, :copy_windsor]
  task :copy_data => [:copy_nhibernate]
  task :copy_mapping => [:copy_automapper]
  task :copy_validation => [:copy_nhibernatevalidator, :copy_fluentvalidation]
  task :copy_logging => [:copy_log4net]
  task :copy_presentation => [:copy_mvc, :copy_mvp]

  task :copy_binaries do
    Copy.assemblies.matching('Arc.Domain,Arc.Infrastructure').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}")
  end
  
  task :copy_structuremap do
    Copy.assemblies.matching('*StructureMap*').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/ServiceLocators/Structuremap")
  end

  task :copy_ninject do
    Copy.assemblies.matching('*Ninject*').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/ServiceLocators/Ninject")
  end
  
  task :copy_windsor do
    Copy.assemblies.matching('*CastleWindsor*,Castle.Windsor,Castle.Core,Castle.MicroKernel').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/ServiceLocators/Windsor")
  end
  
  task :copy_nhibernate do
    Copy.assemblies.matching('*NHibernate,Castle.Core,Castle.DynamicProxy2,Iesi.Collections,log4net,Antlr3*,*ByteCode.Castle').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").    
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Data/NHibernate")
  end
  
  task :copy_log4net do
    Copy.assemblies.matching('*log4net*').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Logging/Log4Net")
  end
  
  task :copy_structuremap do
    Copy.assemblies.matching('*AutoMapper*').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Mappers/AutoMapper")
  end
  
  task :copy_fluentvalidation do
    Copy.assemblies.matching('*FluentValidation*').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Validation/FluentValidation")
  end
  
  task :copy_nhibernatevalidator do
    Copy.assemblies.matching('*NHibernateValidator*,NHibernate,Castle.DynamicProxy2,Iesi.Collections,log4net,Antlr3*,*ByteCode.Castle').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Validation/NHibernateValidator")
  end
  
  task :copy_mvc do
    Copy.assemblies.matching('*Mvc*').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Presentation/MVC")
  end
  
  task :copy_mvp do
    Copy.assemblies.matching('*Mvp*').
      from("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:binary]}").
      to("#{CONFIG[:directories][:build]}/#{CONFIG[:directories][:publish]}/Presentation/MVP")
  end

end