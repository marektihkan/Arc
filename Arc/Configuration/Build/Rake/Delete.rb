require 'fileutils'

class Delete
  def self.directory(path)
    FileUtils.rm_rf path.to_s if exists?(path.to_s)
  end
end