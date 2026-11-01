local dirt = game.res:block(":dirt")
dirt.texture = game.res:texture("textures/dirt.png")
dirt.display = "Dirt"
dirt.asleep = true

local stone = game.res:block(":stone")
stone.texture = game.res:texture("textures/stone.png")
stone.display = "Stone"
stone.asleep = true

local gravel = game.res:block(":gravel")
gravel.texture = game.res:texture("textures/gravel.png")
gravel.display = "Gravel"
gravel.asleep = true

local planks = game.res:block(":planks")
planks.texture = game.res:texture("textures/planks.png")
planks.display = "Planks"
planks.asleep = true

dirt:commit()
stone:commit()
gravel:commit()
planks:commit()