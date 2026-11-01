local conf = game.res:block("mymod:dirt")

conf.display = "Dirt"
conf.texture = game.res:texture("textures/stone.png")
conf.asleep = false

conf:commit()
conf:on("place", game:callback(function()
    game.debug:log("down")
end))