using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.Utils;
using Terraria.ID;

namespace UniverseOfSwordsMod.Projectiles;

public class GreenSOTUBeam : ModProjectile
{
	private const float MaxChargeValue = 1f;

	private const float MoveDistance = 60f;

	public float Distance
	{
		get
		{
			return Projectile.ai[0];
		}
		set
		{
			Projectile.ai[0] = value;
		}
	}

	public float Charge
	{
		get
		{
			return Projectile.localAI[0];
		}
		set
		{
			Projectile.localAI[0] = value;
		}
	}

	public bool AtMaxCharge => Charge == 1f;

	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.friendly = true;
		Projectile.penetrate = -1;
		Projectile.tileCollide = false;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.hide = true;
	}

	public override bool PreDraw(ref Color lightColor)
	{
		if (AtMaxCharge)
		{
			DrawLaser(Main.spriteBatch, TextureAssets.Projectile[Projectile.type].Value, ((Entity)Main.player[Projectile.owner]).Center, Projectile.velocity, 10f, Projectile.damage, -1.57f, 1f, 1000f, Color.White, 60);
		}
		return false;
	}

	public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default(Color), int transDist = 50)
	{
		Vector2 origin = start;
		float r = Utils.ToRotation(unit) + rotation;
		for (float i = transDist; i <= Distance; i += step)
		{
			Color c = Color.White;
			origin = start + i * unit;
			spriteBatch.Draw(texture, origin - Main.screenPosition, (Rectangle?)new Rectangle(0, 26, 28, 26), (i < (float)transDist) ? Color.Transparent : c, r, new Vector2(14f, 13f), scale, (SpriteEffects)0, 0f);
		}
		spriteBatch.Draw(texture, start + unit * ((float)transDist - step) - Main.screenPosition, (Rectangle?)new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, (SpriteEffects)0, 0f);
		spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition, (Rectangle?)new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, (SpriteEffects)0, 0f);
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
	{
		if (AtMaxCharge)
		{
			Player player = Main.player[Projectile.owner];
			Vector2 unit = Projectile.velocity;
			float point = 0f;
			return Collision.CheckAABBvLineCollision(Utils.TopLeft(targetHitbox), Utils.Size(targetHitbox), player.Center, player.Center + unit * Distance, 22f, ref point);
		}
		return false;
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.immune[Projectile.owner] = 5;
	}

	public override void AI()
	{
		Vector2 mousePos = Main.MouseWorld;
		Player player = Main.player[Projectile.owner];
		if (Projectile.owner == Main.myPlayer)
		{
			Vector2 diff = mousePos - player.Center;
			diff.Normalize();
			Projectile.velocity = diff;
			Projectile.direction = ((Main.MouseWorld.X > player.position.X) ? 1 : (-1));
			Projectile.netUpdate = true;
		}
		Projectile.position = player.Center + Projectile.velocity * 60f;
		Projectile.timeLeft = 2;
		int dir = Projectile.direction;
		player.ChangeDir(dir);
		player.heldProj = Projectile.whoAmI;
		player.itemTime = 2;
		player.itemAnimation = 2;
		player.itemRotation = (float)Math.Atan2(Projectile.velocity.Y * (float)dir, Projectile.velocity.X * (float)dir);
		if (!player.channel)
		{
			Projectile.Kill();
		}
		else
		{
			if (Main.time % 10.0 < 1.0 && !player.CheckMana(player.inventory[player.selectedItem].mana, true, false))
			{
				Projectile.Kill();
			}
			Vector2 offset = Projectile.velocity;
			offset *= 40f;
			Vector2 pos = player.Center + offset - new Vector2(10f, 10f);
			if (Charge < 1f)
			{
				Charge++;
			}
			int chargeFact = (int)(Charge / 20f);
			Vector2 dustVelocity = Vector2.UnitX * 18f;
			dustVelocity = Utils.RotatedBy(dustVelocity, (double)(Projectile.rotation - 1.57f), default(Vector2));
			Vector2 spawnPos = Projectile.Center + dustVelocity;
			for (int j = 0; j < chargeFact + 1; j++)
			{
				Vector2 spawn = spawnPos + Utils.ToRotationVector2((float)Main.rand.NextDouble() * 6.28f) * (12f - (float)(chargeFact * 2));
				Dust obj = Main.dust[Dust.NewDust(pos, 20, 20, DustID.GreenFairy, Projectile.velocity.X / 2f, Projectile.velocity.Y / 2f, 0, default(Color), 1f)];
				obj.velocity = Vector2.Normalize(spawnPos - spawn) * 1.5f * (10f - (float)chargeFact * 2f) / 10f;
				obj.noGravity = true;
				obj.scale = 2f;
				obj.scale = (float)Main.rand.Next(10, 20) * 0.05f;
			}
		}
		if (Charge < 1f)
		{
			return;
		}
		Vector2 start = player.Center;
		Vector2 unit = Projectile.velocity;
		unit *= -1f;
		for (Distance = 60f; Distance <= 2200f; Distance += 5f)
		{
			start = player.Center + Projectile.velocity * Distance;
			if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1))
			{
				Distance -= 5f;
				break;
			}
		}
		Vector2 dustPos = player.Center + Projectile.velocity * Distance;
		Vector2 dustVel = default(Vector2);
		for (int i = 0; i < 2; i++)
		{
			float num1 = Utils.ToRotation(Projectile.velocity) + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * 1.57f;
			float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
			//dustVel = (float)Math.Cos(num1) * num2, (float)Math.Sin(num1) * num2;
			dustVel.X = (float)Math.Cos(num1) * num2;
			dustVel.Y = (float)Math.Sin(num1) * num2;
			Dust obj2 = Main.dust[Dust.NewDust(dustPos, 0, 0, DustID.GreenFairy, dustVel.X, dustVel.Y, 0, default(Color), 1f)];
			obj2.noGravity = true;
			obj2.scale = 1f;
			Dust obj3 = Dust.NewDustDirect(((Entity)Main.player[Projectile.owner]).Center, 0, 0, DustID.GreenFairy, (0f - unit.X) * Distance, (0f - unit.Y) * Distance, 0, default(Color), 1f);
			obj3.fadeIn = 0f;
			obj3.noGravity = true;
			obj3.scale = 1f;
		}
		if (Main.rand.Next(5) == 0)
		{
			Vector2 offset2 = Utils.RotatedBy(Projectile.velocity, 1.5700000524520874, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)Projectile.width;
			Dust dust = Main.dust[Dust.NewDust(dustPos + offset2 - Vector2.One * 4f, 8, 8, DustID.GreenFairy, 0f, 0f, 100, default(Color), 1.5f)];
			dust.velocity *= 0.5f;
			dust.velocity.Y = 0f - Math.Abs(dust.velocity.Y);
			unit = dustPos - ((Entity)Main.player[Projectile.owner]).Center;
			unit.Normalize();
			dust = Main.dust[Dust.NewDust(((Entity)Main.player[Projectile.owner]).Center + 55f * unit, 8, 8, DustID.GreenFairy, 0f, 0f, 100, default(Color), 1.5f)];
			dust.velocity *= 0.5f;
			dust.velocity.Y = 0f - Math.Abs(dust.velocity.Y);
		}
		DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
		Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * (Distance - 60f), 26f, new TileActionAttempt(DelegateMethods.CastLight));
	}

	public override bool ShouldUpdatePosition()
	{
		return false;
	}

	public override void CutTiles()
	{
		DelegateMethods.tilecut_0 = (TileCuttingContext)2;
		Vector2 unit = Projectile.velocity;
		Utils.PlotTileLine(Projectile.Center, Projectile.Center + unit * Distance, (float)(Projectile.width + 16) * Projectile.scale, new TileActionAttempt(DelegateMethods.CutTiles));
	}
}
