﻿using BetterSigns.Staxel.Rendering;
using BetterSigns.Staxel.TileState;
using Microsoft.Xna.Framework;
using Plukit.Base;
using Staxel.Logic;
using Staxel.Player;

namespace BetterSigns.Staxel.Commands
{
	class ChangeSignCommand: IPlayerExtendedCommand
	{
		public string Kind()
		{
			return "changeSign";
		}

		public void Invoke(PlayerEntityLogic logic, Entity entity, Blob config, Timestep timestep, EntityUniverseFacade facade)
		{
			string message = config.GetString("message");
			Color color = new Color() { PackedValue = (uint)config.GetLong("color") };
			float scale = (float)config.GetDouble("scale");
			BmFontAlign align = (BmFontAlign)config.GetLong("align");

			EntityId id = config.GetLong("id");
			Entity ent = default(Entity);
			if (facade.TryGetEntity(id, out ent) && ent.TileStateEntityLogic != null)
			{
				BulletinBoardTileStateEntityLogic entLogic = ent.TileStateEntityLogic as BulletinBoardTileStateEntityLogic;
				entLogic.ChangeSign(message, color, scale, align);
			}
		}
	}
}