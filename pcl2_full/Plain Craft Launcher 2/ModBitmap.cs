using Microsoft.VisualBasic.CompilerServices;
using PCL.My;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PCL
{
	// Token: 0x0200018D RID: 397
	[StandardModule]
	public sealed class ModBitmap
	{
		// Token: 0x060011A7 RID: 4519 RVA: 0x0000B368 File Offset: 0x00009568
		// Note: this type is marked as 'beforefieldinit'.
		static ModBitmap()
		{
			ModBitmap.interpreterFilter = new Dictionary<string, ModBitmap.MyBitmap>();
		}

		// Token: 0x0400092A RID: 2346
		public static Dictionary<string, ModBitmap.MyBitmap> interpreterFilter;

		// Token: 0x0200018E RID: 398
		public class MyBitmap
		{
			// Token: 0x060011A8 RID: 4520 RVA: 0x0000B374 File Offset: 0x00009574
			public static implicit operator ModBitmap.MyBitmap(Image Image)
			{
				return new ModBitmap.MyBitmap(Image);
			}

			// Token: 0x060011A9 RID: 4521 RVA: 0x0000B37C File Offset: 0x0000957C
			public static implicit operator Image(ModBitmap.MyBitmap Image)
			{
				return Image.requestMapper;
			}

			// Token: 0x060011AA RID: 4522 RVA: 0x0000B384 File Offset: 0x00009584
			public static implicit operator ModBitmap.MyBitmap(ImageSource Image)
			{
				return new ModBitmap.MyBitmap(Image);
			}

			// Token: 0x060011AB RID: 4523 RVA: 0x0007D420 File Offset: 0x0007B620
			public static implicit operator ImageSource(ModBitmap.MyBitmap Image)
			{
				Bitmap bitmap = Image.requestMapper;
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				ImageSource result;
				try
				{
					int bufferSize = checked(rect.Width * rect.Height * 4);
					result = BitmapSource.Create(bitmap.Width, bitmap.Height, (double)ModBase._BridgeRule, (double)ModBase._BridgeRule, PixelFormats.Bgra32, null, bitmapData.Scan0, bufferSize, bitmapData.Stride);
				}
				finally
				{
					bitmap.UnlockBits(bitmapData);
				}
				return result;
			}

			// Token: 0x060011AC RID: 4524 RVA: 0x0000B38C File Offset: 0x0000958C
			public static implicit operator ModBitmap.MyBitmap(Bitmap Image)
			{
				return new ModBitmap.MyBitmap(Image);
			}

			// Token: 0x060011AD RID: 4525 RVA: 0x0000B37C File Offset: 0x0000957C
			public static implicit operator Bitmap(ModBitmap.MyBitmap Image)
			{
				return Image.requestMapper;
			}

			// Token: 0x060011AE RID: 4526 RVA: 0x0000B394 File Offset: 0x00009594
			public static implicit operator ModBitmap.MyBitmap(ImageBrush Image)
			{
				return new ModBitmap.MyBitmap(Image);
			}

			// Token: 0x060011AF RID: 4527 RVA: 0x0000B39C File Offset: 0x0000959C
			public static implicit operator ImageBrush(ModBitmap.MyBitmap Image)
			{
				return new ImageBrush(new ModBitmap.MyBitmap(Image.requestMapper));
			}

			// Token: 0x060011B0 RID: 4528 RVA: 0x00002440 File Offset: 0x00000640
			public MyBitmap()
			{
			}

			// Token: 0x060011B1 RID: 4529 RVA: 0x0007D4B8 File Offset: 0x0007B6B8
			public MyBitmap(string FilePathOrResourceName)
			{
				FileStream fileStream = null;
				try
				{
					if (FilePathOrResourceName.StartsWith(ModBase.m_ExpressionRule))
					{
						if (ModBitmap.interpreterFilter.ContainsKey(FilePathOrResourceName))
						{
							this.requestMapper = ModBitmap.interpreterFilter[FilePathOrResourceName].requestMapper;
						}
						else
						{
							this.requestMapper = new ModBitmap.MyBitmap((ImageSource)new ImageSourceConverter().ConvertFromString(FilePathOrResourceName)).requestMapper;
							ModBitmap.interpreterFilter.Add(FilePathOrResourceName, new ModBitmap.MyBitmap(this.requestMapper));
						}
					}
					else
					{
						fileStream = new FileStream(FilePathOrResourceName, FileMode.Open);
						this.requestMapper = new Bitmap(fileStream);
					}
				}
				catch (Exception ex)
				{
					this.requestMapper = (Bitmap)MyWpfExtension.PopFactory().TryFindResource(FilePathOrResourceName);
					if (this.requestMapper == null)
					{
						this.requestMapper = new Bitmap(1, 1);
						ModBase.Log(ex, "加载位图失败（" + FilePathOrResourceName + "）", ModBase.LogLevel.Debug, "出现错误");
						throw;
					}
					ModBase.Log(ex, "指定类型有误的位图加载（" + FilePathOrResourceName + "）", ModBase.LogLevel.Developer, "出现错误");
				}
				finally
				{
					if (fileStream != null)
					{
						fileStream.Close();
						fileStream.Dispose();
					}
				}
			}

			// Token: 0x060011B2 RID: 4530 RVA: 0x0007D5F0 File Offset: 0x0007B7F0
			public MyBitmap(ImageSource Image)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					new PngBitmapEncoder
					{
						Frames = 
						{
							BitmapFrame.Create((BitmapSource)Image)
						}
					}.Save(memoryStream);
					this.requestMapper = new Bitmap(memoryStream);
				}
			}

			// Token: 0x060011B3 RID: 4531 RVA: 0x0000B3B3 File Offset: 0x000095B3
			public MyBitmap(Image Image)
			{
				this.requestMapper = (Bitmap)Image;
			}

			// Token: 0x060011B4 RID: 4532 RVA: 0x0000B3C7 File Offset: 0x000095C7
			public MyBitmap(Bitmap Image)
			{
				this.requestMapper = Image;
			}

			// Token: 0x060011B5 RID: 4533 RVA: 0x0007D654 File Offset: 0x0007B854
			public MyBitmap(ImageBrush Image)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					new BmpBitmapEncoder
					{
						Frames = 
						{
							BitmapFrame.Create((BitmapSource)Image.ImageSource)
						}
					}.Save(memoryStream);
					this.requestMapper = new Bitmap(memoryStream);
				}
			}

			// Token: 0x060011B6 RID: 4534 RVA: 0x0007D6BC File Offset: 0x0007B8BC
			public Bitmap Rotation(double angle)
			{
				Image image = this.requestMapper;
				float num = (float)image.Width;
				Bitmap bitmap = checked(new Bitmap((int)Math.Round((double)num), (int)Math.Round((double)num)));
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.TranslateTransform(num / 2f, num / 2f);
					graphics.RotateTransform((float)angle);
					graphics.TranslateTransform(-num / 2f, -num / 2f);
					graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Width));
				}
				return bitmap;
			}

			// Token: 0x060011B7 RID: 4535 RVA: 0x0007D760 File Offset: 0x0007B960
			public Bitmap Clip(Rectangle rect)
			{
				Image image = this.requestMapper;
				Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.DrawImageUnscaled(image, rect);
				}
				return bitmap;
			}

			// Token: 0x060011B8 RID: 4536 RVA: 0x0000B3D6 File Offset: 0x000095D6
			public Bitmap LeftRightFilp()
			{
				Bitmap bitmap = new Bitmap(this.requestMapper);
				bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
				return bitmap;
			}

			// Token: 0x060011B9 RID: 4537 RVA: 0x0007D7B4 File Offset: 0x0007B9B4
			public void Save(string FilePath)
			{
				BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
				bitmapEncoder.Frames.Add(BitmapFrame.Create((BitmapSource)this));
				using (FileStream fileStream = new FileStream(FilePath, FileMode.Create))
				{
					bitmapEncoder.Save(fileStream);
				}
			}

			// Token: 0x0400092B RID: 2347
			public Bitmap requestMapper;
		}
	}
}
