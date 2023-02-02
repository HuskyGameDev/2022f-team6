[General Use]
	Each background assets folder will have multiple tilesets that can be used to create a full background scene.
	
[General Elements]
	'Sky' - A .jpg that is mostly either a solid color or gradicient, can be stretched to fill the backside of the level.
		  Example name: "Surface_Sky"

	'Walls/Hills' - A .png that will either have the 'hills'/'walls' of the level, 3 color variations to add in depth
			    The darker colored sprites go on the layer that is the closest to the sky's layer (in the back)
			    Example name: "Hill_Tileset"
		
	'Extras' - A .png that has other elements that can be added to the sky or wall/hill elements to make them more interesting
		     Example name: "BackgroundElements_Tileset"
		     There will also be separate .pngs with just a single sprite that are considered main elements to add into the scene
		     Example name: "MuseumSprite" or "StonePath_Tileset"
		     All/most of these elements should go on separate in-between layers so that they don't mess up the wall/hill elements