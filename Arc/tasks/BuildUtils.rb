require 'albacore'
require 'fileutils'

class Version
  def self.get
	version = '0.0.0.0'
    version = File.open('VERSION', 'r').gets if File.exist?('VERSION')
	version
  end
end
