using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Token: 0x020001D7 RID: 471
public class GClass3
{
	// Token: 0x06001332 RID: 4914 RVA: 0x0000C13E File Offset: 0x0000A33E
	public static bool smethod_0()
	{
		return (bool)new GClass18().method_112(null, 0xAED9B);
	}

	// Token: 0x06001333 RID: 4915 RVA: 0x0008BA28 File Offset: 0x00089C28
	public static bool smethod_1(bool bool_0)
	{
		object[] object_ = new object[]
		{
			bool_0
		};
		return (bool)new GClass18().method_112(object_, 0xB1BAB);
	}

	// Token: 0x06001334 RID: 4916 RVA: 0x0008BA60 File Offset: 0x00089C60
	internal static bool smethod_2(byte[] byte_0)
	{
		uint num4;
		for (;;)
		{
			IL_00:
			int num = 0;
			for (;;)
			{
				IL_CFF:
				int num2 = num;
				int num3 = byte_0.Length;
				num4 = 0x120C0003U;
				if (num2 >= num3)
				{
					goto Block_78;
				}
				for (;;)
				{
					int num5 = num + 3;
					int num6 = byte_0.Length;
					num4 = 0x438AU;
					if (num5 < num6)
					{
						if (num4 + 0x502E3286U != 0U)
						{
							goto IL_674;
						}
						goto IL_CFF;
					}
					IL_984:
					int num7 = num;
					num4 = 0x385E38U / num4;
					int num8 = num7 + (int)(num4 ^ 0xDDU);
					int num9 = byte_0.Length;
					num4 = 0x38200142U >> (int)num4;
					if (num8 < num9)
					{
						num4 = 0x685B0EDCU % num4;
						if (0x6E96539CU < num4)
						{
							goto IL_CFF;
						}
						byte b = byte_0[num];
						num4 *= 0x3B933693U;
						uint num10 = num4 ^ 0x6E161CAAU;
						num4 /= 0x1E47272BU;
						num4 ^= 0x1C2U;
						if (b == num10)
						{
							int num11 = num;
							num4 %= 0x7532BE1U;
							byte b2 = byte_0[num11 + (int)(num4 ^ 0x1C0U)];
							uint num12 = num4 ^ 0x1A8U;
							num4 = 0x693C4F46U * num4;
							num4 += 0x6D38F7FBU;
							if (b2 == num12)
							{
								num4 = 0x7E74318FU % num4;
								num4 = (0x337B3515U | num4);
								byte b3 = byte_0[num + (int)(num4 ^ 0x337B35DFU)];
								num4 = (0x1E966B21U | num4);
								uint num13 = num4 + 0xC0008066U;
								num4 ^= 0x3FFF7E3CU;
								if (b3 == num13)
								{
									num4 = (0x39106B47U ^ num4);
									if ((num4 ^ 0x20902279U) == 0U)
									{
										goto IL_69B;
									}
									num4 = 0x47851F20U * num4;
									uint num14 = num;
									num4 -= 0x746D4AD3U;
									int num15 = num14 + (num4 + 0xD3DBC016U);
									num4 >>= 0x18;
									byte b4 = byte_0[num15];
									uint num16 = num4 ^ 0x5EU;
									num4 += 0x678F03BCU;
									num4 += 0x9870FDD9U;
									if (b4 == num16)
									{
										uint num17 = num;
										num4 = 0x523D3195U << (int)num4;
										int num18 = num17 + (num4 ^ 0xA47A632EU);
										num4 &= 0x128713CAU;
										byte b5 = byte_0[num18];
										uint num19 = num4 - 0x2029BU;
										num4 += 0xFFFDFEB7U;
										if (b5 == num19)
										{
											if (num4 >= 0x595349C6U)
											{
												goto IL_CFF;
											}
											int num20 = num;
											int num21 = num4 - 0x1BCU;
											num4 = 0x351921B5U - num4;
											byte b6 = byte_0[num20 + num21];
											uint num22 = num4 ^ 0x35191F87U;
											num4 = (0x29A37613U ^ num4);
											num4 += 0xE34597DAU;
											if (b6 == num22)
											{
												byte b7 = byte_0[num + (int)(num4 ^ 0x1C7U)];
												num4 = 0x39856C6BU << (int)num4;
												uint num23 = num4 + 0x8CF52799U;
												num4 &= 0x12D72A31U;
												num4 ^= 0x120209D1U;
												if (b7 == num23)
												{
													num4 |= 0x6A43022DU;
													num4 += 0x387B7591U;
													byte b8 = byte_0[num + (int)(num4 - 0xA2BE7977U)];
													num4 = 0x195A2B33U >> (int)num4;
													uint num24 = num4 ^ 0x66U;
													num4 *= 0x17126C1FU;
													num4 += 0x1C1U;
													if (b8 == num24)
													{
														int num25 = num;
														num4 = 0x32CC57CFU * num4;
														int num26 = num4 ^ 0x18660207U;
														num4 -= 0x12CE7219U;
														byte b9 = byte_0[num25 + num26];
														uint num27 = num4 - 0x5978F82U;
														num4 += 0xFA6871CBU;
														if (b9 == num27)
														{
															goto Block_54;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					uint num28 = num;
					num4 /= 0x423F2026U;
					uint num29 = num28 + (num4 ^ 6U);
					num4 |= 0x6F913D7CU;
					num4 <<= 2;
					int num30 = byte_0.Length;
					num4 = 0x50F256CCU * num4;
					if (num29 < num30)
					{
						num4 = 0x2F8C1E6EU / num4;
						int num31 = num;
						num4 /= 0xA9C4985U;
						byte b10 = byte_0[num31];
						num4 /= 0x1B1B722BU;
						uint num32 = num4 ^ 0x69U;
						num4 ^= 0x46729B40U;
						if (b10 == num32)
						{
							num4 = (0x52E552E1U & num4);
							num4 = 0x12DE6BA9U + num4;
							int num33 = num;
							int num34 = num4 ^ 0x553E7DE8U;
							num4 /= 0x3C034630U;
							byte b11 = byte_0[num33 + num34];
							num4 = 0x73CB3680U * num4;
							uint num35 = num4 ^ 0x73CB36EEU;
							num4 = 0x30717CBAU * num4;
							num4 ^= 0xD8F90240U;
							if (b11 == num35)
							{
								num4 += 0x7D1576A2U;
								uint num36 = num;
								num4 = 0x55494CCEU * num4;
								int num37 = num36 + (num4 - 0xE03F7BDAU);
								num4 = 0x2B731798U << (int)num4;
								byte b12 = byte_0[num37];
								num4 = 0x1F6C7252U / num4;
								uint num38 = num4 ^ 0x6EU;
								num4 = 0x3155621U << (int)num4;
								num4 += 0x435D451FU;
								if (b12 == num38)
								{
									num4 = 0x4DF71387U + num4;
									if (num4 <= 0x353A1089U)
									{
										goto IL_00;
									}
									int num39 = num;
									int num40 = num4 + 0x6B96513CU;
									num4 = 0x11EA5FB7U << (int)num4;
									byte b13 = byte_0[num39 + num40];
									num4 &= 0x195C56DAU;
									uint num41 = num4 + 0xEEF3ADEFU;
									num4 = 0x1B904C5FU * num4;
									num4 ^= 0xA26206C0U;
									if (b13 == num41)
									{
										if ((num4 ^ 0x2AED6986U) == 0U)
										{
											goto IL_674;
										}
										uint num42 = num;
										num4 -= 0x68C03A7U;
										int num43 = num42 + (num4 + 0xC019686BU);
										num4 = (0x27944642U | num4);
										byte b14 = byte_0[num43];
										num4 ^= 0x68EC31B1U;
										uint num44 = num4 ^ 0x571AE61EU;
										num4 -= 0x23D62AA2U;
										num4 ^= 0x75362088U;
										if (b14 == num44)
										{
											num4 = 0x713A5731U - num4;
											int num45 = num + (int)(num4 ^ 0x2AC7BBF4U);
											num4 &= 0x415C4E28U;
											byte b15 = byte_0[num45];
											uint num46 = num4 ^ 0x440A45U;
											num4 &= 0x75E4351DU;
											num4 += 0x462E9B40U;
											if (b15 == num46)
											{
												num4 = 0x553243F1U * num4;
												if (num4 + 0x2C514FB5U == 0U)
												{
													goto IL_00;
												}
												num4 = 0x35FC1D0CU / num4;
												int num47 = num + (int)(num4 ^ 6U);
												num4 -= 0x3DF8036DU;
												byte b16 = byte_0[num47];
												uint num48 = num4 ^ 0xC207FCF8U;
												num4 ^= 0x847567D3U;
												if (b16 == num48)
												{
													goto Block_10;
												}
											}
										}
									}
								}
							}
						}
					}
					num4 = 0x613E6836U / num4;
					if (num4 <= 0x5D991E58U)
					{
						uint num49 = num;
						num4 &= 0x1BA2635FU;
						uint num50 = num49 + (num4 ^ 8U);
						int num51 = byte_0.Length;
						num4 += 0x1FEF5BBFU;
						int num52 = num51;
						num4 = 0x18882396U >> (int)num4;
						if (num50 < num52)
						{
							num4 |= 0x2C700E53U;
							if (0x6EDB1ADBU * num4 == 0U)
							{
								goto IL_00;
							}
							byte b17 = byte_0[num];
							uint num53 = num4 ^ 0x3CF82F81U;
							num4 += 0xDB8FF3BFU;
							if (b17 == num53)
							{
								num4 /= 0x7ED15F60U;
								if (0x7B216AB6U <= num4)
								{
									continue;
								}
								int num54 = num + (int)(num4 ^ 1U);
								num4 = 0x1D676300U >> (int)num4;
								byte b18 = byte_0[num54];
								num4 = 0xFC04090U - num4;
								uint num55 = num4 ^ 0xF258DDF9U;
								num4 ^= 0x73554580U;
								num4 += 0x977A8B86U;
								if (b18 == num55)
								{
									num4 = 0x20F7531DU << (int)num4;
									if ((num4 & 0x15462882U) == 0U)
									{
										goto IL_674;
									}
									num4 = (0x6B725E6BU & num4);
									int num56 = num;
									int num57 = num4 ^ 0x43400002U;
									num4 = 0x77AE5DA7U % num4;
									byte b19 = byte_0[num56 + num57];
									num4 = 0x4A077429U >> (int)num4;
									uint num58 = num4 - 0x940E76U;
									num4 <<= 0x1D;
									num4 ^= 0x18882396U;
									if (b19 == num58)
									{
										if (num4 >> 0x1F != 0U)
										{
											goto IL_00;
										}
										int num59 = num;
										uint num60 = num4 - 0x18882393U;
										num4 = 0x15A94AA7U % num4;
										int num61 = num59 + num60;
										num4 += 0x15C364E4U;
										byte b20 = byte_0[num61];
										num4 %= 0x276A6B8EU;
										uint num62 = num4 - 0x4024389U;
										num4 += 0x1485DF99U;
										if (b20 == num62)
										{
											uint num63 = num;
											num4 = 0x131148E5U / num4;
											int num64 = num63 + (num4 + 4U);
											num4 = 0x7AF33B82U * num4;
											byte b21 = byte_0[num64];
											uint num65 = num4 ^ 0x75U;
											num4 ^= 0x18882396U;
											if (b21 == num65)
											{
												byte b22 = byte_0[num + (int)(num4 + 0xE777DC6FU)];
												num4 ^= 0x189E1920U;
												uint num66 = num4 - 0x163A55U;
												num4 += 0x1871E8E0U;
												if (b22 == num66)
												{
													if (0x340D7121U == num4)
													{
														goto IL_00;
													}
													num4 <<= 0xA;
													int num67 = num;
													num4 = (0x78C44D80U | num4);
													int num68 = num4 - 0x78CE5D7AU;
													num4 = (0x426F000DU ^ num4);
													byte b23 = byte_0[num67 + num68];
													uint num69 = num4 ^ 0x3AA15DE1U;
													num4 ^= 0x22297E1BU;
													if (b23 == num69)
													{
														num4 = 0x401238BCU << (int)num4;
														num4 = 0x77D0D9EU - num4;
														byte b24 = byte_0[num + (int)(num4 ^ 0xD87D0D99U)];
														num4 -= 0x36EA493CU;
														uint num70 = num4 + 0x5E6D3BE0U;
														num4 ^= 0xB91AE7F4U;
														if (b24 == num70)
														{
															num4 /= 0x175645F5U;
															if (num4 * 0x4B623C7CU == 0U)
															{
																goto IL_CFF;
															}
															num4 = 0x4F650728U >> (int)num4;
															int num71 = num;
															int num72 = num4 - 0x27B2838CU;
															num4 %= 0x3C82428BU;
															byte b25 = byte_0[num71 + num72];
															num4 = 0x12A859A4U / num4;
															uint num73 = num4 + 0x6FU;
															num4 >>= 1;
															num4 += 0x18882396U;
															if (b25 == num73)
															{
																num4 %= 0x28B74EB9U;
																num4 = 0x75026E34U - num4;
																uint num74 = num;
																num4 = 0x23821095U % num4;
																int num75 = num74 + (num4 ^ 0x2382109CU);
																num4 = 0x31613B2BU % num4;
																byte b26 = byte_0[num75];
																num4 %= 0x4689502CU;
																uint num76 = num4 ^ 0xDDF2AEEU;
																num4 += 0xAA8F900U;
																if (b26 == num76)
																{
																	goto Block_28;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						num4 /= 0x36B60B6U;
						if (num4 >= 0x684B2F7BU)
						{
							goto IL_CFF;
						}
						uint num77 = num;
						num4 = 0x779609A7U * num4;
						uint num78 = num77 + (num4 ^ 0x451A4394U);
						num4 ^= 0x515E321CU;
						num4 = 0x1A0E50D5U << (int)num4;
						int num79 = byte_0.Length;
						num4 = (0x29BE59F1U ^ num4);
						int num80 = num79;
						num4 += 0x53C535ECU;
						if (num78 < num80)
						{
							num4 = 0x1B3D4DF5U * num4;
							if (0x31871071U % num4 == 0U)
							{
								goto IL_00;
							}
							num4 >>= 0x19;
							byte b27 = byte_0[num];
							num4 = 0x335645F3U - num4;
							uint num81 = num4 - 0x33564546U;
							num4 %= 0x130B1249U;
							num4 ^= 0x3A2A0ED7U;
							if (b27 == num81)
							{
								if (0x34807553U == num4)
								{
									goto IL_69B;
								}
								int num82 = num;
								num4 = 0x74FA48D1U + num4;
								byte b28 = byte_0[num82 + (int)(num4 ^ 0xAC6478AFU)];
								uint num83 = num4 + 0x539B879FU;
								num4 ^= 0x9B0E5773U;
								if (b28 == num83)
								{
									if (num4 == 0x59E16A3BU)
									{
										goto IL_00;
									}
									int num84 = num;
									int num85 = num4 ^ 0x376A2FDFU;
									num4 -= 0x6C1F3DA6U;
									byte b29 = byte_0[num84 + num85];
									uint num86 = num4 ^ 0xCB4AF240U;
									num4 += 0x6C1F3DA6U;
									if (b29 == num86)
									{
										num4 %= 0x7FF23F2FU;
										num4 = (0x683052C3U ^ num4);
										int num87 = num;
										num4 = 0x77AB2D07U / num4;
										byte b30 = byte_0[num87 + (int)(num4 + 2U)];
										uint num88 = num4 ^ 0x60U;
										num4 = (0x6DE74512U & num4);
										num4 += 0x376A2FDDU;
										if (b30 == num88)
										{
											if ((0x3791680EU & num4) == 0U)
											{
												goto IL_00;
											}
											num4 &= 0x66AC3F64U;
											int num89 = num;
											num4 <<= 1;
											int num90 = num4 ^ 0x4C505E8CU;
											num4 = 0x5B2E7CF8U % num4;
											byte b31 = byte_0[num89 + num90];
											num4 <<= 6;
											uint num91 = num4 + 0x48786472U;
											num4 += 0x7FE293DDU;
											if (b31 == num91)
											{
												if (num4 << 0 == 0U)
												{
													goto IL_674;
												}
												num4 <<= 0xD;
												int num92 = num;
												num4 <<= 0xD;
												byte b32 = byte_0[num92 + (int)(num4 ^ 0x74000005U)];
												uint num93 = num4 ^ 0x74000065U;
												num4 = 0x4EAE3C4FU / num4;
												num4 += 0x376A2FDDU;
												if (b32 == num93)
												{
													goto Block_56;
												}
											}
										}
									}
								}
							}
						}
						if (num4 > 0x531D7A85U)
						{
							goto IL_00;
						}
						int num94 = num + (int)(num4 - 0x376A2FD5U);
						num4 = (0x405B2729U ^ num4);
						if (num94 >= byte_0.Length)
						{
							goto IL_CD1;
						}
						num4 *= 0x276A3D5BU;
						if (num4 - 0x74872F9DU != 0U)
						{
							break;
						}
						continue;
					}
					IL_6F1:
					num4 += 0x3ADC5DD4U;
					int num95 = num;
					int num96 = num4 ^ 0x3ADCA15CU;
					num4 = 0x223159E0U + num4;
					byte b33 = byte_0[num95 + num96];
					num4 = (0x2EC26636U | num4);
					uint num97 = num4 ^ 0x7FCFFF73U;
					num4 = 0x40BC1D75U % num4;
					num4 += 0xBF442615U;
					if (b33 != num97)
					{
						goto IL_984;
					}
					num4 = 0x114C29ACU + num4;
					int num98 = num;
					uint num99 = num4 ^ 0x114C6D35U;
					num4 = (0x493B174BU ^ num4);
					int num100 = num98 + num99;
					num4 = (0x2683511EU & num4);
					byte b34 = byte_0[num100];
					uint num101 = num4 ^ 0x35049U;
					num4 += 0x281C67F0U;
					num4 ^= 0x281FFB86U;
					if (b34 == num101)
					{
						goto Block_42;
					}
					goto IL_984;
					IL_69B:
					num4 = 0x474F3CA4U - num4;
					int num102 = num;
					int num103 = num4 ^ 0x474EF91BU;
					num4 = 0x21401F76U << (int)num4;
					byte b35 = byte_0[num102 + num103];
					num4 = 0x42305FC0U >> (int)num4;
					uint num104 = num4 ^ 0x42305F85U;
					num4 += 0xBDCFE3CAU;
					if (b35 != num104)
					{
						goto IL_984;
					}
					num4 %= 0x6A665C04U;
					if (num4 <= 0x61CE05B2U)
					{
						goto IL_6F1;
					}
					goto IL_00;
					IL_674:
					num4 &= 0x359C1722U;
					byte b36 = byte_0[num];
					num4 <<= 0x1B;
					uint num105 = num4 - 0xFFFFFAFU;
					num4 += 0xF000438AU;
					if (b36 == num105)
					{
						goto IL_69B;
					}
					goto IL_984;
				}
				byte b37 = byte_0[num];
				num4 = 0x36B03BAU - num4;
				uint num106 = num4 - 0x14D2B0AEU;
				num4 &= 0x18542514U;
				num4 += 0x66E0E8E0U;
				if (b37 == num106)
				{
					if (num4 >> 0xA == 0U)
					{
						break;
					}
					uint num107 = num;
					num4 = (0x6F030C96U | num4);
					int num108 = num107 + (num4 ^ 0x7F330CF7U);
					num4 <<= 0x1D;
					byte b38 = byte_0[num108];
					num4 -= 0x473D4E17U;
					uint num109 = num4 + 0x873D4E78U;
					num4 ^= 0xFF3B91DU;
					if (b38 == num109)
					{
						num4 %= 0x7F36497AU;
						uint num110 = num;
						num4 = 0x5BC518C0U / num4;
						int num111 = num110 + (num4 + 2U);
						num4 = (0x26922977U ^ num4);
						byte b39 = byte_0[num111];
						num4 >>= 0x14;
						uint num112 = num4 ^ 0x21BU;
						num4 = 0x462C725FU >> (int)num4;
						num4 ^= 0x77121ECDU;
						if (b39 == num112)
						{
							if (num4 - 0x69BC213CU == 0U)
							{
								continue;
							}
							num4 /= 0x719B05C4U;
							byte b40 = byte_0[num + (int)(num4 - 0xFFFFFFFEU)];
							uint num113 = num4 - 0xFFFFFFA0U;
							num4 <<= 6;
							num4 += 0x773108B4U;
							if (b40 == num113)
							{
								num4 = 0x3EF41388U / num4;
								if (num4 > 0x7FEE165BU)
								{
									continue;
								}
								num4 /= 0x77502CF4U;
								int num114 = num;
								num4 &= 0x4D7D2244U;
								byte b41 = byte_0[num114 + (int)(num4 ^ 4U)];
								num4 = 0x2D330F84U << (int)num4;
								uint num115 = num4 ^ 0x2D330FE8U;
								num4 += 0x2CEC122AU;
								num4 ^= 0x2D2E295AU;
								if (b41 == num115)
								{
									num4 ^= 0x716974DCU;
									if (num4 >= 0x3FA0188DU)
									{
										break;
									}
									num4 = 0x402E8BU >> (int)num4;
									int num116 = num;
									num4 &= 0x36097D7AU;
									int num117 = num4 + 0xFFFFBFDBU;
									num4 = 0x5C851696U << (int)num4;
									byte b42 = byte_0[num116 + num117];
									uint num118 = num4 ^ 0x145A586CU;
									num4 += 0x62D6B0F4U;
									if (b42 == num118)
									{
										if (num4 < 0x76765D24U)
										{
											break;
										}
										byte b43 = byte_0[num + (int)(num4 - 0x773108EEU)];
										num4 = 0x7BB712A5U / num4;
										uint num119 = num4 + 0x64U;
										num4 = 0x6DD5463DU * num4;
										num4 += 0x95BC2B7U;
										if (b43 == num119)
										{
											num4 = 0x35A226B2U - num4;
											int num120 = num;
											uint num121 = num4 ^ 0xBE711DB9U;
											num4 -= 0x74077783U;
											int num122 = num120 + num121;
											num4 = 0x7A0A0DE4U - num4;
											byte b44 = byte_0[num122];
											num4 -= 0x3B1A09C1U;
											uint num123 = num4 + 0xB79A284U;
											num4 = (0x54E03CA0U | num4);
											num4 ^= 0x83D7751CU;
											if (b44 == num123)
											{
												num4 = 0x58FC60A0U / num4;
												if (num4 >= 0x5EC137E2U)
												{
													break;
												}
												num4 >>= 9;
												int num124 = num;
												num4 = 0x18424C4DU << (int)num4;
												uint num125 = num4 ^ 0x18424C45U;
												num4 = 0x47F6618EU / num4;
												int num126 = num124 + num125;
												num4 = (0x3FD25E4EU | num4);
												byte b45 = byte_0[num126];
												uint num127 = num4 ^ 0x3FD25E3DU;
												num4 += 0x375EAAA6U;
												if (b45 == num127)
												{
													goto Block_76;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				IL_CD1:
				num4 %= 0x213F2116U;
				if (num4 / 0x724C1B0BU != 0U)
				{
					break;
				}
				int num128 = num;
				num4 = (0x46A36C47U & num4);
				int num129 = num128 + (int)(num4 - 0x2232401U);
				num4 |= 0x12F349D8U;
				num = num129;
			}
		}
		Block_10:
		return (num4 ^ 0x46729B41U) != 0U;
		Block_28:
		return (num4 ^ 0x18882397U) != 0U;
		Block_42:
		num4 = 0x66CE3F85U % num4;
		return num4 - 0x2CCCU != 0U;
		Block_54:
		return (num4 ^ 0x1C0U) != 0U;
		Block_56:
		num4 = 0x5D65313FU * num4;
		return (num4 ^ 0x217C1462U) != 0U;
		Block_76:
		num4 /= 0x36F31B78U;
		return (num4 ^ 3U) != 0U;
		Block_78:
		return (num4 ^ 0x120C0003U) != 0U;
	}

	// Token: 0x06001335 RID: 4917 RVA: 0x0000C155 File Offset: 0x0000A355
	public static bool smethod_3()
	{
		return (bool)new GClass18().method_112(null, 0xACFFD);
	}

	// Token: 0x06001336 RID: 4918 RVA: 0x0008C7D0 File Offset: 0x0008A9D0
	public static bool smethod_4()
	{
		uint num = 0x204A5E8FU;
		for (;;)
		{
			IL_5B9:
			bool flag = GClass10.smethod_0();
			num = (0x5F80565CU & num);
			if (flag)
			{
				break;
			}
			IL_40D:
			while (0x241F45AFU >= num)
			{
				RuntimeTypeHandle handle = typeof(GClass3).TypeHandle;
				num >>= 0x13;
				Type typeFromHandle = Type.GetTypeFromHandle(handle);
				num |= 0x7A73412DU;
				IntPtr hinstance = Marshal.GetHINSTANCE(typeFromHandle.Module);
				num = 0x3DDA0999U % num;
				IntPtr intPtr = hinstance;
				num -= 0x474C2419U;
				if (0x79ED4701U >= num)
				{
					break;
				}
				long num2 = intPtr.ToInt64();
				num >>= 0;
				long num3 = num2;
				num = 0x355A3881U >> (int)num;
				uint num5;
				long num7;
				bool result;
				byte[] array2;
				GClass7 gclass;
				for (;;)
				{
					long num4 = num3;
					num = 0x77491F9DU >> (int)num;
					num5 = (uint)Marshal.ReadInt32(new IntPtr(num4 + (long)((ulong)(num ^ 0x3BA48FCEU))));
					num = 0x13D8469DU * num;
					ulong num6 = (ulong)(num + 0xCCF17AAAU);
					num = 0x7924086U - num;
					num7 = (long)num6;
					bool flag2 = (num ^ 0xD483BB31U) != 0U;
					num = 0x73A67701U + num;
					result = flag2;
					int num8 = (int)(num ^ 0x482A323DU);
					num -= 0x73FC3316U;
					byte[] array = new byte[num8];
					num |= 0x2D61306FU;
					array2 = array;
					if (0x5C676C91U >= num)
					{
						goto IL_40D;
					}
					gclass = new GClass7();
					num = 0x40824F1U >> (int)num;
					if (num >> 3 != 0U)
					{
						goto IL_5D1;
					}
					uint num9 = (uint)Marshal.ReadInt32(new IntPtr(num3 + (long)((ulong)(num + 0U))));
					GClass7 gclass2 = gclass;
					long value = num3 + num7;
					num = 0x60124074U >> (int)num;
					IntPtr intptr_ = new IntPtr(value);
					num &= 0x5E691D6DU;
					uint uint_ = num5;
					num %= 0x3AAE4AEFU;
					if (num9 != gclass2.method_0(intptr_, uint_))
					{
						num >>= 0x17;
						bool flag3 = (num ^ 0xAU) != 0U;
						num |= 0x25DA43B0U;
						result = flag3;
						num += 0xDF7771BBU;
					}
					GClass8 gclass3 = new GClass8();
					num &= 0x52D80150U;
					int num10 = (int)(num ^ 0x500150U);
					num <<= 5;
					int num11 = num10;
					for (;;)
					{
						num = 0x21241721U * num;
						if (0x44CE181DU % num == 0U)
						{
							break;
						}
						long num12 = (long)num11;
						num = 0x3DF054D8U / num;
						ulong num13 = (ulong)num12;
						num = (0x2C6C5CECU | num);
						if (num13 >= (ulong)num5)
						{
							goto IL_30A;
						}
						Marshal.Copy(new IntPtr(num3 + num7 + (long)num11), array2, 0, array2.Length);
						uint num14 = gclass3.method_0(BitConverter.ToUInt32(array2, 0));
						uint uint_2 = gclass3.method_0(BitConverter.ToUInt32(array2, 4));
						uint num15 = gclass3.method_0(BitConverter.ToUInt32(array2, 8));
						GClass7 gclass4 = gclass;
						IntPtr intptr_2 = new IntPtr(num3 + (long)((ulong)num14));
						num = 0U;
						if (gclass4.method_0(intptr_2, uint_2) != num15)
						{
							result = ((num ^ 0U) != 0U);
							num ^= 0U;
						}
						int num16 = num11;
						int num17 = array2.Length;
						num = (0x59743F3EU ^ num);
						num11 = num16 + num17;
						num ^= 0x5374153EU;
					}
				}
				IL_30A:
				num = 0x25FB4E4AU >> (int)num;
				long num18 = num3;
				long num19 = (long)((ulong)GClass10.smethod_3());
				num = (0x1282285U & num);
				long value2 = num18 + num19;
				num = 0x77997D43U / num;
				IntPtr ptr = new IntPtr(value2);
				num = (0x4B0F6BC7U | num);
				uint num20 = (uint)Marshal.ReadInt32(ptr);
				num -= 0x49AE7C25U;
				num5 = num20;
				num <<= 0x14;
				if (num / 0x33B05924U == 0U)
				{
					break;
				}
				ulong num21 = (ulong)GClass10.smethod_2();
				num = 0x19452A73U / num;
				long num22 = (long)num21;
				num = 0x356948AEU * num;
				num7 = num22;
				long num23 = num3;
				num = 0x671D313FU + num;
				ulong num24 = (ulong)GClass10.smethod_4();
				num = 0x2FAD24C7U * num;
				long value3 = num23 + (long)num24;
				num |= 0x3EEE51A7U;
				uint num25 = (uint)Marshal.ReadInt32(new IntPtr(value3));
				GClass7 gclass5 = gclass;
				num = 0x459A20B8U - num;
				if (num25 != gclass5.method_0(new IntPtr(num3 + num7), num5))
				{
					num = 0x7BC46FCEU >> (int)num;
					result = (num - 0x3DU != 0U);
					num ^= 0x59AAC84U;
				}
				num = 0x3C2C113FU - num;
				if (0x76D245F7U % num != 0U)
				{
					GClass8 gclass6 = new GClass8();
					int num26 = (int)(num - 0x36916486U);
					num |= 0x7A0237F3U;
					int num27 = num26;
					if (0x71D72D5CU < num)
					{
						while (0x251B95U != num)
						{
							ulong num28 = (ulong)((long)num27);
							ulong num29 = (ulong)num5;
							num = 0x70F82731U >> (int)num;
							if (num28 >= num29)
							{
								return result;
							}
							Marshal.Copy(new IntPtr(num3 + num7 + (long)num27), array2, 0, array2.Length);
							uint num30 = gclass6.method_0(BitConverter.ToUInt32(array2, 0));
							uint uint_3 = gclass6.method_0(BitConverter.ToUInt32(array2, 4));
							uint num31 = gclass6.method_0(BitConverter.ToUInt32(array2, 8));
							uint num32 = gclass.method_0(new IntPtr(num3 + (long)((ulong)num30)), uint_3);
							num = 0x5F26F6BDU;
							if (num32 != num31)
							{
								result = (num - 0x5F26F6BDU != 0U);
								num += 0U;
							}
							num *= 0x58D01B5EU;
							if (0x36102C21U >= num)
							{
								break;
							}
							int num33 = num27;
							num &= 0x68715308U;
							int num34 = array2.Length;
							num = 0xA46423CU * num;
							num27 = num33 + num34;
							num += 0x481377F7U;
						}
						goto IL_5B9;
					}
					break;
				}
			}
			break;
		}
		IL_5D1:
		num = 0x61B437E1U + num;
		return num - 0x61B48DEDU != 0U;
	}

	// Token: 0x06001337 RID: 4919 RVA: 0x0008CDC0 File Offset: 0x0008AFC0
	public static bool smethod_5(ref string string_0)
	{
		object[] array = new object[]
		{
			string_0
		};
		bool result;
		try
		{
			result = (bool)new GClass18().method_112(array, 0xAEAB6);
		}
		finally
		{
			string_0 = array[0];
		}
		return result;
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001338 RID: 4920 RVA: 0x0000C16C File Offset: 0x0000A36C
	// (set) Token: 0x06001339 RID: 4921 RVA: 0x0000C174 File Offset: 0x0000A374
	public GClass11 GClass11_0 { get; private set; }

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x0600133A RID: 4922 RVA: 0x0000C17D File Offset: 0x0000A37D
	// (set) Token: 0x0600133B RID: 4923 RVA: 0x0000C185 File Offset: 0x0000A385
	public GClass17 GClass17_0 { get; private set; }

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x0600133C RID: 4924 RVA: 0x0000C18E File Offset: 0x0000A38E
	// (set) Token: 0x0600133D RID: 4925 RVA: 0x0000C196 File Offset: 0x0000A396
	public GClass12 GClass12_0 { get; private set; }

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x0600133E RID: 4926 RVA: 0x0000C19F File Offset: 0x0000A39F
	// (set) Token: 0x0600133F RID: 4927 RVA: 0x0000C1A7 File Offset: 0x0000A3A7
	public GClass4 GClass4_0 { get; private set; }

	// Token: 0x06001340 RID: 4928 RVA: 0x0008CE0C File Offset: 0x0008B00C
	private static string smethod_6(uint uint_0)
	{
		object[] object_ = new object[]
		{
			uint_0
		};
		return (string)new GClass18().method_112(object_, 0xACFB5);
	}

	// Token: 0x06001341 RID: 4929 RVA: 0x0000C1B0 File Offset: 0x0000A3B0
	public static void smethod_7(string string_0)
	{
		MessageBox.Show(string_0, Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	// Token: 0x06001342 RID: 4930 RVA: 0x0000C1CB File Offset: 0x0000A3CB
	private static void smethod_8()
	{
		new GClass18().method_112(null, 0xB17C8);
	}

	// Token: 0x06001343 RID: 4931 RVA: 0x0008CE44 File Offset: 0x0008B044
	public bool method_0(long long_0)
	{
		object[] object_ = new object[]
		{
			this,
			long_0
		};
		return (bool)new GClass18().method_112(object_, 0xAB959);
	}

	// Token: 0x06001345 RID: 4933 RVA: 0x0000C1DE File Offset: 0x0000A3DE
	// Note: this type is marked as 'beforefieldinit'.
	static GClass3()
	{
		GClass3.gclass3_0 = new GClass3();
	}

	// Token: 0x06001346 RID: 4934 RVA: 0x0000C1EA File Offset: 0x0000A3EA
	public static string smethod_9()
	{
		return (string)new GClass18().method_112(null, 0xB2B72);
	}

	// Token: 0x04000A99 RID: 2713
	public static readonly GClass3 gclass3_0;

	// Token: 0x04000A9A RID: 2714
	[CompilerGenerated]
	private GClass11 gclass11_0;

	// Token: 0x04000A9B RID: 2715
	[CompilerGenerated]
	private GClass17 gclass17_0;

	// Token: 0x04000A9C RID: 2716
	[CompilerGenerated]
	private GClass12 gclass12_0;

	// Token: 0x04000A9D RID: 2717
	[CompilerGenerated]
	private GClass4 gclass4_0;
}
