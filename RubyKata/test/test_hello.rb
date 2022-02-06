# frozen_string_literal: true

require 'minitest/autorun'

class Hello
  def self.world
    'world'
  end
end

describe '.hello' do
  it 'should return the string "world"' do
    # _(Hello.world).must_equal('world')
    _(Hello.world).must_equal('world')
  end
end
