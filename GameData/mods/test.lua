local i = 0

game.world:on("place", game:callback(function()
    game.debug:log("block down!")
end))