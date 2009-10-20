require 'erb'

class Create
  def self.directory(name)
    Dir.mkdir name.to_s unless exists?(name.to_s)  
  end

  def self.versioning_file
    VersionFileBuilder.new
  end
end


class VersionFileBuilder
    def initialize
      @properties = {'Product' => 'Unknown', 'Version' => '0.0.0.0', 'InformationalVersion' => '0.0.0.0'}
      @build_number = 0
    end

    def for_product_named(name)
      @properties['Product'] = name
      self
    end

    def versioned(version)
      @properties['Version'] = @properties['InformationalVersion'] = version + '.' + (ENV["CCNetLabel"].nil? ? @build_number.to_s : ENV["CCNetLabel"].to_s)
      self
    end

    def build(build_number)
      @build_number = build_number
      self
    end

    def reserve_all_rights_to(owner)
      @properties['Copyright'] = "Copyright 2008 - 2009 #{owner}. All rights reserved."
      self
    end

	def to(file_path)
		template = %q{
using System;
using System.Reflection;
using System.Runtime.InteropServices;

<% @properties.each {|k, v| %>
[assembly: Assembly<%=k%>Attribute("<%=v%>")]
<% } %>
		}.gsub(/^    /, '')

	  erb = ERB.new(template, 0, "%<>")

	  File.open(file_path.to_s, 'w') do |file|
		  file.puts erb.result(binding)
	  end
	end
end