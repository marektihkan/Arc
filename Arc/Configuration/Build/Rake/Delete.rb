require 'fileutils'

class Delete
  def self.directory(path)
    FileUtils.rm_rf path if exists?(path)
  end
end