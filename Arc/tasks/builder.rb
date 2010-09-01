$: << File.expand_path(File.dirname(__FILE__))

Dir.glob(File.join(File.expand_path(File.dirname(__FILE__)), '*.rb')).each {|f| require f }