using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;

// Token: 0x020001EA RID: 490
public class GClass18
{
	// Token: 0x0600137A RID: 4986 RVA: 0x0008DC88 File Offset: 0x0008BE88
	public GClass18()
	{
		uint num;
		for (;;)
		{
			IL_00:
			num = 0x21050C6DU;
			this.dictionary_0 = new Dictionary<uint, GClass18.Delegate2>();
			for (;;)
			{
				IL_12A5:
				num = 0x39AF192AU * num;
				Type typeFromHandle = typeof(GClass18);
				num ^= 0x49845FEFU;
				this.module_0 = typeFromHandle.Module;
				if (num + 0x7C6706A4U != 0U)
				{
					for (;;)
					{
						IL_1287:
						num = 0xBD56E09U >> (int)num;
						this.stack_0 = new Stack<GClass18.Class9>();
						for (;;)
						{
							IL_B5F:
							num |= 0x35AF0A0AU;
							this.list_0 = new List<GClass18.Class8>();
							if (0x62977D99U >= num)
							{
								goto IL_AEA;
							}
							for (;;)
							{
								IL_B28:
								num *= 0x2D1446FAU;
								this.stack_2 = new Stack<int>();
								this.list_2 = new List<IntPtr>();
								num = 0x31AE47A0U % num;
								if (0x22B61C31U % num == 0U)
								{
									goto IL_12A5;
								}
								base..ctor();
								num >>= 0x1D;
								if (num > 0x78231EE0U)
								{
									goto IL_00;
								}
								for (;;)
								{
									IntPtr hinstance = Marshal.GetHINSTANCE(this.module_0);
									num ^= 0x7F9C60DAU;
									IntPtr intPtr = hinstance;
									num = 0x3E455C61U << (int)num;
									long num2 = intPtr.ToInt64();
									num %= 0x60FD371BU;
									this.long_0 = num2;
									num >>= 0xB;
									num = 0x5ED56909U << (int)num;
									Dictionary<uint, GClass18.Delegate2> dictionary = this.dictionary_0;
									num >>= 0x1C;
									uint key = num + uint.MaxValue;
									num = 0x311F00E4U % num;
									dictionary[key] = new GClass18.Delegate2(this.method_42);
									num = 0x49D25E66U << (int)num;
									Dictionary<uint, GClass18.Delegate2> dictionary2 = this.dictionary_0;
									num = 0x678527EAU >> (int)num;
									uint key2 = num + 0xFE61EB62U;
									num = (0x7605212FU ^ num);
									dictionary2[key2] = new GClass18.Delegate2(this.method_47);
									num = (0x5D6727A3U ^ num);
									if (num > 0x44481A3EU)
									{
										goto IL_00;
									}
									num &= 0x121E4849U;
									Dictionary<uint, GClass18.Delegate2> dictionary3 = this.dictionary_0;
									uint key3 = num + 0xFDE40001U;
									num ^= 0x28734AB0U;
									dictionary3[key3] = new GClass18.Delegate2(this.method_69);
									Dictionary<uint, GClass18.Delegate2> dictionary4 = this.dictionary_0;
									num = 0xBC70C47U << (int)num;
									dictionary4[num - 0x188DFFFDU] = new GClass18.Delegate2(this.method_45);
									if (0x19FD35ABU == num)
									{
										goto IL_00;
									}
									num *= 0xF153D81U;
									Dictionary<uint, GClass18.Delegate2> dictionary5 = this.dictionary_0;
									num *= 0x4F911428U;
									uint key4 = num ^ 0x76300004U;
									num -= 0x618F78C1U;
									IntPtr intptr_ = ldftn(method_109);
									num = 0x27006358U - num;
									dictionary5[key4] = new GClass18.Delegate2(this, intptr_);
									num = 0x4EFA05CFU + num;
									num |= 0x3C6D5C84U;
									Dictionary<uint, GClass18.Delegate2> dictionary6 = this.dictionary_0;
									num = 0x41E80918U * num;
									uint key5 = num ^ 0x3B9D1A25U;
									num &= 0x3502173FU;
									num ^= 0x13296B33U;
									GClass18.Delegate2 value = new GClass18.Delegate2(this.method_61);
									num = 0x73855C3EU - num;
									dictionary6[key5] = value;
									num = 0x46961186U * num;
									Dictionary<uint, GClass18.Delegate2> dictionary7 = this.dictionary_0;
									num = (0x174A2C1BU & num);
									uint key6 = num ^ 0x5400004U;
									num &= 0x20C96925U;
									IntPtr intptr_2 = ldftn(method_52);
									num = (0x600D0FF2U | num);
									dictionary7[key6] = new GClass18.Delegate2(this, intptr_2);
									if (0x4C492CDFU > num)
									{
										goto IL_1287;
									}
									Dictionary<uint, GClass18.Delegate2> dictionary8 = this.dictionary_0;
									num /= 0x10DF00FFU;
									uint key7 = num ^ 2U;
									IntPtr intptr_3 = ldftn(method_81);
									num |= 0x99D384FU;
									GClass18.Delegate2 value2 = new GClass18.Delegate2(this, intptr_3);
									num = 0x57927F49U + num;
									dictionary8[key7] = value2;
									if (0x75AC6061U == num)
									{
										goto IL_00;
									}
									num -= 0x16790A8BU;
									Dictionary<uint, GClass18.Delegate2> dictionary9 = this.dictionary_0;
									num ^= 0xC93509AU;
									uint key8 = num + 0xB9DA0271U;
									num = 0x3EFB2738U / num;
									IntPtr intptr_4 = ldftn(method_50);
									num = 0x418C000CU - num;
									GClass18.Delegate2 value3 = new GClass18.Delegate2(this, intptr_4);
									num |= 0x753579CEU;
									dictionary9[key8] = value3;
									Dictionary<uint, GClass18.Delegate2> dictionary10 = this.dictionary_0;
									uint key9 = num ^ 0x75BD79C7U;
									IntPtr intptr_5 = ldftn(method_93);
									num *= 0x26E3BBFU;
									dictionary10[key9] = new GClass18.Delegate2(this, intptr_5);
									if ((num ^ 0x71914030U) == 0U)
									{
										goto IL_12A5;
									}
									num = 0x122F4206U + num;
									Dictionary<uint, GClass18.Delegate2> dictionary11 = this.dictionary_0;
									num = 0x36ED6E89U >> (int)num;
									uint key10 = num + 0xFFFFFFD4U;
									num -= 0x6DC431A8U;
									IntPtr intptr_6 = ldftn(method_89);
									num -= 0x7C744A10U;
									GClass18.Delegate2 value4 = new GClass18.Delegate2(this, intptr_6);
									num = 0x72531734U >> (int)num;
									dictionary11[key10] = value4;
									num = 0x6C71505DU >> (int)num;
									if (num - 0x5EC1E54U == 0U)
									{
										goto IL_12A5;
									}
									Dictionary<uint, GClass18.Delegate2> dictionary12 = this.dictionary_0;
									uint key11 = num - 0x3638A823U;
									num = 0x78927818U % num;
									GClass18.Delegate2 value5 = new GClass18.Delegate2(this.method_84);
									num &= 0x5C8B47ADU;
									dictionary12[key11] = value5;
									num /= 0x1E590B22U;
									Dictionary<uint, GClass18.Delegate2> dictionary13 = this.dictionary_0;
									uint key12 = num ^ 0xCU;
									IntPtr intptr_7 = ldftn(method_80);
									num = 0x542E62F3U * num;
									dictionary13[key12] = new GClass18.Delegate2(this, intptr_7);
									num |= 0x15F439B2U;
									if (0x6CCD2829U <= num)
									{
										goto IL_00;
									}
									Dictionary<uint, GClass18.Delegate2> dictionary14 = this.dictionary_0;
									num = 0x6811718CU << (int)num;
									dictionary14[num - 0xC62FFFF3U] = new GClass18.Delegate2(this.method_59);
									num |= 0x4CDA454EU;
									if (0x46004905U > num)
									{
										goto IL_00;
									}
									Dictionary<uint, GClass18.Delegate2> dictionary15 = this.dictionary_0;
									num = (0x55362E57U ^ num);
									uint key13 = num ^ 0x9BCC6B17U;
									num >>= 5;
									dictionary15[key13] = new GClass18.Delegate2(this.method_35);
									num ^= 0x14920C38U;
									if (0x6A14564DU < num)
									{
										goto IL_12A5;
									}
									Dictionary<uint, GClass18.Delegate2> dictionary16 = this.dictionary_0;
									num = 0x29022999U << (int)num;
									uint key14 = num + 0xD6FDD676U;
									num = 0xA591EAFU / num;
									GClass18.Delegate2 value6 = new GClass18.Delegate2(this.method_97);
									num *= 0x1C325787U;
									dictionary16[key14] = value6;
									num /= 0xE745D1CU;
									Dictionary<uint, GClass18.Delegate2> dictionary17 = this.dictionary_0;
									uint key15 = num - 0xFFFFFFF0U;
									num += 0xD07350FU;
									num = 0x5F9C557FU + num;
									GClass18.Delegate2 value7 = new GClass18.Delegate2(this.method_53);
									num = 0xCF358E8U >> (int)num;
									dictionary17[key15] = value7;
									num |= 0x3E186349U;
									if (num * 0x1BF329FDU == 0U)
									{
										goto IL_B0D;
									}
									num = (0x120C17B3U & num);
									Dictionary<uint, GClass18.Delegate2> dictionary18 = this.dictionary_0;
									uint key16 = num - 0x12081370U;
									num &= 0x2AD93E09U;
									num = 0x1B296668U / num;
									GClass18.Delegate2 value8 = new GClass18.Delegate2(this.method_54);
									num /= 0x746A58U;
									dictionary18[key16] = value8;
									num -= 0x202F5681U;
									if (0x3B662294U >= num)
									{
										goto IL_12A5;
									}
									num >>= 0x10;
									Dictionary<uint, GClass18.Delegate2> dictionary19 = this.dictionary_0;
									num = 0x68A7A09U % num;
									uint key17 = num + 0xFFFFBEF9U;
									num = 0x77091532U - num;
									IntPtr intptr_8 = ldftn(method_83);
									num = 0x7C8279D3U - num;
									dictionary19[key17] = new GClass18.Delegate2(this, intptr_8);
									num = 0xA4D14E5U << (int)num;
									Dictionary<uint, GClass18.Delegate2> dictionary20 = this.dictionary_0;
									uint key18 = num ^ 0x94000013U;
									num = (0x1A20083EU | num);
									IntPtr intptr_9 = ldftn(method_65);
									num = 0x27A332B1U >> (int)num;
									dictionary20[key18] = new GClass18.Delegate2(this, intptr_9);
									num = 0x1C632BB5U * num;
									if (num >= 0x144D4790U)
									{
										goto IL_00;
									}
									this.dictionary_0[num + 0x14U] = new GClass18.Delegate2(this.method_44);
									num = 0x79E70DA6U + num;
									if (num == 0x3F1A6AE3U)
									{
										goto IL_AEA;
									}
									num += 0x1C95246DU;
									Dictionary<uint, GClass18.Delegate2> dictionary21 = this.dictionary_0;
									uint key19 = num - 0x967C31FEU;
									IntPtr intptr_10 = ldftn(method_55);
									num = 0x18D531A5U >> (int)num;
									dictionary21[key19] = new GClass18.Delegate2(this, intptr_10);
									num = (0x69D6285AU | num);
									num = 0x7BD76E7CU - num;
									Dictionary<uint, GClass18.Delegate2> dictionary22 = this.dictionary_0;
									num = (0x3CBF7CCBU ^ num);
									uint key20 = num ^ 0x2EBE3FFFU;
									num /= 0x24E23CCEU;
									num = (0x15D66C41U | num);
									GClass18.Delegate2 value9 = new GClass18.Delegate2(this.method_87);
									num = (0x58A32AF0U & num);
									dictionary22[key20] = value9;
									num += 0x386C5C17U;
									num = (0x77014B4EU | num);
									Dictionary<uint, GClass18.Delegate2> dictionary23 = this.dictionary_0;
									uint key21 = num ^ 0x7FEFCF48U;
									num = 0x3943722DU % num;
									num -= 0x250B0B68U;
									IntPtr intptr_11 = ldftn(method_62);
									num *= 0x40EE6595U;
									GClass18.Delegate2 value10 = new GClass18.Delegate2(this, intptr_11);
									num = 0xE576AF7U - num;
									dictionary23[key21] = value10;
									Dictionary<uint, GClass18.Delegate2> dictionary24 = this.dictionary_0;
									num += 0x65604E3BU;
									uint key22 = num + 0x5CCDD08FU;
									num *= 0x4D225EEAU;
									GClass18.Delegate2 value11 = new GClass18.Delegate2(this.method_82);
									num *= 0x7E13443AU;
									dictionary24[key22] = value11;
									if (num == 0xAA774AEU)
									{
										goto IL_B5F;
									}
									num |= 0x55F26ED0U;
									Dictionary<uint, GClass18.Delegate2> dictionary25 = this.dictionary_0;
									num = (0x1C3D11A7U ^ num);
									uint key23 = num + 0xB63D81C6U;
									num += 0x47997793U;
									num = 0x74565A1EU * num;
									IntPtr intptr_12 = ldftn(method_79);
									num >>= 9;
									dictionary25[key23] = new GClass18.Delegate2(this, intptr_12);
									Dictionary<uint, GClass18.Delegate2> dictionary26 = this.dictionary_0;
									num >>= 0xE;
									uint key24 = num ^ 0x7AU;
									num = 0x19B354A1U + num;
									num |= 0x3FC77B55U;
									IntPtr intptr_13 = ldftn(method_70);
									num <<= 3;
									GClass18.Delegate2 value12 = new GClass18.Delegate2(this, intptr_13);
									num = 0x58F40DCAU * num;
									dictionary26[key24] = value12;
									num >>= 0x1E;
									Dictionary<uint, GClass18.Delegate2> dictionary27 = this.dictionary_0;
									uint key25 = num ^ 0x18U;
									num <<= 6;
									num = 0x21937DE2U + num;
									dictionary27[key25] = new GClass18.Delegate2(this.method_49);
									num >>= 0x13;
									Dictionary<uint, GClass18.Delegate2> dictionary28 = this.dictionary_0;
									num &= 0x123143D6U;
									uint key26 = num ^ 0xEU;
									num += 0x3D216C09U;
									IntPtr intptr_14 = ldftn(method_66);
									num = (0x6000285AU ^ num);
									dictionary28[key26] = new GClass18.Delegate2(this, intptr_14);
									if (num == 0x70E16440U)
									{
										break;
									}
									Dictionary<uint, GClass18.Delegate2> dictionary29 = this.dictionary_0;
									uint key27 = num - 0x5D214424U;
									IntPtr intptr_15 = ldftn(method_48);
									num = 0x7B540F4FU / num;
									GClass18.Delegate2 value13 = new GClass18.Delegate2(this, intptr_15);
									num = 0x5EEB51EFU * num;
									dictionary29[key27] = value13;
									num += 0x16373FADU;
									Dictionary<uint, GClass18.Delegate2> dictionary30 = this.dictionary_0;
									num &= 0x24C41A7FU;
									uint key28 = num - 0x24000FFEU;
									num /= 0x30B3D26U;
									num = 0x746C2405U % num;
									IntPtr intptr_16 = ldftn(method_74);
									num = 0x72A93851U % num;
									dictionary30[key28] = new GClass18.Delegate2(this, intptr_16);
									num = 0x7C046C3BU * num;
									if (0x6AF7103C << (int)num == 0)
									{
										goto IL_1287;
									}
									num = 0x1F9753ECU + num;
									Dictionary<uint, GClass18.Delegate2> dictionary31 = this.dictionary_0;
									uint key29 = num ^ 0x9B9BC038U;
									num = 0x7A601C37U >> (int)num;
									GClass18.Delegate2 value14 = new GClass18.Delegate2(this.method_71);
									num = (0x3502560EU ^ num);
									dictionary31[key29] = value14;
									if (num / 0x4F20604DU != 0U)
									{
										goto IL_00;
									}
									Dictionary<uint, GClass18.Delegate2> dictionary32 = this.dictionary_0;
									uint key30 = num - 0x35F69616U;
									num /= 0x1F144293U;
									dictionary32[key30] = new GClass18.Delegate2(this.method_96);
									Dictionary<uint, GClass18.Delegate2> dictionary33 = this.dictionary_0;
									num = (0x688E10F9U ^ num);
									dictionary33[num ^ 0x688E10D9U] = new GClass18.Delegate2(this.method_37);
									num ^= 0x14BD5129U;
									Dictionary<uint, GClass18.Delegate2> dictionary34 = this.dictionary_0;
									num = (0x79C872BAU ^ num);
									uint key31 = num ^ 0x5FB3349U;
									IntPtr intptr_17 = ldftn(method_40);
									num = 0x61EE38C9U * num;
									GClass18.Delegate2 value15 = new GClass18.Delegate2(this, intptr_17);
									num = 0x5702DAAU % num;
									dictionary34[key31] = value15;
									if (num == 0x7D6127B4U)
									{
										goto IL_12A5;
									}
									num *= 0x1E8460CCU;
									Dictionary<uint, GClass18.Delegate2> dictionary35 = this.dictionary_0;
									uint key32 = num ^ 0xDE2C235BU;
									num ^= 0x28042212U;
									GClass18.Delegate2 value16 = new GClass18.Delegate2(this.method_108);
									num = 0x51297654U >> (int)num;
									dictionary35[key32] = value16;
									Dictionary<uint, GClass18.Delegate2> dictionary36 = this.dictionary_0;
									uint key33 = num ^ 0x144A79U;
									GClass18.Delegate2 value17 = new GClass18.Delegate2(this.method_104);
									num = 0xB3F59E5U - num;
									dictionary36[key33] = value17;
									if (num == 0x72841390U)
									{
										goto IL_B5F;
									}
									num = 0x22477747U - num;
									Dictionary<uint, GClass18.Delegate2> dictionary37 = this.dictionary_0;
									num &= 0x31941CE1U;
									uint key34 = num ^ 0x11140484U;
									num = (0x24723BCCU & num);
									IntPtr intptr_18 = ldftn(method_72);
									num /= 0x54643F3DU;
									GClass18.Delegate2 value18 = new GClass18.Delegate2(this, intptr_18);
									num &= 0x231E2C3DU;
									dictionary37[key34] = value18;
									Dictionary<uint, GClass18.Delegate2> dictionary38 = this.dictionary_0;
									num = 0xBBF1AE6U << (int)num;
									uint key35 = num + 0xF440E540U;
									GClass18.Delegate2 value19 = new GClass18.Delegate2(this.method_58);
									num <<= 1;
									dictionary38[key35] = value19;
									Dictionary<uint, GClass18.Delegate2> dictionary39 = this.dictionary_0;
									uint key36 = num ^ 0x177E35EBU;
									num ^= 0x13291F43U;
									GClass18.Delegate2 value20 = new GClass18.Delegate2(this.method_43);
									num = (0x7E0611A3U & num);
									dictionary39[key36] = value20;
									num &= 0x597037D3U;
									Dictionary<uint, GClass18.Delegate2> dictionary40 = this.dictionary_0;
									uint key37 = num ^ 0xABU;
									num = (0x1F0E38EAU | num);
									GClass18.Delegate2 value21 = new GClass18.Delegate2(this.method_75);
									num = 0x4E0830D6U - num;
									dictionary40[key37] = value21;
									num = 0x4210734U >> (int)num;
									if (num != 0x6FEA6EA3U)
									{
										goto Block_19;
									}
								}
							}
							IL_B0D:
							num = 0x28194A7BU + num;
							this.stack_1 = new Stack<GClass18.Class38>();
							num |= 0x26ED1BD6U;
							goto IL_B28;
							IL_AEA:
							num >>= 0xC;
							List<GClass18.Class38> list = new List<GClass18.Class38>();
							num += 0x7455795FU;
							this.list_1 = list;
							num = 0x33130258U / num;
							goto IL_B0D;
						}
						Block_19:
						Dictionary<uint, GClass18.Delegate2> dictionary41 = this.dictionary_0;
						num ^= 0x9FB11ECU;
						uint key38 = num + 0xF6046A5DU;
						num ^= 0x3E247AABU;
						num = 0x3BF51243U >> (int)num;
						GClass18.Delegate2 value22 = new GClass18.Delegate2(this.method_78);
						num = 0x4CEC0291U * num;
						dictionary41[key38] = value22;
						num ^= 0x74273DB2U;
						Dictionary<uint, GClass18.Delegate2> dictionary42 = this.dictionary_0;
						uint key39 = num - 0xC8C8DBACU;
						num ^= 0x75A631B6U;
						num = (0x5D2B7494U & num);
						IntPtr intptr_19 = ldftn(method_98);
						num ^= 0x580C60E3U;
						dictionary42[key39] = new GClass18.Delegate2(this, intptr_19);
						num /= 0x4E296999U;
						Dictionary<uint, GClass18.Delegate2> dictionary43 = this.dictionary_0;
						num = (0x243D10DDU ^ num);
						uint key40 = num - 0x243D10B2U;
						num = 0x593045E6U * num;
						num |= 0x2452254AU;
						IntPtr intptr_20 = ldftn(method_39);
						num &= 0x1FB33350U;
						GClass18.Delegate2 value23 = new GClass18.Delegate2(this, intptr_20);
						num = 0x26AC4075U << (int)num;
						dictionary43[key40] = value23;
						num &= 0x44571DE8U;
						num = 0x3212220EU / num;
						Dictionary<uint, GClass18.Delegate2> dictionary44 = this.dictionary_0;
						num = 0x66017CFFU - num;
						uint key41 = num ^ 0x66017CDFU;
						IntPtr intptr_21 = ldftn(method_107);
						num <<= 0xF;
						GClass18.Delegate2 value24 = new GClass18.Delegate2(this, intptr_21);
						num -= 0x34150352U;
						dictionary44[key41] = value24;
						Dictionary<uint, GClass18.Delegate2> dictionary45 = this.dictionary_0;
						num = (0x65880F53U ^ num);
						dictionary45[num - 0xEFEC73D0U] = new GClass18.Delegate2(this.method_92);
						if (0x7C60506CU % num == 0U)
						{
							break;
						}
						Dictionary<uint, GClass18.Delegate2> dictionary46 = this.dictionary_0;
						uint key42 = num + 0x10138C31U;
						num = (0x4926233AU | num);
						IntPtr intptr_22 = ldftn(method_73);
						num = 0x35DD0BD2U >> (int)num;
						GClass18.Delegate2 value25 = new GClass18.Delegate2(this, intptr_22);
						num -= 0x79271FA4U;
						dictionary46[key42] = value25;
						num = (0x38671BAFU ^ num);
						Dictionary<uint, GClass18.Delegate2> dictionary47 = this.dictionary_0;
						num -= 0x1FB3378DU;
						uint key43 = num ^ 0x9F0CC449U;
						num = (0x5F52F48U | num);
						IntPtr intptr_23 = ldftn(method_51);
						num -= 0x460E2ADEU;
						GClass18.Delegate2 value26 = new GClass18.Delegate2(this, intptr_23);
						num >>= 4;
						dictionary47[key43] = value26;
						if (num > 0x147720C9U)
						{
							goto IL_00;
						}
						num %= 0x18AB6112U;
						Dictionary<uint, GClass18.Delegate2> dictionary48 = this.dictionary_0;
						uint key44 = num - 0x59EFC19U;
						num = (0x17984762U & num);
						num = 0x25851526U - num;
						IntPtr intptr_24 = ldftn(method_110);
						num = (0x1247077EU ^ num);
						GClass18.Delegate2 value27 = new GClass18.Delegate2(this, intptr_24);
						num &= 0x66D4540U;
						dictionary48[key44] = value27;
						num = 0x578C33A7U + num;
						Dictionary<uint, GClass18.Delegate2> dictionary49 = this.dictionary_0;
						num = 0x3276219CU + num;
						uint key45 = num - 0x8E2B9A12U;
						num >>= 0xD;
						IntPtr intptr_25 = ldftn(method_67);
						num += 0x25070BF8U;
						GClass18.Delegate2 value28 = new GClass18.Delegate2(this, intptr_25);
						num = 0x53115780U << (int)num;
						dictionary49[key45] = value28;
						num >>= 0x17;
						Dictionary<uint, GClass18.Delegate2> dictionary50 = this.dictionary_0;
						num = (0x51CC729DU | num);
						uint key46 = num ^ 0x51CC72CFU;
						num = 0x138C105DU - num;
						IntPtr intptr_26 = ldftn(method_86);
						num = 0x1D1E7B33U >> (int)num;
						dictionary50[key46] = new GClass18.Delegate2(this, intptr_26);
						num = 0x99D1FD1U * num;
						if (0x33EE670AU >= num)
						{
							goto IL_00;
						}
						num = 0x5A3D6A96U / num;
						Dictionary<uint, GClass18.Delegate2> dictionary51 = this.dictionary_0;
						num <<= 2;
						uint key47 = num ^ 0x33U;
						num <<= 0x12;
						dictionary51[key47] = new GClass18.Delegate2(this.method_41);
						if (0x437C6D71U < num)
						{
							goto IL_00;
						}
						num = 0x6DAF6425U + num;
						Dictionary<uint, GClass18.Delegate2> dictionary52 = this.dictionary_0;
						num ^= 0x7E4841A2U;
						uint key48 = num ^ 0x13E725B3U;
						IntPtr intptr_27 = ldftn(method_103);
						num = 0x693A384DU - num;
						dictionary52[key48] = new GClass18.Delegate2(this, intptr_27);
						num = 0x675814E6U << (int)num;
						num = 0x130F2D37U << (int)num;
						this.dictionary_0[num + 0xECF0D2FEU] = new GClass18.Delegate2(this.method_76);
						num = (0x1EEF131CU | num);
						if (0x4FD10DDFU % num == 0U)
						{
							goto IL_00;
						}
						Dictionary<uint, GClass18.Delegate2> dictionary53 = this.dictionary_0;
						uint key49 = num ^ 0x1FEF3F09U;
						num = 0x6EE54D8FU - num;
						IntPtr intptr_28 = ldftn(method_57);
						num <<= 0xE;
						GClass18.Delegate2 value29 = new GClass18.Delegate2(this, intptr_28);
						num *= 0x2AE8796BU;
						dictionary53[key49] = value29;
						num = 0x39313D93U * num;
						if (num << 4 == 0U)
						{
							goto IL_00;
						}
						Dictionary<uint, GClass18.Delegate2> dictionary54 = this.dictionary_0;
						uint key50 = num ^ 0xE0540037U;
						num >>= 0x18;
						GClass18.Delegate2 value30 = new GClass18.Delegate2(this.method_95);
						num = 0x7DF96036U - num;
						dictionary54[key50] = value30;
						num ^= 0x326D4EBFU;
						Dictionary<uint, GClass18.Delegate2> dictionary55 = this.dictionary_0;
						uint key51 = num - 0x4F9411B1U;
						num *= 0xA1B07A4U;
						IntPtr intptr_29 = ldftn(method_60);
						num -= 0x56741219U;
						GClass18.Delegate2 value31 = new GClass18.Delegate2(this, intptr_29);
						num /= 0x616178U;
						dictionary55[key51] = value31;
						num ^= 0x60E27540U;
						num |= 0x64FB20E3U;
						Dictionary<uint, GClass18.Delegate2> dictionary56 = this.dictionary_0;
						uint key52 = num ^ 0x64FB74D2U;
						num &= 0x4A466C06U;
						IntPtr intptr_30 = ldftn(method_36);
						num = 0x5E6D6BC5U * num;
						dictionary56[key52] = new GClass18.Delegate2(this, intptr_30);
						if (0x4FA67C22U == num)
						{
							goto IL_00;
						}
						num %= 0x7CF5208BU;
						Dictionary<uint, GClass18.Delegate2> dictionary57 = this.dictionary_0;
						uint key53 = num - 0x6C8AAC5U;
						num = (0x7B7B7EE6U ^ num);
						GClass18.Delegate2 value32 = new GClass18.Delegate2(this.method_88);
						num /= 0x2E841641U;
						dictionary57[key53] = value32;
						Dictionary<uint, GClass18.Delegate2> dictionary58 = this.dictionary_0;
						uint key54 = num - 0xFFFFFFC7U;
						num >>= 0xD;
						num = 0x4843627AU + num;
						GClass18.Delegate2 value33 = new GClass18.Delegate2(this.method_100);
						num ^= 0x7A176F0EU;
						dictionary58[key54] = value33;
						num >>= 1;
						Dictionary<uint, GClass18.Delegate2> dictionary59 = this.dictionary_0;
						uint key55 = num - 0x192A067EU;
						num >>= 0x1B;
						IntPtr intptr_31 = ldftn(method_68);
						num = 0x73645EF2U >> (int)num;
						dictionary59[key55] = new GClass18.Delegate2(this, intptr_31);
						if (0x115E5CB8U * num == 0U)
						{
							break;
						}
						num = (0x3DAE6BFFU & num);
						Dictionary<uint, GClass18.Delegate2> dictionary60 = this.dictionary_0;
						num <<= 0x1F;
						uint key56 = num ^ 0x3DU;
						num = 0x78E7739EU + num;
						IntPtr intptr_32 = ldftn(method_99);
						num /= 0x239C3A28U;
						dictionary60[key56] = new GClass18.Delegate2(this, intptr_32);
						Dictionary<uint, GClass18.Delegate2> dictionary61 = this.dictionary_0;
						num -= 0x4D7B27B5U;
						uint key57 = num - 0xB284D810U;
						num = (0xCC55217U & num);
						num |= 0x423B5F88U;
						GClass18.Delegate2 value34 = new GClass18.Delegate2(this.method_38);
						num |= 0x2BA37D52U;
						dictionary61[key57] = value34;
						num += 0x274928E5U;
						num *= 0x275D780FU;
						Dictionary<uint, GClass18.Delegate2> dictionary62 = this.dictionary_0;
						uint key58 = num - 0xB0744B2EU;
						num >>= 0xA;
						num = 0x6CDD3F2DU >> (int)num;
						IntPtr intptr_33 = ldftn(method_105);
						num |= 0x5EF67B52U;
						GClass18.Delegate2 value35 = new GClass18.Delegate2(this, intptr_33);
						num = (0x4D045D88U & num);
						dictionary62[key58] = value35;
						num |= 0x760E1625U;
						Dictionary<uint, GClass18.Delegate2> dictionary63 = this.dictionary_0;
						uint key59 = num ^ 0x7E0E5F65U;
						num >>= 1;
						num <<= 0;
						GClass18.Delegate2 value36 = new GClass18.Delegate2(this.method_106);
						num = 0x70892CA7U + num;
						dictionary63[key59] = value36;
						if (0x18D102EF << (int)num == 0)
						{
							break;
						}
						num = 0x36ED4A1BU >> (int)num;
						Dictionary<uint, GClass18.Delegate2> dictionary64 = this.dictionary_0;
						uint key60 = num + 0x26U;
						num = 0x14CF4347U * num;
						num >>= 0x14;
						IntPtr intptr_34 = ldftn(method_46);
						num |= 0x20766BE6U;
						GClass18.Delegate2 value37 = new GClass18.Delegate2(this, intptr_34);
						num = (0x38867541U & num);
						dictionary64[key60] = value37;
						num /= 0x33139D3U;
						Dictionary<uint, GClass18.Delegate2> dictionary65 = this.dictionary_0;
						num &= 0x98265D1U;
						uint key61 = num + 0x42U;
						num -= 0xE3150B7U;
						num = (0xA5735BFU ^ num);
						IntPtr intptr_35 = ldftn(method_56);
						num -= 0x386F1BF4U;
						GClass18.Delegate2 value38 = new GClass18.Delegate2(this, intptr_35);
						num <<= 0x19;
						dictionary65[key61] = value38;
						num %= 0x3A566642U;
						if (0x3D033F34U != num)
						{
							goto Block_32;
						}
					}
				}
			}
		}
		Block_32:
		num <<= 0x1A;
		Dictionary<uint, GClass18.Delegate2> dictionary66 = this.dictionary_0;
		num = (0x27512E78U & num);
		uint key62 = num - 0xFFFFFFBDU;
		num = 0x76193536U + num;
		num = 0x692323AEU - num;
		IntPtr intptr_36 = ldftn(method_102);
		num &= 0x600D118DU;
		GClass18.Delegate2 value39 = new GClass18.Delegate2(this, intptr_36);
		num = 0x72557ED5U << (int)num;
		dictionary66[key62] = value39;
		num += 0x21E03C5AU;
		Dictionary<uint, GClass18.Delegate2> dictionary67 = this.dictionary_0;
		num = 0x53C27560U + num;
		uint key63 = num - 0xCB218676U;
		num = 0x70303463U - num;
		num = 0x1E403791U >> (int)num;
		IntPtr intptr_37 = ldftn(method_85);
		num <<= 0x1E;
		dictionary67[key63] = new GClass18.Delegate2(this, intptr_37);
		num /= 0x3AB6675AU;
		Dictionary<uint, GClass18.Delegate2> dictionary68 = this.dictionary_0;
		num = (0x5C8C13D2U & num);
		uint key64 = num - 0xFFFFFFBDU;
		IntPtr intptr_38 = ldftn(method_90);
		num |= 0x76CD72F3U;
		dictionary68[key64] = new GClass18.Delegate2(this, intptr_38);
		this.dictionary_0[0x46U] = new GClass18.Delegate2(this.method_91);
		this.dictionary_0[0x47U] = new GClass18.Delegate2(this.method_94);
		this.dictionary_0[0x48U] = new GClass18.Delegate2(this.method_77);
		this.dictionary_0[0x49U] = new GClass18.Delegate2(this.method_101);
		this.dictionary_0[0x4AU] = new GClass18.Delegate2(this.method_64);
		this.dictionary_0[0x4BU] = new GClass18.Delegate2(this.method_9);
		this.dictionary_0[0x4CU] = new GClass18.Delegate2(this.method_63);
		this.dictionary_0[0x4DU] = new GClass18.Delegate2(this.method_55);
		this.dictionary_0[0x4EU] = new GClass18.Delegate2(this.method_76);
		this.dictionary_0[0x4FU] = new GClass18.Delegate2(this.method_66);
		this.dictionary_0[0x50U] = new GClass18.Delegate2(this.method_58);
		this.dictionary_0[0x51U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x52U] = new GClass18.Delegate2(this.method_56);
		this.dictionary_0[0x53U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0x54U] = new GClass18.Delegate2(this.method_102);
		this.dictionary_0[0x55U] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0x56U] = new GClass18.Delegate2(this.method_36);
		this.dictionary_0[0x57U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x58U] = new GClass18.Delegate2(this.method_94);
		this.dictionary_0[0x59U] = new GClass18.Delegate2(this.method_39);
		this.dictionary_0[0x5AU] = new GClass18.Delegate2(this.method_67);
		this.dictionary_0[0x5BU] = new GClass18.Delegate2(this.method_48);
		this.dictionary_0[0x5CU] = new GClass18.Delegate2(this.method_109);
		this.dictionary_0[0x5DU] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x5EU] = new GClass18.Delegate2(this.method_48);
		this.dictionary_0[0x5FU] = new GClass18.Delegate2(this.method_54);
		this.dictionary_0[0x60U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x61U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x62U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x63U] = new GClass18.Delegate2(this.method_83);
		this.dictionary_0[0x64U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x65U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0x66U] = new GClass18.Delegate2(this.method_83);
		this.dictionary_0[0x67U] = new GClass18.Delegate2(this.method_45);
		this.dictionary_0[0x68U] = new GClass18.Delegate2(this.method_98);
		this.dictionary_0[0x69U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x6AU] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x6BU] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x6CU] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0x6DU] = new GClass18.Delegate2(this.method_64);
		this.dictionary_0[0x6EU] = new GClass18.Delegate2(this.method_73);
		this.dictionary_0[0x6FU] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x70U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x71U] = new GClass18.Delegate2(this.method_75);
		this.dictionary_0[0x72U] = new GClass18.Delegate2(this.method_45);
		this.dictionary_0[0x73U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x74U] = new GClass18.Delegate2(this.method_39);
		this.dictionary_0[0x75U] = new GClass18.Delegate2(this.method_52);
		this.dictionary_0[0x76U] = new GClass18.Delegate2(this.method_38);
		this.dictionary_0[0x77U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x78U] = new GClass18.Delegate2(this.method_38);
		this.dictionary_0[0x79U] = new GClass18.Delegate2(this.method_45);
		this.dictionary_0[0x7AU] = new GClass18.Delegate2(this.method_42);
		this.dictionary_0[0x7BU] = new GClass18.Delegate2(this.method_98);
		this.dictionary_0[0x7CU] = new GClass18.Delegate2(this.method_99);
		this.dictionary_0[0x7DU] = new GClass18.Delegate2(this.method_62);
		this.dictionary_0[0x7EU] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0x7FU] = new GClass18.Delegate2(this.method_83);
		this.dictionary_0[0x80U] = new GClass18.Delegate2(this.method_55);
		this.dictionary_0[0x81U] = new GClass18.Delegate2(this.method_99);
		this.dictionary_0[0x82U] = new GClass18.Delegate2(this.method_41);
		this.dictionary_0[0x83U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x84U] = new GClass18.Delegate2(this.method_71);
		this.dictionary_0[0x85U] = new GClass18.Delegate2(this.method_52);
		this.dictionary_0[0x86U] = new GClass18.Delegate2(this.method_99);
		this.dictionary_0[0x87U] = new GClass18.Delegate2(this.method_94);
		this.dictionary_0[0x88U] = new GClass18.Delegate2(this.method_66);
		this.dictionary_0[0x89U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0x8AU] = new GClass18.Delegate2(this.method_66);
		this.dictionary_0[0x8BU] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x8CU] = new GClass18.Delegate2(this.method_73);
		this.dictionary_0[0x8DU] = new GClass18.Delegate2(this.method_41);
		this.dictionary_0[0x8EU] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0x8FU] = new GClass18.Delegate2(this.method_74);
		this.dictionary_0[0x90U] = new GClass18.Delegate2(this.method_98);
		this.dictionary_0[0x91U] = new GClass18.Delegate2(this.method_49);
		this.dictionary_0[0x92U] = new GClass18.Delegate2(this.method_73);
		this.dictionary_0[0x93U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0x94U] = new GClass18.Delegate2(this.method_50);
		this.dictionary_0[0x95U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0x96U] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0x97U] = new GClass18.Delegate2(this.method_83);
		this.dictionary_0[0x98U] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0x99U] = new GClass18.Delegate2(this.method_64);
		this.dictionary_0[0x9AU] = new GClass18.Delegate2(this.method_73);
		this.dictionary_0[0x9BU] = new GClass18.Delegate2(this.method_36);
		this.dictionary_0[0x9CU] = new GClass18.Delegate2(this.method_67);
		this.dictionary_0[0x9DU] = new GClass18.Delegate2(this.method_88);
		this.dictionary_0[0x9EU] = new GClass18.Delegate2(this.method_52);
		this.dictionary_0[0x9FU] = new GClass18.Delegate2(this.method_105);
		this.dictionary_0[0xA0U] = new GClass18.Delegate2(this.method_93);
		this.dictionary_0[0xA1U] = new GClass18.Delegate2(this.method_48);
		this.dictionary_0[0xA2U] = new GClass18.Delegate2(this.method_55);
		this.dictionary_0[0xA3U] = new GClass18.Delegate2(this.method_36);
		this.dictionary_0[0xA4U] = new GClass18.Delegate2(this.method_66);
		this.dictionary_0[0xA5U] = new GClass18.Delegate2(this.method_47);
		this.dictionary_0[0xA6U] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0xA7U] = new GClass18.Delegate2(this.method_56);
		this.dictionary_0[0xA8U] = new GClass18.Delegate2(this.method_48);
		this.dictionary_0[0xA9U] = new GClass18.Delegate2(this.method_47);
		this.dictionary_0[0xAAU] = new GClass18.Delegate2(this.method_42);
		this.dictionary_0[0xABU] = new GClass18.Delegate2(this.method_41);
		this.dictionary_0[0xACU] = new GClass18.Delegate2(this.method_76);
		this.dictionary_0[0xADU] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0xAEU] = new GClass18.Delegate2(this.method_101);
		this.dictionary_0[0xAFU] = new GClass18.Delegate2(this.method_79);
		this.dictionary_0[0xB0U] = new GClass18.Delegate2(this.method_45);
		this.dictionary_0[0xB1U] = new GClass18.Delegate2(this.method_41);
		this.dictionary_0[0xB2U] = new GClass18.Delegate2(this.method_60);
		this.dictionary_0[0xB3U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0xB4U] = new GClass18.Delegate2(this.method_98);
		this.dictionary_0[0xB5U] = new GClass18.Delegate2(this.method_73);
		this.dictionary_0[0xB6U] = new GClass18.Delegate2(this.method_45);
		this.dictionary_0[0xB7U] = new GClass18.Delegate2(this.method_44);
		this.dictionary_0[0xB8U] = new GClass18.Delegate2(this.method_103);
		this.dictionary_0[0xB9U] = new GClass18.Delegate2(this.method_41);
		this.dictionary_0[0xBAU] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0xBBU] = new GClass18.Delegate2(this.method_72);
		this.dictionary_0[0xBCU] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0xBDU] = new GClass18.Delegate2(this.method_49);
		this.dictionary_0[0xBEU] = new GClass18.Delegate2(this.method_49);
		this.dictionary_0[0xBFU] = new GClass18.Delegate2(this.method_79);
		this.dictionary_0[0xC0U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0xC1U] = new GClass18.Delegate2(this.method_64);
		this.dictionary_0[0xC2U] = new GClass18.Delegate2(this.method_104);
		this.dictionary_0[0xC3U] = new GClass18.Delegate2(this.method_79);
		this.dictionary_0[0xC4U] = new GClass18.Delegate2(this.method_52);
		this.dictionary_0[0xC5U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0xC6U] = new GClass18.Delegate2(this.method_58);
		this.dictionary_0[0xC7U] = new GClass18.Delegate2(this.method_36);
		this.dictionary_0[0xC8U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0xC9U] = new GClass18.Delegate2(this.method_57);
		this.dictionary_0[0xCAU] = new GClass18.Delegate2(this.method_49);
		this.dictionary_0[0xCBU] = new GClass18.Delegate2(this.method_83);
		this.dictionary_0[0xCCU] = new GClass18.Delegate2(this.method_44);
		this.dictionary_0[0xCDU] = new GClass18.Delegate2(this.method_74);
		this.dictionary_0[0xCEU] = new GClass18.Delegate2(this.method_108);
		this.dictionary_0[0xCFU] = new GClass18.Delegate2(this.method_69);
		this.dictionary_0[0xD0U] = new GClass18.Delegate2(this.method_93);
		this.dictionary_0[0xD1U] = new GClass18.Delegate2(this.method_45);
		this.dictionary_0[0xD2U] = new GClass18.Delegate2(this.method_41);
		this.dictionary_0[0xD3U] = new GClass18.Delegate2(this.method_86);
		this.dictionary_0[0xD4U] = new GClass18.Delegate2(this.method_50);
		this.dictionary_0[0xD5U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0xD6U] = new GClass18.Delegate2(this.method_94);
		this.dictionary_0[0xD7U] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0xD8U] = new GClass18.Delegate2(this.method_39);
		this.dictionary_0[0xD9U] = new GClass18.Delegate2(this.method_48);
		this.dictionary_0[0xDAU] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0xDBU] = new GClass18.Delegate2(this.method_41);
		this.dictionary_0[0xDCU] = new GClass18.Delegate2(this.method_53);
		this.dictionary_0[0xDDU] = new GClass18.Delegate2(this.method_45);
		this.dictionary_0[0xDEU] = new GClass18.Delegate2(this.method_58);
		this.dictionary_0[0xDFU] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0xE0U] = new GClass18.Delegate2(this.method_71);
		this.dictionary_0[0xE1U] = new GClass18.Delegate2(this.method_54);
		this.dictionary_0[0xE2U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0xE3U] = new GClass18.Delegate2(this.method_47);
		this.dictionary_0[0xE4U] = new GClass18.Delegate2(this.method_60);
		this.dictionary_0[0xE5U] = new GClass18.Delegate2(this.method_89);
		this.dictionary_0[0xE6U] = new GClass18.Delegate2(this.method_9);
		this.dictionary_0[0xE7U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0xE8U] = new GClass18.Delegate2(this.method_61);
		this.dictionary_0[0xE9U] = new GClass18.Delegate2(this.method_47);
		this.dictionary_0[0xEAU] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0xEBU] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0xECU] = new GClass18.Delegate2(this.method_72);
		this.dictionary_0[0xEDU] = new GClass18.Delegate2(this.method_92);
		this.dictionary_0[0xEEU] = new GClass18.Delegate2(this.method_96);
		this.dictionary_0[0xEFU] = new GClass18.Delegate2(this.method_95);
		this.dictionary_0[0xF0U] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0xF1U] = new GClass18.Delegate2(this.method_84);
		this.dictionary_0[0xF2U] = new GClass18.Delegate2(this.method_47);
		this.dictionary_0[0xF3U] = new GClass18.Delegate2(this.method_56);
		this.dictionary_0[0xF4U] = new GClass18.Delegate2(this.method_48);
		this.dictionary_0[0xF5U] = new GClass18.Delegate2(this.method_38);
		this.dictionary_0[0xF6U] = new GClass18.Delegate2(this.method_62);
		this.dictionary_0[0xF7U] = new GClass18.Delegate2(this.method_9);
		this.dictionary_0[0xF8U] = new GClass18.Delegate2(this.method_39);
		this.dictionary_0[0xF9U] = new GClass18.Delegate2(this.method_62);
		this.dictionary_0[0xFAU] = new GClass18.Delegate2(this.method_47);
		this.dictionary_0[0xFBU] = new GClass18.Delegate2(this.method_73);
		this.dictionary_0[0xFCU] = new GClass18.Delegate2(this.method_107);
		this.dictionary_0[0xFDU] = new GClass18.Delegate2(this.method_79);
		this.dictionary_0[0xFEU] = new GClass18.Delegate2(this.method_36);
		this.dictionary_0[0xFFU] = new GClass18.Delegate2(this.method_64);
	}

	// Token: 0x0600137B RID: 4987 RVA: 0x0000C386 File Offset: 0x0000A586
	private void method_0(GClass18.Class8 class8_0)
	{
		this.stack_0.Push(class8_0.vmethod_4());
	}

	// Token: 0x0600137C RID: 4988 RVA: 0x0000C399 File Offset: 0x0000A599
	private GClass18.Class8 method_1()
	{
		return this.stack_0.Pop();
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x0000C3A6 File Offset: 0x0000A5A6
	private GClass18.Class8 method_2()
	{
		return this.stack_0.Peek();
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x0000C3B3 File Offset: 0x0000A5B3
	private byte method_3()
	{
		byte result = Marshal.ReadByte(new IntPtr(this.long_0 + (long)this.int_0));
		this.int_0++;
		return result;
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x0000C3DB File Offset: 0x0000A5DB
	private short method_4()
	{
		short result = Marshal.ReadInt16(new IntPtr(this.long_0 + (long)this.int_0));
		this.int_0 += 2;
		return result;
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x0000C403 File Offset: 0x0000A603
	private int method_5()
	{
		int result = Marshal.ReadInt32(new IntPtr(this.long_0 + (long)this.int_0));
		this.int_0 += 4;
		return result;
	}

	// Token: 0x06001381 RID: 4993 RVA: 0x0000C42B File Offset: 0x0000A62B
	private long method_6()
	{
		long result = Marshal.ReadInt64(new IntPtr(this.long_0 + (long)this.int_0));
		this.int_0 += 8;
		return result;
	}

	// Token: 0x06001382 RID: 4994 RVA: 0x0000C453 File Offset: 0x0000A653
	private float method_7()
	{
		return BitConverter.ToSingle(BitConverter.GetBytes(this.method_5()), 0);
	}

	// Token: 0x06001383 RID: 4995 RVA: 0x0000C466 File Offset: 0x0000A666
	private double method_8()
	{
		return BitConverter.ToDouble(BitConverter.GetBytes(this.method_6()), 0);
	}

	// Token: 0x06001384 RID: 4996 RVA: 0x00091170 File Offset: 0x0008F370
	private void method_9()
	{
		uint num = 0x77691E98U;
		byte b2;
		int num5;
		int int_;
		GClass18.Class38 class2;
		for (;;)
		{
			IL_32E:
			byte b = this.method_3();
			num *= 0x19FE5E7EU;
			b2 = b;
			for (;;)
			{
				num &= 0x1A15016U;
				int num2 = this.method_5();
				if (0x7B6811A8 << (int)num != 0)
				{
					for (;;)
					{
						int num3 = this.method_5();
						num = 0x53D13A40U << (int)num;
						int num4 = this.method_5();
						num ^= 0x77DD66D3U;
						num5 = num4;
						num = 0x1D1F5A0FU + num;
						if (0x420708E1U <= num)
						{
							int num6 = this.method_5();
							num = 0x13A659BEU * num;
							int_ = num6;
							num += 0x210F69D2U;
							GClass18.Class38 @class = null;
							num = (0x6A01760U & num);
							class2 = @class;
							int num7 = (int)(num + 0xFF7FFD00U);
							GClass18.Class38 class3;
							for (;;)
							{
								int num8 = num7;
								List<GClass18.Class38> list = this.list_1;
								num = 0x3F5C15D0U % num;
								int count = list.Count;
								num |= 0xF2B40EEU;
								if (num8 >= count)
								{
									goto Block_3;
								}
								class3 = this.list_1[num7];
								GClass18.Class38 class4 = class3;
								num = 1U;
								if (class4.method_0() == num2)
								{
									num &= 0x36C0189CU;
									GClass18.Class38 class5 = class3;
									num = 0x17244E28U << (int)num;
									int num9 = class5.method_1();
									int num10 = num3;
									num += 0xE8DBB1D9U;
									if (num9 == num10)
									{
										goto Block_2;
									}
								}
								num %= 0x2CA9016BU;
								int num11 = num7;
								num -= 0x61125A6CU;
								int num12 = (int)(num ^ 0x9EEDA594U);
								num = (0x29140AF8U | num);
								num7 = num11 + num12;
								num += 0x40825303U;
							}
							IL_107:
							if (num == 0x144C2983U)
							{
								continue;
							}
							if (class2 != null)
							{
								goto IL_363;
							}
							num = 0x511F0A2CU - num;
							bool flag = num + 0xAEE0F5D5U != 0U;
							num ^= 0x3FE953C6U;
							bool flag2 = flag;
							int int_2 = num2;
							num /= 0x127A523FU;
							GClass18.Class38 class6 = new GClass18.Class38(int_2, num3);
							num |= 0x29DD51CDU;
							class2 = class6;
							num -= 0x6F337361U;
							int num13 = (int)(num ^ 0xBAA9DE6EU);
							num ^= 0x66E378DAU;
							int num14 = num13;
							if (0x66311C6U < num)
							{
								for (;;)
								{
									num |= 0x40625CEDU;
									int num15 = num14;
									List<GClass18.Class38> list2 = this.list_1;
									num -= 0x57345DFEU;
									if (num15 >= list2.Count)
									{
										goto Block_8;
									}
									GClass18.Class38 class38_ = this.list_1[num14];
									int num16 = class2.method_2(class38_);
									int num17 = 0;
									num = 0x1A2E9328U;
									if (num16 < num17)
									{
										break;
									}
									num = 0x464C5751U - num;
									int num18 = num14;
									num = (0x6C5438E1U ^ num);
									int num19 = (int)(num + 0xBFB60339U);
									num = (0xDA47D8BU | num);
									int num20 = num18 + num19;
									num |= 0xCAE6A7BU;
									num14 = num20;
									num += 0x8E5AA6B9U;
								}
								num = 0x72180FC6U << (int)num;
								if (num * 0x644C2A11U == 0U)
								{
									break;
								}
								List<GClass18.Class38> list3 = this.list_1;
								num = (0x73443834U ^ num);
								list3.Insert(num14, class2);
								num /= 0x242E6495U;
								flag2 = (num - 1U != 0U);
								if (num + 0x2E052474U == 0U)
								{
									continue;
								}
								IL_28D:
								num *= 0x3EFC5871U;
								if (num % 0x2F937A04U == 0U)
								{
									goto IL_32E;
								}
								bool flag3 = flag2;
								num ^= 0x7DF8B0E3U;
								if (flag3)
								{
									goto IL_363;
								}
								num ^= 0x466D41C5U;
								if (0x4DE87C6DU != num)
								{
									goto Block_12;
								}
								continue;
								Block_8:
								num += 0x7AC95F03U;
								goto IL_28D;
							}
							goto IL_32E;
							Block_2:
							class2 = class3;
							goto IL_107;
							Block_3:
							num += 0xF0842403U;
							goto IL_107;
						}
						goto IL_32E;
					}
				}
			}
		}
		Block_12:
		List<GClass18.Class38> list4 = this.list_1;
		GClass18.Class38 item = class2;
		num ^= 0x25B503A0U;
		list4.Add(item);
		num += 0x9C27BD9DU;
		IL_363:
		num = 0x38A5624CU * num;
		GClass18.Class38 class7 = class2;
		num = (0x2B661A3DU ^ num);
		byte byte_ = b2;
		int int_3 = num5;
		num = (0x5D345B7BU ^ num);
		class7.method_3(byte_, int_3, int_);
	}

	// Token: 0x06001385 RID: 4997 RVA: 0x0009150C File Offset: 0x0008F70C
	private TypeCode method_10(GClass18.Class8 class8_0, GClass18.Class8 class8_1)
	{
		uint num;
		TypeCode typeCode2;
		TypeCode typeCode3;
		for (;;)
		{
			IL_00:
			TypeCode typeCode = class8_0.vmethod_7();
			num = 0x26CE8FA0U;
			typeCode2 = typeCode;
			for (;;)
			{
				IL_180:
				typeCode3 = class8_1.vmethod_7();
				num = 0x68C6269BU - num;
				if (0x3B847F00U < num)
				{
					while (typeCode2 != TypeCode.Empty)
					{
						do
						{
							TypeCode typeCode4 = typeCode2;
							uint num2 = num ^ 0x41F796FAU;
							num += 0U;
							if (typeCode4 == num2)
							{
								goto IL_310;
							}
							if (num <= 0x1F2E5278U)
							{
								goto IL_00;
							}
							bool flag = typeCode3 != TypeCode.Empty;
							num ^= 0U;
							if (!flag)
							{
								goto IL_310;
							}
							if (num * 0x55786DB7U == 0U)
							{
								goto IL_00;
							}
							uint num3 = (uint)typeCode3;
							num = 0x1679614FU / num;
							if (num3 == num + 1U)
							{
								goto Block_3;
							}
							num = 0x597E16F4U + num;
						}
						while (0xDBA1A9DU >= num);
						TypeCode typeCode5 = typeCode2;
						num /= 0x60C042FAU;
						uint num4 = num ^ 0xAU;
						num = 0xCC32736U * num;
						if (typeCode5 == num4)
						{
							goto Block_5;
						}
						num = (0x135A79EEU ^ num);
						TypeCode typeCode6 = typeCode3;
						uint num5 = num + 0xECA5861CU;
						num = (0x7CD90260U & num);
						if (typeCode6 == num5)
						{
							goto Block_6;
						}
						num += 0x1F9324B1U;
						if (num <= 0x292C09C6U)
						{
							goto IL_00;
						}
						TypeCode typeCode7 = typeCode2;
						uint num6 = num ^ 0x2FEB251DU;
						num %= 0x17813CB1U;
						if (typeCode7 == num6)
						{
							uint num7 = (uint)typeCode3;
							num = (0xC422720U ^ num);
							if (num7 == num + 0xF355737AU)
							{
								return typeCode2;
							}
							if (num % 0x45813EE3U != 0U)
							{
								goto IL_1F0;
							}
						}
						else
						{
							TypeCode typeCode8 = typeCode3;
							num |= 0x6D8F53A4U;
							uint num8 = num ^ 0x6DEFFBA3U;
							num += 0x62390AA0U;
							if (typeCode8 != num8)
							{
								goto IL_22C;
							}
							num = 0x1E920E64U >> (int)num;
							if ((0x2365750AU & num) == 0U)
							{
								goto IL_00;
							}
							if (typeCode2 != (TypeCode)(num - 0x3D1BU))
							{
								num = (0x64A60F8EU | num);
								TypeCode typeCode9 = typeCode2;
								num = (0x6B897EC8U & num);
								uint num9 = num + 0x9F7FC183U;
								num += 0x9F7FFE9CU;
								if (typeCode9 != num9)
								{
									goto Block_14;
								}
							}
							num = (0x2AB14CD1U ^ num);
							if ((num ^ 0x24825C0CU) == 0U)
							{
								goto IL_180;
							}
							return typeCode2;
						}
					}
					goto IL_310;
				}
				goto IL_00;
			}
			Block_5:
			if (0x4BF05E71U - num != 0U)
			{
				goto Block_16;
			}
		}
		Block_3:
		num ^= 0x41F796FBU;
		goto IL_310;
		Block_6:
		if (typeCode2 != (int)num + (TypeCode)(-0x10580057))
		{
			return (TypeCode)(num ^ 0x10580060U);
		}
		return typeCode3;
		Block_14:
		num = 0x73536C86U << (int)num;
		return (TypeCode)(num ^ 0x3536C860U);
		Block_16:
		uint num10 = (uint)typeCode3;
		num = 0x7EF92410U >> (int)num;
		if (num10 != num + 0x8106DBF9U)
		{
			return (TypeCode)(num ^ 0x7EF92410U);
		}
		return typeCode2;
		IL_1F0:
		TypeCode typeCode10 = typeCode3;
		uint num11 = num ^ 0xCAA8C84U;
		num ^= 0U;
		if (typeCode10 != num11)
		{
			num %= 0x5D8F0A8BU;
			return (TypeCode)(num ^ 0xCAA8C8FU);
		}
		return typeCode2;
		IL_22C:
		TypeCode typeCode11 = typeCode2;
		num = 0x44DA130EU * num;
		uint num12 = num + 0x3703CABCU;
		num -= 0x54DC1E38U;
		if (typeCode11 != num12)
		{
			uint num13 = (uint)typeCode3;
			num >>= 0x14;
			if (num13 != num - 0x734U)
			{
				TypeCode typeCode12 = typeCode2;
				uint num14 = num ^ 0x74FU;
				num %= 0x6EE6C32U;
				if (typeCode12 != num14)
				{
					num = 0x320C4CF7U % num;
					if (typeCode3 != (TypeCode)(num ^ 0x594U))
					{
						TypeCode typeCode13 = typeCode2;
						uint num15 = num - 0x58EU;
						num += 0x5FA74871U;
						if (typeCode13 != num15)
						{
							TypeCode typeCode14 = typeCode3;
							num = 0x1F8B3EBDU << (int)num;
							uint num16 = num ^ 0x2CFAF40BU;
							num = 0xA3E0DC6U >> (int)num;
							if (typeCode14 != num16)
							{
								return (TypeCode)(num ^ 0xA3E0DCFU);
							}
							num += 0x55694044U;
						}
						num ^= 0x3C9956F9U;
						return (TypeCode)(num ^ 0x633E18F8U);
					}
					num += 0x1A9U;
				}
				num = 0x710C0429U + num;
				return (TypeCode)(num - 0x710C0B5EU);
			}
			num ^= 0x74201058U;
		}
		num -= 0x8FA3940U;
		return (TypeCode)(num ^ 0x6B25DDD4U);
		IL_310:
		return (int)num + (TypeCode)(-0x41F796FB);
	}

	// Token: 0x06001386 RID: 4998 RVA: 0x00091830 File Offset: 0x0008FA30
	private unsafe GClass18.Class8 method_11(GClass18.Class8 class8_0, GClass18.Class8 class8_1, bool bool_0, bool bool_1)
	{
		uint num;
		TypeCode typeCode2;
		int value;
		long long_;
		float num19;
		double num20;
		double num22;
		int int_;
		GClass18.Class16 class5;
		IntPtr intPtr2;
		float num53;
		for (;;)
		{
			IL_00:
			TypeCode typeCode = this.method_10(class8_0, class8_1);
			num = 0x7A39A37CU;
			typeCode2 = typeCode;
			int num25;
			int num26;
			for (;;)
			{
				TypeCode typeCode3 = typeCode2;
				uint num2 = num + 0x85C65C8DU;
				num = 0x565F1AC5U - num;
				switch (typeCode3 - num2)
				{
				case 0:
					goto IL_293;
				case 1:
				{
					if (num <= 0x39786B2BU)
					{
						goto IL_293;
					}
					num |= 0x6BD62715U;
					if (!bool_1)
					{
						goto IL_47D;
					}
					num = 0x15EC4F03U / num;
					num *= 0x79EE57EEU;
					uint num3 = class8_0.vmethod_13();
					num = 0x71836354U * num;
					uint num4 = class8_1.vmethod_13();
					num -= 0x4C885066U;
					uint num5 = num4;
					num = 0x2D5D7560U % num;
					int num8;
					if (!bool_0)
					{
						if (0x3CBA38E7U % num == 0U)
						{
							continue;
						}
						int num6 = (int)num3;
						num /= 0x19734F22U;
						int num7 = (int)num5;
						num |= 0x36606D91U;
						num8 = num6 + num7;
					}
					else
					{
						num = (0x6A05491FU & num);
						if (num > 0x48E70CBFU)
						{
							goto IL_00;
						}
						int num9 = (int)num3;
						int num10 = (int)num5;
						num = 0x13467EC9U * num;
						num8 = checked(num9 + num10);
						num ^= 0xFE7E6491U;
					}
					value = num8;
					if (0x266D0D14U + num != 0U)
					{
						goto Block_33;
					}
					goto IL_293;
				}
				case 2:
				{
					if (0x3D535FE9U >= num)
					{
						goto IL_7E0;
					}
					if (!bool_1)
					{
						goto IL_575;
					}
					num -= 0x5AC04EC1U;
					num = 0x12E105FEU / num;
					ulong num11 = class8_0.vmethod_14();
					num = 0x49B11934U >> (int)num;
					ulong num12 = num11;
					num &= 0x1D76140DU;
					if (num > 0x5BDC0406U)
					{
						goto IL_00;
					}
					num &= 0x158B2635U;
					ulong num13 = class8_1.vmethod_14();
					num = 0x656F60E8U >> (int)num;
					num = 0x277D7193U % num;
					long num16;
					if (!bool_0)
					{
						if (num == 0x5752C40U)
						{
							goto IL_00;
						}
						long num14 = (long)num12;
						long num15 = (long)num13;
						num &= 0x40705DF6U;
						num16 = num14 + num15;
					}
					else
					{
						num16 = (long)(checked(num12 + num13));
						num ^= 0x103A009U;
					}
					long_ = num16;
					if (0x7068635EU <= num)
					{
						goto IL_293;
					}
					goto IL_8E6;
				}
				case 3:
				{
					num <<= 0;
					if (!bool_1)
					{
						goto IL_64C;
					}
					if (0x66640452U + num == 0U)
					{
						goto IL_7E0;
					}
					ulong num17 = class8_0.vmethod_14();
					num += 0x2D8C6317U;
					if ((0x783C7459U & num) == 0U)
					{
						goto IL_00;
					}
					ulong num18 = class8_1.vmethod_14();
					if (num <= 0x1D042213U)
					{
						goto Block_16;
					}
					continue;
				}
				case 4:
				{
					if (0x2F0B3CD1U / num != 0U)
					{
						continue;
					}
					num -= 0x1E854790U;
					GClass18.Class8 @class;
					if (!bool_1)
					{
						@class = class8_0;
					}
					else
					{
						if (0x4BBA7E4DU > num)
						{
							goto IL_7E0;
						}
						@class = class8_0.vmethod_5();
						num ^= 0U;
					}
					num19 = @class.C0EC1D52();
					if (0x7AFA13B3U > num)
					{
						goto IL_155;
					}
					goto IL_769;
				}
				case 5:
				{
					if (0x2191023AU >= num)
					{
						goto IL_00;
					}
					num += 0x608714B5U;
					GClass18.Class8 class2;
					if (!bool_1)
					{
						if (num + 0x640656A1U == 0U)
						{
							goto IL_00;
						}
						class2 = class8_0;
					}
					else
					{
						num = 0x85065F4U >> (int)num;
						class2 = class8_0.vmethod_5();
						num ^= 0x3CAC8BFEU;
					}
					num ^= 0x794A74A5U;
					num20 = class2.F979B236();
					if ((0x2F6B0ED0U & num) == 0U)
					{
						goto IL_00;
					}
					GClass18.Class8 class3;
					if (!bool_1)
					{
						num = (0x37A073F4U | num);
						if (0x5F2A4CDCU >= num)
						{
							goto IL_00;
						}
						class3 = class8_1;
					}
					else
					{
						num = 0x3BDB0AB9U + num;
						class3 = class8_1.vmethod_5();
						num += 0xF624F5EBU;
					}
					num &= 0x625A2E8FU;
					double num21 = class3.F979B236();
					num &= 0x15B2057CU;
					num22 = num21;
					num -= 0x2FF26805U;
					if (!bool_0)
					{
						num = (0x460F53E4U ^ num);
						if (0x4F7280EU <= num)
						{
							goto Block_7;
						}
						continue;
					}
					else
					{
						if (num + 0x57C79B6U != 0U)
						{
							goto Block_8;
						}
						continue;
					}
					break;
				}
				}
				break;
				IL_163:
				num = 0x368234E9U % num;
				int num23;
				int_ = num23;
				if (num != 0x32BA4A84U)
				{
					goto Block_12;
				}
				continue;
				IL_293:
				num <<= 5;
				uint num24;
				if (bool_1)
				{
					num = (0x4B061683U ^ num);
					num |= 0x580030BBU;
					num24 = class8_0.vmethod_13();
					num = (0x366F3AE0U & num);
				}
				else
				{
					num += 0x210A4854U;
					if (num <= 0x724D714EU)
					{
						continue;
					}
					num += 0x42ED2048U;
					num25 = class8_0.vmethod_10();
					if (0x6D8439EBU >= num)
					{
						goto IL_00;
					}
					num26 = class8_1.vmethod_10();
					if (!bool_0)
					{
						num >>= 0;
						if (0x1EF1537DU <= num)
						{
							goto Block_26;
						}
						goto IL_155;
					}
					else if (0x47093C77U < num)
					{
						goto IL_53B;
					}
				}
				uint num27 = class8_1.vmethod_13();
				if (bool_0)
				{
					num |= 0x4FC673E4U;
					int num28 = (int)num24;
					num = (0x5E2653EEU ^ num);
					num23 = checked(num28 + (int)num27);
					num ^= 0xBF85D814U;
					goto IL_163;
				}
				num += 0x49E0162FU;
				IL_155:
				int num29 = (int)num24;
				num *= 0x3C106982U;
				num23 = num29 + (int)num27;
				goto IL_163;
			}
			if ((0x6BE045AFU ^ num) != 0U)
			{
				goto IL_7E0;
			}
			continue;
			IL_47D:
			num = (0x79404356U & num);
			int num30 = class8_0.vmethod_10();
			num = (0x1BC0A9CU ^ num);
			int num31 = num30;
			if (0x5A814BD0U * num == 0U)
			{
				continue;
			}
			num = (0x2D8F645EU & num);
			int num32 = class8_1.vmethod_10();
			num %= 0x2B1A138FU;
			int num33 = num32;
			num = 0x6A9D4609U * num;
			int num34;
			if (!bool_0)
			{
				if (0x3ACA3A64U / num == 0U)
				{
					continue;
				}
				num34 = num31 + num33;
			}
			else
			{
				num /= 0x5791790FU;
				int num35 = num31;
				int num36 = num33;
				num = (0x6371B81U | num);
				num34 = checked(num35 + num36);
				num ^= 0x49EE909U;
			}
			value = num34;
			num ^= 0x34C99F19U;
			IL_512:
			if (0x78BB78E7 << (int)num != 0)
			{
				goto Block_39;
			}
			continue;
			Block_33:
			goto IL_512;
			IL_575:
			num /= 0x2FA4D58U;
			if (0x520F5F25 << (int)num == 0)
			{
				continue;
			}
			num ^= 0x6939154FU;
			long num37 = class8_0.AFC5EABA();
			num = 0x6267385BU + num;
			long num38 = num37;
			num = 0x6ACF6A44U - num;
			long num39 = class8_1.AFC5EABA();
			num >>= 0x1F;
			long num40 = num39;
			num -= 0x6929310BU;
			if (0xFC55BD9U != num)
			{
				goto Block_41;
			}
			goto IL_7E0;
			Block_16:
			long num43;
			if (!bool_0)
			{
				if (0x726479F2U >> (int)num == 0U)
				{
					continue;
				}
				ulong num17;
				long num41 = (long)num17;
				ulong num18;
				long num42 = (long)num18;
				num <<= 0x15;
				num43 = num41 + num42;
			}
			else
			{
				num = 0x41D8200DU >> (int)num;
				ulong num17;
				long num44 = (long)num17;
				num = 0x77CA5A9BU >> (int)num;
				ulong num18;
				num43 = checked(num44 + (long)num18);
				num ^= 0x4C03BE52U;
			}
			num = (0x37352C05U & num);
			long value2 = num43;
			goto IL_6E4;
			IL_64C:
			num -= 0x15342C08U;
			long num45 = class8_0.AFC5EABA();
			num = (0x38C60F85U & num);
			long num46 = num45;
			num = 0x11926106U + num;
			long num47 = class8_1.AFC5EABA();
			if (num == 0x7AFD7684U)
			{
				continue;
			}
			num >>= 9;
			long num50;
			if (!bool_0)
			{
				if (0x42D5345U * num == 0U)
				{
					continue;
				}
				long num48 = num46;
				num = 0xE4309B4U - num;
				long num49 = num47;
				num -= 0x386C1C95U;
				num50 = num48 + num49;
			}
			else
			{
				num <<= 0x15;
				long num51 = num46;
				long num52 = num47;
				num %= 0x473D4A9FU;
				num50 = checked(num51 + num52);
				num ^= 0xF30DC3E9U;
			}
			value2 = num50;
			num += 0x2E323C17U;
			IL_6E4:
			num = 0x75B42B17U - num;
			GClass18.Class16 class4;
			if (class8_0.vmethod_7() != typeCode2)
			{
				if ((num ^ 0x88A42E7U) == 0U)
				{
					goto IL_7E0;
				}
				num = 0x191538A9U << (int)num;
				class4 = (GClass18.Class16)class8_1;
			}
			else
			{
				class4 = (GClass18.Class16)class8_0;
				num += 0xE2CBD4E9U;
			}
			class5 = class4;
			if (0x16B322CDU >= num)
			{
				continue;
			}
			IntPtr intPtr = new IntPtr(value2);
			num *= 0x576A3F7FU;
			intPtr2 = intPtr;
			num = (0x28197E61U & num);
			if (num < 0x4FD57880U)
			{
				goto Block_50;
			}
			continue;
			IL_769:
			num &= 0x10EA3944U;
			GClass18.Class8 class6;
			if (!bool_1)
			{
				class6 = class8_1;
			}
			else
			{
				num |= 0x2E30355BU;
				class6 = class8_1.vmethod_5();
				num += 0xD1EFEBA5U;
			}
			num53 = class6.C0EC1D52();
			if (0x5AA420E4U < num)
			{
				continue;
			}
			if (bool_0)
			{
				goto IL_946;
			}
			if (0x453832AEU >= num)
			{
				goto Block_54;
			}
			continue;
			IL_7BE:
			num = 0x611E3E1DU << (int)num;
			if (num * 0x7B5E6E01U != 0U)
			{
				goto Block_55;
			}
			continue;
			IL_564:
			int num54;
			int_ = num54;
			num ^= 0x368234E9U;
			goto IL_7BE;
			IL_53B:
			int num55 = num25;
			num = 0x2B3E12B9U / num;
			int num56 = num26;
			num = 0x31203BBCU >> (int)num;
			num54 = checked(num55 + num56);
			num += 0xCEDFC444U;
			goto IL_564;
			Block_26:
			int num57 = num25;
			int num58 = num26;
			num = 0x3C486E74U / num;
			num54 = num57 + num58;
			goto IL_564;
			Block_12:
			goto IL_7BE;
			IL_7E0:
			num = 0x4F430E98U << (int)num;
			if (num >= 0x5FC644DCU)
			{
				goto Block_56;
			}
		}
		Block_7:
		double num59 = num20;
		num -= 0x3C3F228CU;
		double num60 = num22;
		num = (0x630F36C1U ^ num);
		double double_ = num59 + num60;
		goto IL_9A3;
		Block_8:
		double_ = num20 + num22;
		num ^= 0xEAC10791U;
		goto IL_9A3;
		Block_39:
		num -= 0x1C752376U;
		GClass18.Class16 class7;
		if (class8_0.vmethod_7() != typeCode2)
		{
			num = 0x303D62C4U % num;
			class7 = (GClass18.Class16)class8_1;
		}
		else
		{
			num %= 0x722B40F6U;
			num *= 0x7E931A33U;
			class7 = (GClass18.Class16)class8_0;
			num ^= 0xF0B599C8U;
		}
		GClass18.Class16 class8 = class7;
		void* ptr = new IntPtr(value).ToPointer();
		GClass18.Class8 class9 = class8;
		num = (0x6A415041U ^ num);
		object object_ = Pointer.Box(ptr, class9.vmethod_6());
		Type type_ = class8.vmethod_6();
		num |= 0xD7E140BU;
		return new GClass18.Class16(object_, type_);
		Block_41:
		num /= 0x5133D32U;
		long num63;
		if (!bool_0)
		{
			num <<= 0xA;
			long num38;
			long num61 = num38;
			long num40;
			long num62 = num40;
			num = (0x49D125C1U & num);
			num63 = num61 + num62;
		}
		else
		{
			long num38;
			long num64 = num38;
			long num40;
			long num65 = num40;
			num = 0x2E4036E8U >> (int)num;
			num63 = checked(num64 + num65);
			num ^= 0x2401U;
		}
		num <<= 0x19;
		long_ = num63;
		num ^= 0x700D36U;
		goto IL_8E6;
		Block_50:
		num &= 0x1B313E66U;
		void* ptr2 = intPtr2.ToPointer();
		Type type = class5.vmethod_6();
		num = 0x4A0E64A5U * num;
		object object_2 = Pointer.Box(ptr2, type);
		GClass18.Class8 class10 = class5;
		num = (0x60A348A6U | num);
		return new GClass18.Class16(object_2, class10.vmethod_6());
		Block_54:
		float num66 = num19;
		float num67 = num53;
		num += 0x1B3248A3U;
		float float_ = num66 + num67;
		goto IL_965;
		Block_55:
		return new GClass18.Class10(int_);
		Block_56:
		throw new InvalidOperationException();
		IL_8E6:
		num <<= 0x1E;
		return new GClass18.Class11(long_);
		IL_946:
		float num68 = num19;
		num = 0x422D46D0U << (int)num;
		float_ = num68 + num53;
		num += 0xE9A52AD3U;
		IL_965:
		return new GClass18.Class12(float_);
		IL_9A3:
		return new GClass18.Class13(double_);
	}

	// Token: 0x06001387 RID: 4999 RVA: 0x000921E8 File Offset: 0x000903E8
	private unsafe GClass18.Class8 method_12(GClass18.Class8 class8_0, GClass18.Class8 class8_1, bool bool_0, bool bool_1)
	{
		uint num;
		TypeCode typeCode;
		int num14;
		long num16;
		double num18;
		double num20;
		int num31;
		long long_;
		long num46;
		ulong num47;
		ulong num49;
		for (;;)
		{
			IL_00:
			num = 0x39186FB3U;
			typeCode = this.method_10(class8_0, class8_1);
			for (;;)
			{
				uint num2 = (uint)typeCode;
				num = 0x521F526BU - num;
				switch (num2 - (num ^ 0x1906E2B1U))
				{
				case 0U:
				{
					IL_1F7:
					if (bool_1)
					{
						uint num3 = class8_0.vmethod_13();
						num = 0x4F21C61U - num;
						uint num4 = num3;
						uint num5 = class8_1.vmethod_13();
						num = 0x9CB3721U - num;
						uint num6 = num5;
						goto IL_235;
					}
					num = 0x24934E81U + num;
					int num7 = class8_0.vmethod_10();
					num >>= 0x13;
					num += 0x30004187U;
					int num8 = class8_1.vmethod_10();
					num %= 0xB46615AU;
					num *= 0x6A470F53U;
					int num11;
					if (!bool_0)
					{
						if (0x695519F6U == num)
						{
							break;
						}
						int num9 = num7;
						num /= 0x350C47F6U;
						int num10 = num8;
						num /= 0x517D9BU;
						num11 = num9 - num10;
					}
					else
					{
						if (0x438D7EF8U + num == 0U)
						{
							goto IL_00;
						}
						int num12 = num7;
						int num13 = num8;
						num -= 0x2AD52D6CU;
						num11 = checked(num12 - num13);
						num ^= 0x8EB39DAAU;
					}
					num *= 0x67190D35U;
					num14 = num11;
					num ^= 0U;
					goto IL_2E2;
				}
				case 1U:
				{
					if (num >= 0x45A42C37U)
					{
						goto IL_00;
					}
					num = 0x4CB566AEU << (int)num;
					if (!bool_1)
					{
						goto IL_3B5;
					}
					if (0x3D8A6449U - num == 0U)
					{
						goto IL_00;
					}
					uint num15 = class8_0.vmethod_13();
					num += 0x2FF13128U;
					if (0x7CC20208U + num != 0U)
					{
						goto Block_15;
					}
					goto IL_235;
				}
				case 2U:
					num = 0x738A0A91U / num;
					if (bool_1)
					{
						goto IL_49F;
					}
					num = 0x110945F9U + num;
					num = 0x35E40E5BU + num;
					num16 = class8_0.AFC5EABA();
					if (0x70A8758BU + num != 0U)
					{
						goto Block_11;
					}
					continue;
				case 3U:
				{
					if (bool_1)
					{
						goto IL_544;
					}
					num -= 0x63EE2B73U;
					if ((num & 0x91557C3U) == 0U)
					{
						continue;
					}
					num &= 0x57D02504U;
					long num17 = class8_0.AFC5EABA();
					num |= 0x697575CDU;
					if (num + 0x179230A7U != 0U)
					{
						goto Block_9;
					}
					continue;
				}
				case 4U:
					num = 0x7603590FU / num;
					if (!bool_1)
					{
						goto IL_5C6;
					}
					if (num % 0x5BC0A4AU != 0U)
					{
						goto Block_6;
					}
					continue;
				case 5U:
				{
					if (num >= 0x34606871U)
					{
						continue;
					}
					num = (0x7FD96932U | num);
					GClass18.Class8 @class;
					if (!bool_1)
					{
						num = (0xA615B4CU | num);
						@class = class8_0;
					}
					else
					{
						@class = class8_0.vmethod_5();
						num ^= 0x201044U;
					}
					num18 = @class.F979B236();
					GClass18.Class8 class2;
					if (!bool_1)
					{
						class2 = class8_1;
					}
					else
					{
						num = 0x422D65F6U / num;
						if ((0x154A4FAAU ^ num) == 0U)
						{
							continue;
						}
						class2 = class8_1.vmethod_5();
						num ^= 0x7FFFFBFEU;
					}
					num = 0x22E21115U - num;
					double num19 = class2.F979B236();
					num *= 0x5D46DE0U;
					num20 = num19;
					num = (0x72F12DBCU ^ num);
					if (0x4EA42559U + num != 0U)
					{
						goto Block_4;
					}
					continue;
				}
				}
				goto Block_23;
				IL_2E2:
				if (0x3A8570E1U != num)
				{
					goto Block_22;
				}
				continue;
				IL_235:
				int num21;
				if (!bool_0)
				{
					if (0x15604F33U % num == 0U)
					{
						goto IL_00;
					}
					uint num4;
					uint num6;
					num21 = (int)(num4 - num6);
				}
				else
				{
					uint num4;
					int num22 = (int)num4;
					num *= 0x67D25124U;
					uint num6;
					num21 = checked(num22 - (int)num6);
					num += 0xD6BD6098U;
				}
				num = 0xFBA42D1U / num;
				num14 = num21;
				if (0x28924752 << (int)num == 0)
				{
					goto IL_1F7;
				}
				goto IL_2E2;
			}
			Block_9:
			num = 0x77D86057U >> (int)num;
			long num23 = class8_1.AFC5EABA();
			num = 0x5B550B28U * num;
			long num24 = num23;
			if (num >= 0x5F190023U)
			{
				goto Block_37;
			}
			continue;
			Block_15:
			num = (0x274E77B8U & num);
			uint num25 = class8_1.vmethod_13();
			num = 0x5C1C4EB6U % num;
			int num28;
			if (!bool_0)
			{
				num &= 0x28386E05U;
				uint num15;
				int num26 = (int)num15;
				num >>= 0xE;
				int num27 = (int)num25;
				num = 0x6BF76A64U / num;
				num28 = num26 - num27;
			}
			else
			{
				num = 0x299B7FE3U % num;
				uint num15;
				int num29 = (int)num15;
				num = (0x7FDF3318U | num);
				int num30 = (int)num25;
				num -= 0x6A6C73E9U;
				num28 = checked(num29 - num30);
				num += 0xEB8C65E5U;
			}
			num |= 0x738E2E39U;
			num31 = num28;
			if (0x4A8B24B4U + num == 0U)
			{
				continue;
			}
			IL_459:
			TypeCode typeCode2 = class8_0.vmethod_7();
			num %= 0x376940C7U;
			TypeCode typeCode3 = typeCode;
			num = 0x32A57C0FU >> (int)num;
			if (typeCode2 != typeCode3)
			{
				if (num != 0x50244AAFU)
				{
					goto Block_28;
				}
				continue;
			}
			else
			{
				if (0x4BEC2144U != num)
				{
					goto Block_29;
				}
				continue;
			}
			IL_3B5:
			num = 0x25CD576CU + num;
			int num32 = class8_0.vmethod_10();
			num = 0x16F4164AU * num;
			num = (0x568B2E76U ^ num);
			int num33 = class8_1.vmethod_10();
			num = 0x7640604BU << (int)num;
			int num34 = num33;
			num &= 0x472C5F00U;
			num <<= 3;
			int num36;
			if (!bool_0)
			{
				int num35 = num32;
				num &= 0x212D1E3FU;
				num36 = num35 - num34;
			}
			else
			{
				num = 0x1FF6B92U >> (int)num;
				int num37 = num32;
				int num38 = num34;
				num = 0x15C5143BU + num;
				num36 = checked(num37 - num38);
				num ^= 0x17C47FCDU;
			}
			num = 0x24C93C93U + num;
			num31 = num36;
			num ^= 0x5756D3A8U;
			goto IL_459;
			IL_49F:
			ulong num39 = class8_0.vmethod_14();
			if (0x39B524F2 << (int)num == 0)
			{
				continue;
			}
			num = 0x501727A4U >> (int)num;
			ulong num40 = class8_1.vmethod_14();
			long num43;
			if (!bool_0)
			{
				long num41 = (long)num39;
				long num42 = (long)num40;
				num = (0x7D10321U & num);
				num43 = num41 - num42;
			}
			else
			{
				long num44 = (long)num39;
				long num45 = (long)num40;
				num -= 0x4AE31EDU;
				num43 = checked(num44 - num45);
				num += 0x4ADC193U;
			}
			long_ = num43;
			if (num % 0x5D44526U != 0U)
			{
				goto Block_32;
			}
			continue;
			Block_11:
			num &= 0x3187656U;
			num46 = class8_1.AFC5EABA();
			num -= 0x6BA17DBBU;
			if (!bool_0)
			{
				goto IL_739;
			}
			if (0x385261EAU * num != 0U)
			{
				goto Block_34;
			}
			continue;
			IL_544:
			num |= 0x50304AC6U;
			num47 = class8_0.vmethod_14();
			num = 0x652B2011U - num;
			ulong num48 = class8_1.vmethod_14();
			num = (0xF5C2838U ^ num);
			num49 = num48;
			if (bool_0)
			{
				goto IL_7B3;
			}
			num >>= 0x18;
			if (num + 0x1FD81608U != 0U)
			{
				goto Block_36;
			}
			continue;
			IL_5D9:
			num |= 0x360C47C9U;
			GClass18.Class8 class3;
			float num50 = class3.C0EC1D52();
			num = 0x71B63FD0U + num;
			float num51 = num50;
			num <<= 0xF;
			if (num > 0x59E41AEAU)
			{
				continue;
			}
			num ^= 0xADF2A1FU;
			GClass18.Class8 class4;
			if (!bool_1)
			{
				num ^= 0x3313922U;
				class4 = class8_1;
			}
			else
			{
				num = (0x4FA15130U & num);
				class4 = class8_1.vmethod_5();
				num ^= 0x321932DU;
			}
			num = (0x4F03547FU & num);
			float num52 = class4.C0EC1D52();
			if (0x1D60502F << (int)num != 0)
			{
				goto Block_40;
			}
			continue;
			IL_5C6:
			class3 = class8_0;
			goto IL_5D9;
			Block_6:
			class3 = class8_0.vmethod_5();
			num += 0U;
			goto IL_5D9;
			Block_4:
			num %= 0x74761429U;
			if (bool_0)
			{
				goto IL_923;
			}
			if (num >= 0xE53704CU)
			{
				goto Block_42;
			}
		}
		Block_22:
		int int_ = num14;
		num = 0x7D853505U + num;
		return new GClass18.Class10(int_);
		Block_23:
		goto IL_952;
		Block_28:
		num = 0x7698136EU % num;
		GClass18.Class16 class5 = (GClass18.Class16)class8_1;
		goto IL_6C7;
		Block_29:
		num <<= 0x16;
		class5 = (GClass18.Class16)class8_0;
		num ^= 0x4AC0F774U;
		goto IL_6C7;
		Block_32:
		goto IL_783;
		Block_34:
		long num53 = num16;
		num >>= 0x17;
		long num54 = num46;
		num %= 0xA8E5D68U;
		long num55 = checked(num53 - num54);
		num ^= 0x19075051U;
		goto IL_76D;
		Block_36:
		long num56 = (long)num47;
		num = (0x1AF525D0U | num);
		long num57 = num56 - (long)num49;
		goto IL_7C2;
		Block_37:
		num = 0xA6E1298U + num;
		long num59;
		if (!bool_0)
		{
			num *= 0x461F3B36U;
			long num17;
			long num58 = num17;
			num /= 0x5EFD3E52U;
			long num24;
			num59 = num58 - num24;
		}
		else
		{
			num = 0x2A7556F4U << (int)num;
			long num17;
			long num60 = num17;
			num >>= 0x16;
			long num24;
			long num61 = num24;
			num = 0x240855D5U + num;
			num59 = checked(num60 - num61);
			num ^= 0x24085730U;
		}
		num -= 0x54223A23U;
		long num62 = num59;
		num ^= 0xAB2CE1CDU;
		goto IL_83F;
		Block_40:
		num *= 0x1CAA76BDU;
		float float_;
		if (!bool_0)
		{
			float num51;
			float num52;
			float_ = num51 - num52;
		}
		else
		{
			float num51;
			float num63 = num51;
			float num52;
			float num64 = num52;
			num <<= 0xC;
			float_ = num63 - num64;
			num += 0x7C598B09U;
		}
		return new GClass18.Class12(float_);
		Block_42:
		double double_ = num18 - num20;
		goto IL_958;
		IL_6C7:
		GClass18.Class16 class6 = class5;
		int value = num31;
		num >>= 0x1F;
		IntPtr intPtr = new IntPtr(value);
		num = (0x1CF66A5CU ^ num);
		IntPtr intPtr2 = intPtr;
		if (num <= 0x34707607U)
		{
			num = 0x7E012FE8U % num;
			void* ptr = intPtr2.ToPointer();
			GClass18.Class8 class7 = class6;
			num = 0x23877462U / num;
			Type type = class7.vmethod_6();
			num += 0x56800733U;
			object object_ = Pointer.Box(ptr, type);
			Type type_ = class6.vmethod_6();
			num *= 0x755C38E5U;
			return new GClass18.Class16(object_, type_);
		}
		goto IL_952;
		IL_739:
		long num65 = num16;
		long num66 = num46;
		num = 0x1907517DU % num;
		num55 = num65 - num66;
		IL_76D:
		num = 0x61C21578U + num;
		long_ = num55;
		num ^= 0x7FC864D5U;
		IL_783:
		num += 0x1027106BU;
		if (0x6EF9729CU / num != 0U)
		{
			return new GClass18.Class11(long_);
		}
		goto IL_952;
		IL_7B3:
		num57 = (long)(checked(num47 - num49));
		num += 0x164D08A9U;
		IL_7C2:
		num = (0x64F16E32U & num);
		num62 = num57;
		IL_83F:
		num += 0x6646670U;
		TypeCode typeCode4 = class8_0.vmethod_7();
		TypeCode typeCode5 = typeCode;
		num /= 0x586B4656U;
		GClass18.Class16 class8;
		if (typeCode4 != typeCode5)
		{
			num = (0x4490068U ^ num);
			class8 = (GClass18.Class16)class8_1;
		}
		else
		{
			num = (0xEF96C4CU ^ num);
			class8 = (GClass18.Class16)class8_0;
			num ^= 0xAB06C24U;
		}
		num >>= 0;
		GClass18.Class16 class9 = class8;
		long value2 = num62;
		num |= 0x1D29101AU;
		IntPtr intPtr3 = new IntPtr(value2);
		num |= 0x7A23DEAU;
		intPtr2 = intPtr3;
		num = 0x5CB31D57U << (int)num;
		void* ptr2 = intPtr2.ToPointer();
		GClass18.Class8 class10 = class9;
		num |= 0x4A9A30A7U;
		return new GClass18.Class16(Pointer.Box(ptr2, class10.vmethod_6()), class9.vmethod_6());
		IL_923:
		num = 0x54321724U + num;
		if (num / 0x2C1E1C5BU != 0U)
		{
			double num67 = num18;
			num -= 0x1E43545BU;
			double_ = num67 - num20;
			num += 0xCA113D37U;
			goto IL_958;
		}
		IL_952:
		throw new InvalidOperationException();
		IL_958:
		return new GClass18.Class13(double_);
	}

	// Token: 0x06001388 RID: 5000 RVA: 0x00092B54 File Offset: 0x00090D54
	private GClass18.Class8 method_13(GClass18.Class8 class8_0, GClass18.Class8 class8_1, bool bool_0, bool bool_1)
	{
		uint num;
		double num7;
		double num8;
		long num14;
		int num16;
		int num18;
		float num25;
		float num26;
		int num30;
		for (;;)
		{
			IL_00:
			num = 0x3C317386U;
			TypeCode typeCode = this.method_10(class8_0, class8_1);
			ulong num3;
			for (;;)
			{
				TypeCode typeCode2 = typeCode;
				num = 0x3A962D7DU * num;
				uint num2 = num ^ 0x21F7F667U;
				num ^= 0x2F21161DU;
				switch (typeCode2 - num2)
				{
				case 0:
					goto IL_173;
				case 1:
				case 3:
					goto IL_546;
				case 2:
					if (num > 0x16E24A1EU)
					{
						continue;
					}
					if (bool_1)
					{
						num = 0x355B28C4U / num;
						if (num << 0x1B == 0U)
						{
							continue;
						}
						num = 0x478B0905U << (int)num;
						num3 = class8_0.vmethod_14();
						num *= 0x7F7C5076U;
						if (0x701E43B7U <= num)
						{
							goto IL_173;
						}
						goto IL_205;
					}
					else
					{
						num |= 0x7F152386U;
						num |= 0x18707FU;
						long num4 = class8_0.AFC5EABA();
						num = (0x76F36665U & num);
						long num5 = num4;
						num /= 0x7C13186FU;
						if (num > 0x8DA7A0DU)
						{
							continue;
						}
						goto IL_2C9;
					}
					break;
				case 4:
					goto IL_37E;
				case 5:
				{
					num = 0x60166058U / num;
					if (0x441E28D4U <= num)
					{
						continue;
					}
					num = 0x6B467356U - num;
					GClass18.Class8 @class;
					if (!bool_1)
					{
						num = (0x5EE8626FU & num);
						@class = class8_0;
					}
					else
					{
						@class = class8_0.vmethod_5();
						num ^= 0x21061110U;
					}
					num -= 0x33737B46U;
					double num6 = @class.F979B236();
					num >>= 0xC;
					num7 = num6;
					GClass18.Class8 class2;
					if (!bool_1)
					{
						num = (0x3126E15U & num);
						if (0x244F0896U < num)
						{
							goto IL_00;
						}
						class2 = class8_1;
					}
					else
					{
						num += 0x713B123FU;
						if (0x7C0948F5U <= num)
						{
							goto IL_00;
						}
						num = (0x24C428E5U & num);
						class2 = class8_1.vmethod_5();
						num ^= 0x20044401U;
					}
					num8 = class2.F979B236();
					if (!bool_0)
					{
						goto IL_56C;
					}
					if (0x7E027795U * num == 0U)
					{
						goto IL_D7;
					}
					goto IL_586;
				}
				}
				goto Block_12;
				IL_D7:
				uint num9 = class8_0.vmethod_13();
				num ^= 0xE6143D5U;
				if (num * 0x16252542U == 0U)
				{
					goto IL_00;
				}
				uint num10 = class8_1.vmethod_13();
				num = (0x798F43A9U ^ num);
				uint num11 = num10;
				num = 0x8AF2BADU % num;
				if (0x73BC4321U > num)
				{
					goto Block_7;
				}
				continue;
				IL_173:
				num = 0x67DF1D69U % num;
				if (bool_1)
				{
					goto IL_D7;
				}
				goto IL_265;
			}
			IL_205:
			ulong num12 = class8_1.vmethod_14();
			if ((0x581F5CE0U ^ num) != 0U)
			{
				long num13;
				if (!bool_0)
				{
					if (0x34834CD5U - num == 0U)
					{
						break;
					}
					num13 = (long)(num3 * num12);
				}
				else
				{
					num = 0x9F5597CU - num;
					if (0x6AA65E55U >= num)
					{
						continue;
					}
					num13 = (long)(checked(num3 * num12));
					num += 0x5B462B64U;
				}
				num = (0x38D16165U ^ num);
				num14 = num13;
				goto IL_36C;
			}
			break;
			IL_265:
			num = 0x9204DDU / num;
			int num15 = class8_0.vmethod_10();
			num |= 0x18F045AFU;
			num16 = num15;
			num /= 0x12A1185EU;
			int num17 = class8_1.vmethod_10();
			num = 0x67B7059EU / num;
			num18 = num17;
			num &= 0x77827839U;
			num |= 0x5EAC0849U;
			if (!bool_0)
			{
				goto IL_4A3;
			}
			if ((num & 0x40140283U) != 0U)
			{
				goto Block_18;
			}
			continue;
			IL_2C9:
			num >>= 0x1B;
			long num19 = class8_1.AFC5EABA();
			num = (0x23C54298U & num);
			if (0x13B01BE0U >> (int)num == 0U)
			{
				continue;
			}
			num = (0x35A44099U | num);
			long num22;
			if (!bool_0)
			{
				num |= 0x36B77F03U;
				long num5;
				long num20 = num5;
				num = 0x363B708EU << (int)num;
				long num21 = num19;
				num /= 0x3D3D5692U;
				num22 = num20 * num21;
			}
			else
			{
				if (0x23BF3A62U - num == 0U)
				{
					continue;
				}
				long num5;
				long num23 = num5;
				num = 0x203C0D8CU * num;
				num22 = checked(num23 * num19);
				num ^= 0xF0F718ADU;
			}
			num %= 0x79121335U;
			num14 = num22;
			num += 0xA4CA314U;
			IL_36C:
			if (0x6A92942U * num != 0U)
			{
				goto Block_22;
			}
			continue;
			IL_37E:
			GClass18.Class8 class3;
			if (!bool_1)
			{
				class3 = class8_0;
			}
			else
			{
				num = 0x39037883U % num;
				num ^= 0x16C04C14U;
				class3 = class8_0.vmethod_5();
				num += 0xF4184535U;
			}
			num >>= 0x18;
			float num24 = class3.C0EC1D52();
			num %= 0x532F51D4U;
			num25 = num24;
			num = 0x58F425B4U % num;
			if (num >= 0x420231BFU)
			{
				continue;
			}
			num |= 0x56535F55U;
			GClass18.Class8 class4;
			if (!bool_1)
			{
				num &= 0x7BC666BCU;
				class4 = class8_1;
			}
			else
			{
				if (0x2CC0256U > num)
				{
					break;
				}
				num |= 0x22B37C12U;
				class4 = class8_1.vmethod_5();
				num ^= 0x24B13943U;
			}
			num26 = class4.C0EC1D52();
			if (num >> 0x10 == 0U)
			{
				break;
			}
			if (bool_0)
			{
				goto IL_50B;
			}
			num = 0xBC602A8U >> (int)num;
			if (0x76A93FD6U != num)
			{
				goto Block_29;
			}
			continue;
			Block_7:
			int num29;
			if (!bool_0)
			{
				num <<= 4;
				uint num9;
				int num27 = (int)num9;
				uint num11;
				int num28 = (int)num11;
				num >>= 0x10;
				num29 = num27 * num28;
			}
			else
			{
				uint num9;
				uint num11;
				num29 = (int)(checked(num9 * num11));
				num ^= 0x8AFA15FU;
			}
			num30 = num29;
			if (0x42283947U != num)
			{
				goto Block_31;
			}
		}
		do
		{
			IL_546:
			num = 0x69807CCU << (int)num;
		}
		while (0xFE4740EU >> (int)num == 0U);
		throw new InvalidOperationException();
		Block_12:
		num ^= 0U;
		goto IL_546;
		Block_18:
		int num31 = num16;
		num &= 0x37AB4383U;
		int num32 = num18;
		num = 0x31806FB8U * num;
		int num33 = checked(num31 * num32);
		num += 0x7F0FA9F4U;
		goto IL_4D7;
		Block_22:
		long long_ = num14;
		num -= 0x42FD6F18U;
		return new GClass18.Class11(long_);
		Block_29:
		double num34 = (double)(num25 * num26);
		goto IL_524;
		Block_31:
		goto IL_5B4;
		IL_4A3:
		num = 0x68C019ACU % num;
		num33 = num16 * num18;
		IL_4D7:
		num = 0x234F3802U / num;
		num30 = num33;
		num ^= 0x8AF2U;
		goto IL_5B4;
		IL_50B:
		num &= 0x44130B26U;
		num34 = (double)(num25 * num26);
		num += 0xBFFDFDFCU;
		IL_524:
		num &= 0x5A3655A5U;
		double double_ = num34;
		num = 0x2BE9303DU << (int)num;
		return new GClass18.Class13(double_);
		IL_56C:
		double num35 = num7;
		num <<= 0x16;
		double num36 = num8;
		num ^= 0x10C4069AU;
		double double_2 = num35 * num36;
		goto IL_5AE;
		IL_586:
		double num37 = num7;
		num = 0x713E03A3U >> (int)num;
		double num38 = num8;
		num -= 0x35686947U;
		double_2 = num37 * num38;
		num += 0x40188FA7U;
		IL_5AE:
		return new GClass18.Class13(double_2);
		IL_5B4:
		int int_ = num30;
		num = 0x463A2CC6U / num;
		return new GClass18.Class10(int_);
	}

	// Token: 0x06001389 RID: 5001 RVA: 0x00093128 File Offset: 0x00091328
	private GClass18.Class8 method_14(GClass18.Class8 class8_0, GClass18.Class8 class8_1, bool bool_0)
	{
		uint num = 0x7CB26556U;
		for (;;)
		{
			num = 0x2EB6786EU % num;
			num = 0x2D9C1DCEU % num;
			TypeCode typeCode = this.method_10(class8_0, class8_1);
			num = 0x396A3A8AU >> (int)num;
			TypeCode typeCode2 = typeCode;
			num = 0x2FF8759DU * num;
			if (0x74C9598FU >= num)
			{
				goto IL_302;
			}
			for (;;)
			{
				TypeCode typeCode3 = typeCode2;
				num += 0x153E5F52U;
				uint num2 = num + 0x2E7F00AFU;
				num &= 0xD7624D8U;
				switch (typeCode3 - num2)
				{
				case 0:
					if (0x50C01AD8U == num)
					{
						goto IL_302;
					}
					num = (0x50CE4E10U ^ num);
					if (bool_0)
					{
						num = 0x4F3D0E41U - num;
						if (num >> 0 != 0U)
						{
							goto Block_7;
						}
						continue;
					}
					else
					{
						if (num != 0x24E01936U)
						{
							goto Block_8;
						}
						continue;
					}
					break;
				case 1:
				case 3:
					goto IL_226;
				case 2:
					goto IL_CA;
				case 4:
					num = (0x16420D09U & num);
					if (!bool_0)
					{
						goto IL_234;
					}
					if (0x4C4E4E52U % num != 0U)
					{
						goto Block_4;
					}
					continue;
				case 5:
					num &= 0x35185E54U;
					num >>= 0x1B;
					if (!bool_0)
					{
						goto IL_2A8;
					}
					num = 0x17000475U >> (int)num;
					if (num != 0xF727CF0U)
					{
						goto Block_2;
					}
					continue;
				}
				goto Block_9;
			}
			IL_CA:
			num ^= 0x3AA63B28U;
			if (num + 0x45137C0AU != 0U)
			{
				if (bool_0)
				{
					goto IL_1C0;
				}
				if (0x7C31457EU % num != 0U)
				{
					goto IL_1EB;
				}
			}
		}
		Block_2:
		GClass18.Class8 @class = class8_0.vmethod_5();
		num ^= 0x17000475U;
		goto IL_2B9;
		Block_4:
		num = 0x2C2B4AFBU / num;
		GClass18.Class8 class2 = class8_0.vmethod_5();
		num ^= 0x76638072U;
		goto IL_255;
		Block_7:
		num <<= 0x1A;
		int num3 = (int)class8_0.vmethod_13();
		num <<= 0x17;
		uint num4 = class8_1.vmethod_13();
		int num5 = num3 / (int)num4;
		num = 0x1010001U;
		int int_ = num5;
		goto IL_302;
		Block_8:
		num %= 0x36347073U;
		int num6 = class8_0.vmethod_10();
		num = 0x6480342DU - num;
		int num7 = class8_1.vmethod_10();
		num ^= 0x63E55259U;
		int num8 = num7;
		num -= 0x25FB5EB6U;
		int num9 = num8;
		num = 0x24B379F0U << (int)num;
		int_ = num6 / num9;
		num += 0x65318001U;
		goto IL_302;
		Block_9:
		num += 0U;
		goto IL_226;
		IL_1C0:
		long num10 = (long)class8_0.vmethod_14();
		num /= 0x58EA19B1U;
		num = 0x5350793CU - num;
		ulong num11 = class8_1.vmethod_14();
		long num12 = num10 / (long)num11;
		num = (0x27C469CBU | num);
		long long_ = num12;
		goto IL_21E;
		IL_1EB:
		long num13 = class8_0.AFC5EABA();
		num = (0x250C2753U ^ num);
		num &= 0x1765282AU;
		long num14 = class8_1.AFC5EABA();
		long num15 = num13 / num14;
		num -= 0x57BD3F7AU;
		long_ = num15;
		num ^= 0xC9B69157U;
		IL_21E:
		return new GClass18.Class11(long_);
		IL_226:
		num &= 0x265F539AU;
		throw new InvalidOperationException();
		IL_234:
		num ^= 0x76697092U;
		class2 = class8_0;
		IL_255:
		num = 0x1D6E5905U << (int)num;
		float num16 = class2.C0EC1D52();
		GClass18.Class8 class3;
		if (!bool_0)
		{
			num &= 0x6003583BU;
			class3 = class8_1;
		}
		else
		{
			num ^= 0x4ED65AF7U;
			class3 = class8_1.vmethod_5();
			num ^= 0x5AD65AF7U;
		}
		float num17 = class3.C0EC1D52();
		num <<= 0x12;
		return new GClass18.Class12(num16 / num17);
		IL_2A8:
		@class = class8_0;
		IL_2B9:
		num += 0x52EC651AU;
		double num18 = @class.F979B236();
		GClass18.Class8 class4;
		if (!bool_0)
		{
			class4 = class8_1;
		}
		else
		{
			class4 = class8_1.vmethod_5();
			num += 0U;
		}
		num |= 0x69376EEBU;
		double num19 = class4.F979B236();
		num ^= 0x4FCF5568U;
		double double_ = num18 / num19;
		num *= 0x31D74905U;
		return new GClass18.Class13(double_);
		IL_302:
		num ^= 0x3B1014F6U;
		return new GClass18.Class10(int_);
	}

	// Token: 0x0600138A RID: 5002 RVA: 0x00093448 File Offset: 0x00091648
	private GClass18.Class8 method_15(GClass18.Class8 class8_0, GClass18.Class8 class8_1, bool bool_0)
	{
		uint num = 0x3A40154DU;
		for (;;)
		{
			TypeCode typeCode = class8_0.vmethod_7();
			num = 0x1F0D0F3FU + num;
			TypeCode typeCode2 = typeCode;
			if (num >= 0x3353496DU)
			{
				for (;;)
				{
					if (typeCode2 != (TypeCode)(num ^ 0x594D2485U))
					{
						for (;;)
						{
							TypeCode typeCode3 = typeCode2;
							uint num2 = num - 0x594D2481U;
							num = (0x6A7A1B3BU | num);
							if (typeCode3 == num2)
							{
								break;
							}
							if (0x712D06B7U < num)
							{
								goto IL_5C;
							}
						}
						num &= 0x104F3162U;
						if (!bool_0)
						{
							goto IL_66;
						}
						if (0x6C206769U * num != 0U)
						{
							goto IL_A2;
						}
					}
					else
					{
						num = 0x47D96416U >> (int)num;
						if (0x29E61F25U > num)
						{
							goto Block_1;
						}
					}
				}
				IL_5C:
				if (0x4FA23D7U < num)
				{
					break;
				}
				continue;
				IL_66:
				if (num != 0x2BE323CU)
				{
					goto Block_6;
				}
				continue;
				Block_1:
				if (!bool_0)
				{
					goto IL_15B;
				}
				if (num != 0x3F080EADU)
				{
					goto Block_8;
				}
			}
		}
		throw new InvalidOperationException();
		Block_6:
		num = 0x74745722U << (int)num;
		long num3 = class8_0.AFC5EABA();
		num = 0x412F0CD4U >> (int)num;
		long num4 = class8_1.AFC5EABA();
		long num5 = num4;
		num |= 0x282F3955U;
		long long_ = num3 % num5;
		num >>= 9;
		return new GClass18.Class11(long_);
		Block_8:
		num &= 0xBED7D39U;
		int num6 = (int)class8_0.vmethod_13();
		num -= 0x1B1833D6U;
		uint num7 = class8_1.vmethod_13();
		num = 0x54BF6239U + num;
		uint num8 = num7;
		num = (0x77483F57U | num);
		int int_ = num6 % (int)num8;
		num = (0x66870B63U ^ num);
		return new GClass18.Class10(int_);
		IL_A2:
		num = 0x6E4F351DU >> (int)num;
		long num9 = (long)class8_0.vmethod_14();
		ulong num10 = class8_1.vmethod_14();
		num = 0x1CE33221U / num;
		long num11 = (long)num10;
		num = 0x27E04B92U >> (int)num;
		return new GClass18.Class11(num9 % num11);
		IL_15B:
		num -= 0x5F475357U;
		num ^= 0x184C37EEU;
		int num12 = class8_0.vmethod_10();
		num %= 0x39130D4FU;
		int num13 = class8_1.vmethod_10();
		int num14 = num13;
		num ^= 0x2ACE58C9U;
		return new GClass18.Class10(num12 % num14);
	}

	// Token: 0x0600138B RID: 5003 RVA: 0x000935E8 File Offset: 0x000917E8
	private GClass18.Class8 method_16(GClass18.Class8 class8_0, GClass18.Class8 class8_1)
	{
		uint num = 0x4D151BB8U;
		for (;;)
		{
			num ^= 0x78CE0E71U;
			num = 0x745A5ECDU << (int)num;
			num = 0x1A6D3383U << (int)num;
			TypeCode typeCode = this.method_10(class8_0, class8_1);
			num = 0x671364F9U - num;
			TypeCode typeCode2 = typeCode;
			if (0x1B16021BU < num)
			{
				for (;;)
				{
					uint num2 = (uint)typeCode2;
					num &= 0x6CA65BBU;
					switch (num2 - (num - 0x4822129U))
					{
					case 0U:
						goto IL_151;
					case 1U:
					case 3U:
						goto IL_1A2;
					case 2U:
						goto IL_FA;
					case 4U:
						goto IL_48;
					case 5U:
						goto IL_85;
					default:
						if (num != 0x61163B04U)
						{
							goto Block_1;
						}
						break;
					}
				}
				IL_48:
				num = 0x317B162EU - num;
				if (num >> 0x1E != 0U)
				{
					goto IL_151;
				}
				int size = IntPtr.Size;
				uint num3 = num + 0xD3070B08U;
				num -= 0x799B148BU;
				if (size != num3)
				{
					goto Block_4;
				}
				if (0x11E5206FU - num != 0U)
				{
					goto Block_5;
				}
				continue;
				IL_85:
				if (IntPtr.Size != (int)(num - 0x482212EU))
				{
					goto Block_6;
				}
				num = 0x7AE1546DU / num;
				if (0x5E125375U > num)
				{
					goto IL_1B8;
				}
			}
		}
		do
		{
			IL_1A2:
			num = 0x497F45EDU % num;
		}
		while (0x70B56631U <= num);
		throw new InvalidOperationException();
		Block_1:
		num ^= 0U;
		goto IL_1A2;
		Block_4:
		num = (0x1C045DB0U ^ num);
		float float_ = 0f;
		goto IL_14B;
		Block_5:
		float_ = float.NaN;
		num ^= 0x1C045DB0U;
		goto IL_14B;
		Block_6:
		double double_;
		if (0x52165B97U >= num)
		{
			double_ = 0.0;
			goto IL_1C9;
		}
		goto IL_1A2;
		IL_FA:
		num = 0x30F7E85U / num;
		num += 0x6AD52FF4U;
		long num4 = class8_0.AFC5EABA();
		num %= 0x365D054FU;
		num &= 0x6D227CA7U;
		long num5 = class8_1.AFC5EABA();
		return new GClass18.Class11(num4 ^ num5);
		IL_14B:
		return new GClass18.Class12(float_);
		IL_151:
		num <<= 0xC;
		int num6 = class8_0.vmethod_10();
		int num7 = class8_1.vmethod_10();
		num = 0x49596A6AU + num;
		int num8 = num7;
		num ^= 0x19613C8AU;
		int num9 = num8;
		num *= 0x1A163536U;
		int int_ = num6 ^ num9;
		num &= 0x1BD233E1U;
		return new GClass18.Class10(int_);
		IL_1B8:
		double_ = double.NaN;
		num ^= 0x4822129U;
		IL_1C9:
		num %= 0x296147F0U;
		return new GClass18.Class13(double_);
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x000937CC File Offset: 0x000919CC
	private GClass18.Class8 method_17(GClass18.Class8 class8_0, GClass18.Class8 class8_1)
	{
		uint num = 0x71DE509CU;
		for (;;)
		{
			num = 0xB2E0C58U / num;
			num = (0x4E9C1033U & num);
			TypeCode typeCode = this.method_10(class8_0, class8_1);
			for (;;)
			{
				switch (typeCode - ((int)num + TypeCode.Int32))
				{
				case 0:
					goto IL_9D;
				case 1:
				case 3:
					goto IL_10F;
				case 2:
					goto IL_5B;
				case 4:
				{
					int size = IntPtr.Size;
					uint num2 = num - 0xFFFFFFFCU;
					num -= 0xDA3688BU;
					if (size != num2)
					{
						goto Block_1;
					}
					num = (0x70FE0BA8U & num);
					if (num < 0x6BBC039AU)
					{
						continue;
					}
					goto IL_11C;
				}
				case 5:
					goto IL_12F;
				}
				goto Block_2;
			}
			Block_1:
			if (num <= 0x60166C01U)
			{
				continue;
			}
			goto IL_115;
			IL_5B:
			num = 0x29C22A5FU + num;
			if (num < 0x2AEE6058U)
			{
				goto Block_3;
			}
		}
		Block_2:
		num += 0U;
		goto IL_10F;
		Block_3:
		long num3 = class8_0.AFC5EABA();
		num *= 0x692427A4U;
		num = 0x4C6A757FU * num;
		long num4 = class8_1.AFC5EABA();
		num += 0x4D4B4620U;
		long num5 = num4;
		num ^= 0x66D858D1U;
		long long_ = num3 | num5;
		num |= 0xF0D65BAU;
		return new GClass18.Class11(long_);
		IL_9D:
		int num6 = class8_0.vmethod_10();
		num -= 0x40260651U;
		int num7 = class8_1.vmethod_10();
		num &= 0x15BD7447U;
		int num8 = num7;
		num = (0x23FF60F1U ^ num);
		int num9 = num8;
		num = (0x71023E8BU & num);
		return new GClass18.Class10(num6 | num9);
		IL_10F:
		throw new InvalidOperationException();
		IL_115:
		float float_ = 0f;
		goto IL_129;
		IL_11C:
		float_ = float.NaN;
		num ^= 0x82009455U;
		IL_129:
		return new GClass18.Class12(float_);
		IL_12F:
		int size2 = IntPtr.Size;
		num = 0x6E3A0CC5U * num;
		uint num10 = num ^ 4U;
		num = 0x18C66A4FU * num;
		double double_;
		if (size2 != num10)
		{
			double_ = 0.0;
		}
		else
		{
			num = (0x3C275AEAU ^ num);
			double_ = double.NaN;
			num += 0xC3D8A516U;
		}
		return new GClass18.Class13(double_);
	}

	// Token: 0x0600138D RID: 5005 RVA: 0x00093950 File Offset: 0x00091B50
	private GClass18.Class8 method_18(GClass18.Class8 class8_0, GClass18.Class8 class8_1)
	{
		uint num = 0x2A5D6AC9U;
		for (;;)
		{
			num += 0x66FF1EFBU;
			num ^= 0x3C9E719AU;
			num += 0x27981E7DU;
			TypeCode typeCode = this.method_10(class8_0, class8_1);
			num = 0x3A9D1614U % num;
			TypeCode typeCode2 = typeCode;
			num = (0x7D903933U & num);
			for (;;)
			{
				int num2 = typeCode2 - (TypeCode)(num - 0x38901007U);
				num %= 0x650B2987U;
				switch (num2)
				{
				case 0:
					goto IL_F1;
				case 1:
				case 3:
					goto IL_6E;
				case 2:
					goto IL_11E;
				case 4:
					goto IL_7B;
				case 5:
				{
					num = 0x7F28019DU % num;
					uint size = (uint)IntPtr.Size;
					num += 0xB2277D2U;
					if (size == num - 0x192A594BU)
					{
						goto IL_19C;
					}
					if ((num ^ 0x31E805F1U) == 0U)
					{
						continue;
					}
					goto IL_191;
				}
				}
				goto Block_2;
			}
			IL_6E:
			if (0x3F1C3907U > num)
			{
				break;
			}
			continue;
			IL_7B:
			if (0x48183A93U < num)
			{
				goto IL_191;
			}
			if (IntPtr.Size != (int)(num ^ 0x38901014U))
			{
				if (num > 0x278752C8U)
				{
					goto Block_6;
				}
				continue;
			}
			else
			{
				num = 0x49F0785AU << (int)num;
				if (num - 0x22392BE4U == 0U)
				{
					continue;
				}
				goto IL_170;
			}
			Block_2:
			num ^= 0U;
			goto IL_6E;
		}
		throw new InvalidOperationException();
		Block_6:
		float float_ = 0f;
		goto IL_17D;
		IL_F1:
		num = (0x2A5E7619U & num);
		int num3 = class8_0.vmethod_10();
		num = 0x97912B7U * num;
		int num4 = class8_1.vmethod_10();
		int int_ = num3 & num4;
		num /= 0x2AD84C5BU;
		return new GClass18.Class10(int_);
		IL_11E:
		num += 0x2B8434F8U;
		num %= 0x649B2289U;
		long num5 = class8_0.AFC5EABA();
		long num6 = class8_1.AFC5EABA();
		num = 0x1C453B73U + num;
		long num7 = num6;
		num -= 0x2A5B3C18U;
		long num8 = num7;
		num = 0x37F20811U % num;
		long long_ = num5 & num8;
		num *= 0xE451C28U;
		return new GClass18.Class11(long_);
		IL_170:
		float_ = float.NaN;
		num += 0xC0361010U;
		IL_17D:
		num = 0xA753392U << (int)num;
		return new GClass18.Class12(float_);
		IL_191:
		double double_ = 0.0;
		goto IL_1AD;
		IL_19C:
		double_ = double.NaN;
		num ^= 0U;
		IL_1AD:
		return new GClass18.Class13(double_);
	}

	// Token: 0x0600138E RID: 5006 RVA: 0x00093B10 File Offset: 0x00091D10
	private int method_19(GClass18.Class8 class8_0, GClass18.Class8 class8_1, bool bool_0, int int_1)
	{
		uint num = 0x60CA69FAU;
		int num2;
		for (;;)
		{
			IL_4A7:
			num |= 0x13521DA3U;
			num2 = int_1;
			num <<= 0;
			if (0x50340AC7U <= num)
			{
				for (;;)
				{
					num |= 0x759C5638U;
					TypeCode typeCode = class8_0.vmethod_7();
					num = 0x777515CU * num;
					if (0x7AA3138DU * num != 0U)
					{
						goto IL_137;
					}
					IL_148:
					uint num3 = (uint)typeCode;
					num ^= 0x1C51E15U;
					TypeCode typeCode2;
					if (num3 != num + 0x23599C9EU)
					{
						if (0x19276F93U > num)
						{
							goto IL_4A7;
						}
						if (typeCode2 == (TypeCode)(num ^ 0xDCA66362U))
						{
							num += 0U;
						}
						else
						{
							num = 0x1E0A6D4EU + num;
							if (typeCode == (int)num + (TypeCode)0x54F2F5D)
							{
								goto IL_3EE;
							}
							if (0x1D091707U / num != 0U)
							{
								goto IL_4A7;
							}
							uint num4 = (uint)typeCode2;
							num = (0x74632A01U | num);
							if (num4 == (num ^ 0xFEF3FABFU))
							{
								goto Block_5;
							}
							TypeCode typeCode3 = typeCode;
							num *= 0x1AE05750U;
							uint num5 = num - 0xEB507E43U;
							num = 0x9EB7916U + num;
							if (typeCode3 != num5)
							{
								if (0x6D22417CU % num == 0U)
								{
									goto IL_1E6;
								}
								TypeCode typeCode4 = typeCode2;
								uint num6 = num ^ 0xF53BF76BU;
								num = (0x39855EAAU | num);
								if (typeCode4 == num6)
								{
									num += 0xF77BF778U;
								}
								else
								{
									TypeCode typeCode5 = typeCode;
									num -= 0x59451C0FU;
									uint num7 = num ^ 0xA47AE3D4U;
									num += 0x3FFD5AF4U;
									if (typeCode5 != num7)
									{
										if (0x4A506E12U + num == 0U)
										{
											goto IL_4A7;
										}
										uint num8 = (uint)typeCode2;
										num = 0x60F20F24U << (int)num;
										if (num8 == num + 0x86E0000BU)
										{
											num += 0x6B583ED3U;
										}
										else
										{
											TypeCode typeCode6 = typeCode;
											num &= 0x3BDB75DDU;
											uint num9 = num + 0xC7000009U;
											num = 0x4FA24ECBU * num;
											if (typeCode6 != num9)
											{
												num /= 0x435B7A56U;
												if (num > 0x49B33CF8U)
												{
													goto IL_4A7;
												}
												TypeCode typeCode7 = typeCode2;
												uint num10 = num - 0xFFFFFFF7U;
												num = (0x522C2916U & num);
												num += 2U;
												if (typeCode7 != num10)
												{
													goto IL_452;
												}
												num += 0x32FFFFFEU;
											}
											if (bool_0)
											{
												goto IL_2AC;
											}
											if (num * 0x34F6081U != 0U)
											{
												break;
											}
											continue;
										}
									}
									if (0x173126DFU <= num)
									{
										goto Block_12;
									}
									goto IL_137;
								}
							}
							num = 0x6C3D2C02U >> (int)num;
							if (num != 0x48A11ECAU)
							{
								goto Block_13;
							}
							goto IL_137;
						}
					}
					IL_1E6:
					num = 0x70263B3CU % num;
					if (num != 0x29212CC1U)
					{
						goto Block_20;
					}
					continue;
					IL_137:
					typeCode2 = class8_1.vmethod_7();
					num |= 0x4C427452U;
					goto IL_148;
				}
				num = 0x7937A8FU % num;
				int num11 = class8_0.vmethod_10();
				num = 0x1D7C5436U + num;
				int num12 = num11;
				num = 0x253D3B99U >> (int)num;
				int num13;
				if (0x6E90700BU != num)
				{
					num = 0x2FE11BEFU << (int)num;
					num = 0x42157998U / num;
					int value = class8_1.vmethod_10();
					num = 0x3A7220ECU >> (int)num;
					num13 = num12.CompareTo(value);
					goto IL_2EF;
				}
				continue;
				Block_12:
				int num15;
				if (!bool_0)
				{
					num = 0x48FD15CDU >> (int)num;
					long num14 = class8_0.AFC5EABA();
					num *= 0x1CC11B68U;
					num15 = num14.CompareTo(class8_1.AFC5EABA());
				}
				else
				{
					ulong num16 = class8_0.vmethod_14();
					num ^= 0x55794F88U;
					ulong num17 = num16;
					if (num < 0x34FA24F2U)
					{
						continue;
					}
					num = 0x4CA132B0U % num;
					ulong value2 = class8_1.vmethod_14();
					num &= 0x735E6C06U;
					num15 = num17.CompareTo(value2);
					num += 0x558D998U;
				}
				num2 = num15;
				num ^= 0x4558F99AU;
				goto IL_452;
				IL_3EE:
				num = (0x58EB610CU ^ num);
				if ((num & 0x3E0D41A1U) == 0U)
				{
					continue;
				}
				num = 0x7D8593FU << (int)num;
				double num18 = class8_0.F979B236();
				num = 0x7CE76277U + num;
				double num19 = num18;
				if (0x10C40691U * num == 0U)
				{
					continue;
				}
				int num20 = num19.CompareTo(class8_1.F979B236());
				num /= 0x1F91282AU;
				num2 = num20;
				if (0x1445711BU >= num)
				{
					goto IL_452;
				}
				continue;
				Block_5:
				num ^= 0x4432A00U;
				goto IL_3EE;
				IL_452:
				num ^= 0x416C24D0U;
				if (0x22866D0EU >= num)
				{
					continue;
				}
				int num21 = num2;
				uint num22 = num - 0x416C24D2U;
				num *= 0x16EA12B5U;
				if (num21 >= num22)
				{
					goto IL_4CC;
				}
				num = 0x61887F65U << (int)num;
				int num23 = (int)(num + 0x6BFFFFFFU);
				num <<= 0x11;
				num2 = num23;
				if (0x79AC36E3U * num != 0U)
				{
					continue;
				}
				return num2;
				IL_2EF:
				num = 0x96B6211U - num;
				num2 = num13;
				num += 0x3106BEDDU;
				goto IL_452;
				IL_2AC:
				num = 0x8F86625U >> (int)num;
				uint num24 = class8_0.vmethod_13();
				num = 0x765F7B6DU - num;
				uint num25 = num24;
				uint value3 = class8_1.vmethod_13();
				num = 0x54914767U - num;
				num13 = num25.CompareTo(value3);
				num += 0x5347EECDU;
				goto IL_2EF;
				Block_13:
				num = 0x2B174171U >> (int)num;
				float num26 = class8_0.C0EC1D52();
				num = 0x537C3EFDU - num;
				num %= 0x2A4055EFU;
				float value4 = class8_1.C0EC1D52();
				num >>= 0x1E;
				int num27 = num26.CompareTo(value4);
				num /= 0x4645381DU;
				num2 = num27;
				num ^= 2U;
				goto IL_452;
			}
		}
		Block_20:
		object obj = class8_0.vmethod_1();
		object obj2 = class8_1.vmethod_1();
		num = 0x6F5F1928U % num;
		object obj3 = obj2;
		object obj4 = obj3;
		num &= 0x3FDC1DC5U;
		if (obj == obj4)
		{
			return (int)(num ^ 0x2F5C1900U);
		}
		bool flag = obj3 != null;
		num >>= 1;
		if (flag)
		{
			num /= 0x440895U;
			return (int)(num - 0x5AU);
		}
		num = 0x76055FF2U >> (int)num;
		return (int)(num + 0x89FAA00FU);
		IL_4CC:
		num %= 0x22BF39D9U;
		int num28 = num2;
		num = 0x677628CU + num;
		uint num29 = num - 0xB7B47A2U;
		num += 0xF484B85EU;
		if (num28 > num29)
		{
			int num30 = (int)(num ^ 1U);
			num -= 0x186F38AEU;
			num2 = num30;
			num ^= 0xE790C752U;
		}
		return num2;
	}

	// Token: 0x0600138F RID: 5007 RVA: 0x0009409C File Offset: 0x0009229C
	private GClass18.Class8 method_20(GClass18.Class8 class8_0)
	{
		TypeCode typeCode = class8_0.vmethod_7();
		uint num = 0x7D514132U;
		for (;;)
		{
			TypeCode typeCode2 = typeCode;
			uint num2 = num ^ 0x7D51413BU;
			num <<= 5;
			if (typeCode2 == num2)
			{
				goto IL_9D;
			}
			num >>= 1;
			if (0x3B635B14U + num != 0U)
			{
				TypeCode typeCode3 = typeCode;
				num = 0x6A3E21BFU * num;
				uint num3 = num ^ 0xF23164EBU;
				num = (0x6A0E0223U | num);
				if (typeCode3 != num3)
				{
					if (0x7F34CE4U == num)
					{
						continue;
					}
				}
				else if ((num & 0x7F422B63U) != 0U)
				{
					break;
				}
			}
			num = (0x4DD5588CU & num);
			if (num / 0x54D6495FU == 0U)
			{
				goto IL_97;
			}
		}
		num &= 0x11D058C6U;
		long num4 = class8_0.AFC5EABA();
		num = (0x764F5087U | num);
		long long_ = ~num4;
		num += 0x20A022C5U;
		return new GClass18.Class11(long_);
		IL_97:
		throw new InvalidOperationException();
		IL_9D:
		num >>= 1;
		int num5 = class8_0.vmethod_10();
		num ^= 0xC493152U;
		return new GClass18.Class10(~num5);
	}

	// Token: 0x06001390 RID: 5008 RVA: 0x00094164 File Offset: 0x00092364
	private GClass18.Class8 method_21(GClass18.Class8 class8_0)
	{
		uint num = 0x42734C8BU;
		for (;;)
		{
			uint num2 = (uint)class8_0.vmethod_7();
			num %= 0x8A17651U;
			switch (num2 - (num + 0xF9F6EFB5U))
			{
			case 0U:
				goto IL_60;
			case 1U:
			case 3U:
				goto IL_A2;
			case 2U:
				goto IL_7D;
			case 4U:
				goto IL_A8;
			case 5U:
				num = 0x792F68CFU >> (int)num;
				if (num > 0x4CF25294U)
				{
					continue;
				}
				goto IL_C5;
			}
			break;
		}
		num ^= 0U;
		goto IL_A2;
		IL_60:
		num = 0x174919F1U / num;
		int num3 = class8_0.vmethod_10();
		num = (0x6BA727C7U | num);
		return new GClass18.Class10(-num3);
		IL_7D:
		num >>= 0x1E;
		long num4 = class8_0.AFC5EABA();
		num = (0x262B3561U & num);
		long long_ = -num4;
		num /= 0x32046D57U;
		return new GClass18.Class11(long_);
		IL_A2:
		throw new InvalidOperationException();
		IL_A8:
		num |= 0x2E591D35U;
		num <<= 6;
		return new GClass18.Class12(-class8_0.C0EC1D52());
		IL_C5:
		num /= 0x66057807U;
		double num5 = class8_0.F979B236();
		num |= 0x58E7081BU;
		return new GClass18.Class13(-num5);
	}

	// Token: 0x06001391 RID: 5009 RVA: 0x00094254 File Offset: 0x00092454
	private GClass18.Class8 method_22(GClass18.Class8 class8_0, GClass18.Class8 class8_1, bool bool_0)
	{
		uint num = 0x16172891U;
		for (;;)
		{
			num |= 0x73F81274U;
			TypeCode typeCode = class8_0.vmethod_7();
			for (;;)
			{
				uint num2 = (uint)typeCode;
				num = (0x282D4246U | num);
				if (num2 != (num ^ 0x7FFF7AFEU))
				{
					break;
				}
				num &= 0x5B6135DU;
				if (num % 0xF5C79A1U != 0U)
				{
					goto IL_118;
				}
			}
			if (typeCode != (int)num + (TypeCode)(-0x7FFF7AEC))
			{
				if (num % 0x41DE39D5U != 0U)
				{
					break;
				}
			}
			else
			{
				num -= 0x1F5917A9U;
				if (0x741E14E0U > num)
				{
					goto IL_75;
				}
			}
		}
		num /= 0x1B735729U;
		throw new InvalidOperationException();
		IL_75:
		num /= 0x8402A5AU;
		if (bool_0)
		{
			num += 0x423B3791U;
			ulong num3 = class8_0.vmethod_14();
			int num4 = class8_1.vmethod_10();
			num *= 0x717E2FFFU;
			int num5 = num4;
			num = 0x42546540U * num;
			int num6 = num5;
			num = 0x5C48619BU % num;
			int num7 = (int)(num ^ 0x5C4861A4U);
			num = 0x79875308U * num;
			return new GClass18.Class11(num3 >> (num6 & num7));
		}
		num = 0x10E074EAU - num;
		long num8 = class8_0.AFC5EABA();
		int num9 = class8_1.vmethod_10();
		num -= 0x10ED5478U;
		int num10 = num9;
		num *= 0x654367AU;
		int num11 = num10;
		num += 0x4B754B70U;
		int num12 = (int)(num ^ 0x99F476B9U);
		num = 0x57E5071EU + num;
		long long_ = num8 >> (num11 & num12);
		num = 0x758A55E8U << (int)num;
		return new GClass18.Class11(long_);
		IL_118:
		if (bool_0)
		{
			num |= 0x37275F3AU;
			num *= 0x20057D6AU;
			uint num13 = class8_0.vmethod_13();
			int num14 = class8_1.vmethod_10();
			num = 0x51FA4929U / num;
			int num15 = num14;
			num = 0x7A65117FU - num;
			int num16 = num15;
			int num17 = (int)(num - 0x7A651160U);
			num = 0x315B4D61U / num;
			return new GClass18.Class10(num13 >> (num16 & num17));
		}
		num = (0x465B5DA7U ^ num);
		num = 0x7E982E42U << (int)num;
		int num18 = class8_0.vmethod_10();
		num = 0x27630173U * num;
		int num19 = class8_1.vmethod_10();
		num += 0x20776615U;
		int num20 = num19;
		int num21 = num20;
		num = 0x115021B2U / num;
		return new GClass18.Class10(num18 >> (num21 & (int)(num - 0xFFFFFFE1U)));
	}

	// Token: 0x06001392 RID: 5010 RVA: 0x00094410 File Offset: 0x00092610
	private GClass18.Class8 method_23(GClass18.Class8 class8_0, GClass18.Class8 class8_1)
	{
		uint num = 0x3C7B10E2U;
		TypeCode typeCode;
		do
		{
			typeCode = class8_0.vmethod_7();
			TypeCode typeCode2 = typeCode;
			uint num2 = num ^ 0x3C7B10EBU;
			num %= 0x28CD57D7U;
			if (typeCode2 == num2)
			{
				goto IL_B3;
			}
		}
		while (num >> 0xE == 0U);
		do
		{
			uint num3 = (uint)typeCode;
			num &= 0x7AD61ADBU;
			if (num3 == (num ^ 0x12841800U))
			{
				goto IL_52;
			}
		}
		while ((0x68D473E0U & num) == 0U);
		throw new InvalidOperationException();
		IL_52:
		long num4 = class8_0.AFC5EABA();
		num = 0x5E80444BU >> (int)num;
		num = 0x69AE51A4U / num;
		int num5 = class8_1.vmethod_10();
		num &= 0x64825CF0U;
		int num6 = num5;
		int num7 = num6;
		num = 0x198879BFU >> (int)num;
		int num8 = (int)(num ^ 0x19B7U);
		num *= 0x1940196FU;
		int num9 = num7 & num8;
		num /= 0x81D5528U;
		long long_ = num4 << num9;
		num = (0xBA278DAU & num);
		return new GClass18.Class11(long_);
		IL_B3:
		num = 0x5C193671U / num;
		int num10 = class8_0.vmethod_10();
		int num11 = class8_1.vmethod_10();
		num = (0x2670691AU & num);
		int int_ = num10 << (num11 & (int)(num ^ 0x1FU));
		num *= 0x221F0853U;
		return new GClass18.Class10(int_);
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x00094504 File Offset: 0x00092704
	private unsafe GClass18.Class8 method_24(object object_0, Type type_1)
	{
		uint num;
		GClass18.Class8 @class;
		for (;;)
		{
			IL_00:
			object obj = object_0;
			num = 0x5A470869U;
			@class = (obj as GClass18.Class8);
			for (;;)
			{
				num = 0x62E0414FU % num;
				if (type_1.IsEnum)
				{
					goto Block_31;
				}
				if (num >= 0x358360E5U)
				{
					goto IL_00;
				}
				num &= 0x2DCC7731U;
				TypeCode typeCode = Type.GetTypeCode(type_1);
				if (num < 0xCD128B4U)
				{
					TypeCode typeCode2 = typeCode;
					num >>= 0xF;
					uint num2 = num + 0xFFFFEEF3U;
					num -= 0x33350203U;
					switch (typeCode2 - num2)
					{
					case 0:
						goto IL_289;
					case 1:
					{
						num = 0xD1C60FBU - num;
						if (0x5F7758F6U <= num)
						{
							goto IL_00;
						}
						bool flag = @class != null;
						num <<= 0x19;
						if (!flag)
						{
							goto IL_2AF;
						}
						if (num >= 0x75ED39CAU)
						{
							goto Block_6;
						}
						continue;
					}
					case 2:
						goto IL_2C0;
					case 3:
						goto IL_2E6;
					case 4:
						goto IL_2FD;
					case 5:
					{
						num &= 0x7C9C4B5AU;
						if (0x74DF7AB5U - num == 0U)
						{
							goto IL_00;
						}
						bool flag2 = @class != null;
						num = 0x2C062639U / num;
						if (!flag2)
						{
							goto IL_31B;
						}
						num >>= 0x1B;
						if (num % 0x2C21792BU == 0U)
						{
							goto Block_9;
						}
						continue;
					}
					case 6:
						goto IL_6BB;
					case 7:
						goto IL_32B;
					case 8:
						goto IL_363;
					case 9:
					{
						num = 0x7181288EU << (int)num;
						bool flag3 = @class != null;
						num = 0x31F6269DU / num;
						if (!flag3)
						{
							goto IL_772;
						}
						if (num != 0x1A7A64A2U)
						{
							goto Block_11;
						}
						continue;
					}
					case 0xA:
					{
						if (num * 0x51CF63ADU == 0U)
						{
							continue;
						}
						bool flag4 = @class != null;
						num /= 0x39DA3D57U;
						if (flag4)
						{
							goto IL_396;
						}
						num -= 0x656B4A0DU;
						if ((num & 0x22CF36EEU) != 0U)
						{
							goto Block_14;
						}
						continue;
					}
					case 0xB:
					{
						bool flag5 = @class != null;
						num = 0x53E515F0U / num;
						if (flag5)
						{
							goto IL_7E2;
						}
						if (num + 0x37EE39B0U != 0U)
						{
							goto Block_16;
						}
						continue;
					}
					case 0xC:
					case 0xD:
					case 0xE:
						break;
					case 0xF:
						goto IL_581;
					default:
						if (num < 0x4CAE72C7U)
						{
							goto IL_00;
						}
						num ^= 0U;
						break;
					}
					if (num == 0x47A14BC9U)
					{
						goto IL_00;
					}
					RuntimeTypeHandle handle = typeof(IntPtr).TypeHandle;
					num = (0x58542CCU ^ num);
					Type typeFromHandle = Type.GetTypeFromHandle(handle);
					num = 0x251D53A1U % num;
					if (type_1 == typeFromHandle)
					{
						goto Block_18;
					}
					num |= 0x56E21590U;
					if (type_1 == typeof(UIntPtr))
					{
						num = 0x21751C18U - num;
						bool flag6 = @class != null;
						num += 0x4DCC6BB0U;
						if (flag6)
						{
							goto IL_3E5;
						}
						if (0x54704F1EU >= num)
						{
							goto IL_00;
						}
						if (object_0 != null)
						{
							goto IL_403;
						}
						num = 0x72682EC7U * num;
						if (0x2F877229U < num)
						{
							goto Block_23;
						}
					}
					else
					{
						if (0x7DFF55DBU < num)
						{
							goto IL_00;
						}
						if (!type_1.IsValueType)
						{
							goto IL_4CE;
						}
						if (num + 0x63F768E4U == 0U)
						{
							goto IL_42D;
						}
						if (@class != null)
						{
							goto IL_88C;
						}
						num -= 0x163A50E5U;
						if ((0x7C910C02U ^ num) == 0U)
						{
							goto IL_42D;
						}
						bool flag7 = object_0 != null;
						num = 0x123D51E2U % num;
						if (!flag7)
						{
							goto IL_418;
						}
						if (0x63AB2463U != num)
						{
							goto Block_30;
						}
					}
				}
			}
			IL_289:
			num /= 0x1F7F7790U;
			bool flag8 = @class != null;
			num >>= 6;
			if (flag8)
			{
				goto IL_5C5;
			}
			if (0x68DC3940U >= num)
			{
				goto Block_33;
			}
			continue;
			IL_2AF:
			if (num >> 0x1A != 0U)
			{
				goto Block_34;
			}
			continue;
			IL_2E6:
			if (@class != null)
			{
				goto IL_647;
			}
			if (0x49346A3CU / num == 0U)
			{
				goto Block_38;
			}
			continue;
			IL_32B:
			if ((num ^ 0x18CC086BU) == 0U)
			{
				continue;
			}
			bool flag9 = @class != null;
			num = 0x367E233AU >> (int)num;
			if (!flag9)
			{
				goto IL_70A;
			}
			num %= 0x780B7D68U;
			if (0x334F0CDDU != num)
			{
				goto Block_44;
			}
			goto IL_42D;
			IL_363:
			if (num + 0xEA16427U == 0U)
			{
				goto IL_438;
			}
			bool flag10 = @class != null;
			num = (0x7B284A68U & num);
			if (!flag10)
			{
				goto IL_736;
			}
			num %= 0x30C437FFU;
			if (num % 0x3207586EU != 0U)
			{
				goto Block_47;
			}
			continue;
			IL_396:
			if (0x5F10253BU >= num)
			{
				goto Block_48;
			}
			continue;
			Block_18:
			num += 0x2FAD71E4U;
			if (@class != null)
			{
				goto IL_806;
			}
			if (0x44A87697 << (int)num == 0)
			{
				goto IL_507;
			}
			if (object_0 == null)
			{
				goto IL_822;
			}
			num = 0x7A076F99U % num;
			if ((0x558F33BEU & num) != 0U)
			{
				goto Block_52;
			}
			continue;
			IL_3E5:
			num = 0x80C2FCCU >> (int)num;
			if (0x386A3E57U != num)
			{
				goto Block_53;
			}
			continue;
			IL_458:
			num %= 0x65365C06U;
			if (0x341731CC << (int)num == 0)
			{
				continue;
			}
			bool flag11 = object_0 != null;
			num *= 0x29F56241U;
			if (!flag11)
			{
				goto IL_507;
			}
			num = 0x4B85605DU / num;
			if (0x1D4F6D4FU == num)
			{
				continue;
			}
			object obj2 = object_0;
			num = 0x2443564EU / num;
			bool flag12 = obj2 is Enum;
			num ^= 0x98A2ADFU;
			if (!flag12)
			{
				goto IL_4AB;
			}
			goto IL_507;
			IL_438:
			GClass18.Class8 class2 = @class;
			num = (0x133E5CBDU & num);
			object obj3 = class2.vmethod_1();
			num *= 0x70A72DCDU;
			object_0 = obj3;
			num += 0x947B7172U;
			goto IL_458;
			IL_418:
			num += 0x3DF275BDU;
			if (0x302017A1U < num)
			{
				goto Block_55;
			}
			goto IL_438;
			IL_42D:
			bool flag13 = @class != null;
			num |= 0x695F672CU;
			if (flag13)
			{
				goto IL_438;
			}
			goto IL_458;
			IL_403:
			num = 0x1B800AF6U % num;
			if (0x25A262C3U > num)
			{
				goto Block_54;
			}
			goto IL_42D;
			IL_31B:
			if (0x6ED63D14U > num)
			{
				goto Block_41;
			}
			goto IL_42D;
			Block_31:
			num += 0x5DA070F4U;
			goto IL_42D;
			IL_2C0:
			bool flag14 = @class != null;
			num += 0x4D4B1E52U;
			if (!flag14)
			{
				goto IL_605;
			}
			num = 0x4E286A6FU + num;
			if (num > 0x3F790EDBU)
			{
				goto Block_36;
			}
			goto IL_458;
			IL_4CE:
			num = 0x56F35DECU % num;
			if (0x29DC343EU > num)
			{
				continue;
			}
			if (type_1.IsArray)
			{
				if (0x2CDF001EU % num == 0U)
				{
					continue;
				}
				if (@class != null)
				{
					goto IL_900;
				}
				if (num << 0x1E == 0U)
				{
					goto IL_8C7;
				}
			}
			else
			{
				num = 0x1D0879C9U / num;
				bool isPointer = type_1.IsPointer;
				num <<= 3;
				if (!isPointer)
				{
					goto IL_9C2;
				}
				num = 0x3C025ED8U >> (int)num;
				bool flag15 = @class != null;
				num = 0x3DE91815U + num;
				if (!flag15)
				{
					goto IL_95C;
				}
				num = (0x4ED017F5U & num);
				if (num / 0x4DA90C24U == 0U)
				{
					goto Block_68;
				}
				continue;
			}
			IL_507:
			if (num / 0x36C35FE0U != 0U)
			{
				continue;
			}
			if (object_0 != null)
			{
				goto IL_8D7;
			}
			num = 0xD7730DU + num;
			if (0x432C65A9U != num)
			{
				goto Block_65;
			}
			continue;
			IL_4AB:
			object value = object_0;
			num <<= 0;
			object obj4 = Enum.ToObject(type_1, value);
			num |= 0x7CA145C5U;
			object_0 = obj4;
			num += 0x9BFFBBFBU;
			goto IL_507;
			IL_2FD:
			num = (0x34AA1296U | num);
			if (@class == null)
			{
				goto IL_663;
			}
			if (0x18A27F86U <= num)
			{
				goto Block_40;
			}
			goto IL_4AB;
			IL_581:
			num = (0x50237E05U & num);
			if (@class == null)
			{
				num = 0x71735150U * num;
				if ((num ^ 0x34F17F8U) != 0U)
				{
					goto Block_70;
				}
			}
			else
			{
				num *= 0x233290DU;
				if (num > 0x6C8228A5U)
				{
					goto Block_71;
				}
			}
		}
		Block_6:
		char char_ = @class.vmethod_11();
		num += 0U;
		goto IL_5F7;
		Block_9:
		GClass18.Class8 class3 = @class;
		num = 0x2AC074F3U - num;
		ushort ushort_ = class3.A7B71418();
		num ^= 0x3AC77C9EU;
		goto IL_6AD;
		Block_11:
		GClass18.Class8 class4 = @class;
		num %= 0x7E547087U;
		ulong ulong_ = class4.vmethod_14();
		num ^= 0x475C5E22U;
		goto IL_7A0;
		Block_14:
		object value2 = object_0;
		num = (0x24284305U ^ num);
		float float_ = Convert.ToSingle(value2);
		goto IL_7CC;
		Block_16:
		object value3 = object_0;
		num = 0x39A4BA9U - num;
		double double_ = Convert.ToDouble(value3);
		goto IL_7F8;
		Block_23:
		UIntPtr uintptr_ = UIntPtr.Zero;
		goto IL_886;
		Block_30:
		object object_ = object_0;
		goto IL_8B9;
		Block_33:
		bool bool_ = Convert.ToBoolean(object_0);
		goto IL_5DB;
		Block_34:
		char_ = Convert.ToChar(object_0);
		goto IL_5F7;
		Block_36:
		GClass18.Class8 class5 = @class;
		num = 0x71026CA9U - num;
		sbyte sbyte_ = class5.vmethod_8();
		num ^= 0x8C3D4DBU;
		goto IL_631;
		Block_38:
		object value4 = object_0;
		num = (0x139130E8U & num);
		byte byte_ = Convert.ToByte(value4);
		goto IL_655;
		Block_40:
		short short_ = @class.vmethod_9();
		num ^= 0U;
		goto IL_681;
		Block_41:
		object value5 = object_0;
		num = (0x1007086DU | num);
		ushort_ = Convert.ToUInt16(value5);
		goto IL_6AD;
		Block_44:
		GClass18.Class8 class6 = @class;
		num ^= 0x3EB92645U;
		uint uint_ = class6.vmethod_13();
		num ^= 0x3EB92645U;
		goto IL_728;
		Block_47:
		GClass18.Class8 class7 = @class;
		num *= 0x29460FE7U;
		long long_ = class7.AFC5EABA();
		num += 0x6935450EU;
		goto IL_764;
		Block_48:
		float_ = @class.C0EC1D52();
		num ^= 0xBEBCF6F0U;
		goto IL_7CC;
		Block_52:
		object obj5 = object_0;
		num /= 0xF653CC9U;
		IntPtr intptr_ = (IntPtr)obj5;
		num += 0x54CAAU;
		goto IL_847;
		Block_53:
		GClass18.Class8 class8 = @class;
		num = 0x31223E67U / num;
		return new GClass18.Class27(class8.vmethod_15());
		Block_54:
		object obj6 = object_0;
		num /= 0x62FD7343U;
		uintptr_ = (UIntPtr)obj6;
		num ^= 0xE06F83E1U;
		goto IL_886;
		Block_55:
		num ^= 0x61BB7C11U;
		object_ = Activator.CreateInstance(type_1);
		num ^= 0x23A9EA6CU;
		goto IL_8B9;
		Block_65:
		num *= 0x3E090544U;
		Enum enum_ = (Enum)Activator.CreateInstance(type_1);
		num += 0x26EC53A4U;
		goto IL_8FA;
		Block_68:
		void* ptr = @class.vmethod_16();
		num /= 0x4472D8FU;
		object object_2 = Pointer.Box(ptr, type_1);
		num = 0x27C578C4U * num;
		num = 0x13620DD6U * num;
		return new GClass18.Class16(object_2, type_1);
		Block_70:
		object obj7 = object_0;
		num = 0x2D862857U % num;
		string string_ = (string)obj7;
		goto IL_A12;
		Block_71:
		string_ = @class.ToString();
		num += 0x9B20A516U;
		goto IL_A12;
		IL_5C5:
		GClass18.Class8 class9 = @class;
		num -= 0x6A65ACCU;
		bool_ = class9.E6731BF1();
		num ^= 0xF959A534U;
		IL_5DB:
		return new GClass18.Class31(bool_);
		IL_5F7:
		num &= 0x8B967EBU;
		return new GClass18.Class32(char_);
		IL_605:
		object value6 = object_0;
		num = 0x3A8346BBU >> (int)num;
		sbyte_ = Convert.ToSByte(value6);
		IL_631:
		return new GClass18.Class34(sbyte_);
		IL_647:
		byte_ = @class.vmethod_12();
		num += 0x33B5F0FBU;
		IL_655:
		num ^= 0x4C223223U;
		return new GClass18.Class33(byte_);
		IL_663:
		num >>= 0;
		short_ = Convert.ToInt16(object_0);
		IL_681:
		return new GClass18.Class29(short_);
		IL_6AD:
		num = (0x79355833U | num);
		return new GClass18.Class30(ushort_);
		IL_6BB:
		num += 0x774D32C8U;
		int int_;
		if (@class == null)
		{
			num ^= 0x2CAB7907U;
			object value7 = object_0;
			num %= 0x23024934U;
			int_ = Convert.ToInt32(value7);
		}
		else
		{
			num *= 0x240B5EA6U;
			GClass18.Class8 class10 = @class;
			num = 0x5B537E93U * num;
			int_ = class10.vmethod_10();
			num += 0xF5B6BF30U;
		}
		num &= 0x18D0013EU;
		return new GClass18.Class10(int_);
		IL_70A:
		uint_ = Convert.ToUInt32(object_0);
		IL_728:
		num = (0x2476481EU & num);
		return new GClass18.Class35(uint_);
		IL_736:
		num = (0xFD978D0U | num);
		object value8 = object_0;
		num ^= 0xFF528F5U;
		long_ = Convert.ToInt64(value8);
		IL_764:
		num = (0x70F41D9EU ^ num);
		return new GClass18.Class11(long_);
		IL_772:
		num = 0x1BD7058AU * num;
		object value9 = object_0;
		num = 0x633363ADU - num;
		ulong_ = Convert.ToUInt64(value9);
		IL_7A0:
		num = (0x71673AF3U ^ num);
		return new GClass18.Class36(ulong_);
		IL_7CC:
		return new GClass18.Class12(float_);
		IL_7E2:
		num >>= 0x1E;
		double_ = @class.F979B236();
		num ^= 0x39A4BA9U;
		IL_7F8:
		num = 0x31FB7194U - num;
		return new GClass18.Class13(double_);
		IL_806:
		GClass18.Class8 class11 = @class;
		num |= 0x2B7C60A6U;
		IntPtr intptr_2 = class11.C2F10BC1();
		num &= 0x3A6C4E63U;
		return new GClass18.Class26(intptr_2);
		IL_822:
		num >>= 0xC;
		intptr_ = IntPtr.Zero;
		IL_847:
		num = 0x35E632D4U + num;
		return new GClass18.Class26(intptr_);
		IL_886:
		return new GClass18.Class27(uintptr_);
		IL_88C:
		GClass18.Class8 class12 = @class;
		num &= 0x1716815U;
		return new GClass18.Class17(class12.vmethod_1());
		IL_8B9:
		num /= 0x30C03CB6U;
		return new GClass18.Class17(object_);
		IL_8C7:
		object obj8 = object_0;
		num &= 0x25E40655U;
		Array array_ = (Array)obj8;
		goto IL_923;
		IL_8D7:
		enum_ = (Enum)object_0;
		IL_8FA:
		return new GClass18.Class28(enum_);
		IL_900:
		num = 0x52492EFAU % num;
		object obj9 = @class.vmethod_1();
		num = 0x20607A6EU / num;
		array_ = (Array)obj9;
		num += 0x4E00444U;
		IL_923:
		num = 0x4B7D7F54U % num;
		return new GClass18.Class18(array_);
		IL_95C:
		num |= 0x38E011A4U;
		void* ptr2;
		if (object_0 == null)
		{
			num = 0x6B0901F8U >> (int)num;
			ptr2 = num - 0x35848U;
		}
		else
		{
			num = 0x513B4CA4U - num;
			object ptr3 = object_0;
			num ^= 0x233C105AU;
			ptr2 = Pointer.Unbox(ptr3);
			num += 0xB8F935BU;
		}
		num = 0x715D4D1BU % num;
		object object_3 = Pointer.Box(ptr2, type_1);
		num >>= 0x1D;
		num = (0x2B1C4608U ^ num);
		return new GClass18.Class16(object_3, type_1);
		IL_9C2:
		bool flag16 = @class != null;
		num = 0x542E7F00U * num;
		object object_4;
		if (!flag16)
		{
			object_4 = object_0;
		}
		else
		{
			num = (0x653B5A9DU ^ num);
			GClass18.Class8 class13 = @class;
			num >>= 5;
			object_4 = class13.vmethod_1();
			num ^= 0x329DAD4U;
		}
		return new GClass18.Class15(object_4);
		IL_A12:
		return new GClass18.Class14(string_);
	}

	// Token: 0x06001394 RID: 5012 RVA: 0x00094F28 File Offset: 0x00093128
	private string method_25(int int_1)
	{
		uint num = 0x602863BFU;
		Dictionary<int, object> obj;
		do
		{
			Dictionary<int, object> dictionary = GClass18.dictionary_1;
			num = 0x2FA22B1DU % num;
			obj = dictionary;
			num = (0x374A2F0FU ^ num);
		}
		while (num == 0xBA139F7U);
		string result;
		lock (obj)
		{
			num /= 0x7F664CA6U;
			object obj2;
			if (num != 0x4DC12BB8U)
			{
				Dictionary<int, object> dictionary2 = GClass18.dictionary_1;
				num &= 0x678A0452U;
				num = (0x49420D8FU | num);
				bool flag = dictionary2.TryGetValue(int_1, out obj2);
				num = 0x4270018BU >> (int)num;
				if (flag)
				{
					if ((num ^ 0x7D240821U) == 0U)
					{
						goto IL_10F;
					}
				}
				else
				{
					num %= 0x5AD764BCU;
					Module module = this.module_0;
					num = 0x76625E01U % num;
					string text = module.ResolveString(int_1);
					num = 0x203F0DD3U * num;
					string text2 = text;
					Dictionary<int, object> dictionary3 = GClass18.dictionary_1;
					num &= 0x797E5E80U;
					num |= 0x6AEC4FE8U;
					object value = text2;
					num = 0x1AF47DE3U * num;
					dictionary3.Add(int_1, value);
					if (num > 0x71FC437DU)
					{
						return text2;
					}
				}
			}
			do
			{
				object obj3 = obj2;
				num *= 0x54F005CFU;
				string text3 = (string)obj3;
				num = 0x79F626BDU - num;
				result = text3;
			}
			while ((num & 0x30493E80U) == 0U);
			IL_10F:;
		}
		return result;
	}

	// Token: 0x06001395 RID: 5013 RVA: 0x0009506C File Offset: 0x0009326C
	private Type method_26(int int_1)
	{
		Dictionary<int, object> dictionary = GClass18.dictionary_1;
		object obj = dictionary;
		uint num = 0x2D4519AU;
		Monitor.Enter(obj);
		Type result2;
		try
		{
			num = (0x599854F0U | num);
			object obj2;
			if (0x303E7458U < num)
			{
				for (;;)
				{
					Dictionary<int, object> dictionary2 = GClass18.dictionary_1;
					num = 0x274E4973U * num;
					if (dictionary2.TryGetValue(int_1, out obj2))
					{
						break;
					}
					if (0x21390D7BU * num != 0U)
					{
						goto IL_62;
					}
				}
				num = (0x4EE22371U & num);
				goto IL_9F;
				IL_62:
				num += 0x14075C40U;
				Module module = this.module_0;
				num *= 0x7D234120U;
				Type type = module.ResolveType(int_1);
				Dictionary<int, object> dictionary3 = GClass18.dictionary_1;
				num *= 0x25E4526AU;
				dictionary3.Add(int_1, type);
				Type result = type;
				num += 0x27362E7FU;
				return result;
			}
			IL_9F:
			Type type2 = (Type)obj2;
			num = 0x53D74B94U / num;
			result2 = type2;
		}
		finally
		{
			Monitor.Exit(dictionary);
		}
		return result2;
	}

	// Token: 0x06001396 RID: 5014 RVA: 0x00095148 File Offset: 0x00093348
	private MethodBase method_27(int int_1)
	{
		Dictionary<int, object> dictionary = GClass18.dictionary_1;
		object obj = dictionary;
		uint num = 0x45FB7AD6U;
		Monitor.Enter(obj);
		MethodBase result;
		try
		{
			num += 0x253F7FA3U;
			object obj2;
			if (num % 0x60A86479U != 0U)
			{
				Dictionary<int, object> dictionary2 = GClass18.dictionary_1;
				num = 0x55C9452EU + num;
				num &= 0x15230F11U;
				num = 0x1E553241U * num;
				bool flag = dictionary2.TryGetValue(int_1, out obj2);
				num += 0x3E624032U;
				if (!flag)
				{
					goto IL_6F;
				}
				if (0x5B753025U <= num)
				{
					goto IL_CE;
				}
				IL_63:
				MethodBase methodBase;
				result = methodBase;
				if (0x1377054EU * num != 0U)
				{
					return result;
				}
				IL_6F:
				num = 0x3A656A22U % num;
				num <<= 9;
				methodBase = this.module_0.ResolveMethod(int_1);
				num = 0x64F74FE1U - num;
				Dictionary<int, object> dictionary3 = GClass18.dictionary_1;
				num = 0x565B3BB0U + num;
				num |= 0x35B63E3CU;
				object value = methodBase;
				num = (0x69C20DDAU & num);
				dictionary3.Add(int_1, value);
				num = (0x783B13D6U & num);
				if (num >= 0x18EB1468U)
				{
					goto IL_63;
				}
			}
			IL_CE:
			object obj3 = obj2;
			num &= 0x61DC6FC7U;
			result = (MethodBase)obj3;
		}
		finally
		{
			Monitor.Exit(dictionary);
		}
		return result;
	}

	// Token: 0x06001397 RID: 5015 RVA: 0x00095258 File Offset: 0x00093458
	private FieldInfo method_28(int int_1)
	{
		Dictionary<int, object> dictionary = GClass18.dictionary_1;
		uint num = 0xCC000000U;
		Dictionary<int, object> obj = dictionary;
		FieldInfo result2;
		lock (obj)
		{
			if (0x18BD2B7EU > num)
			{
				goto IL_52;
			}
			object obj2;
			do
			{
				IL_33:
				Dictionary<int, object> dictionary2 = GClass18.dictionary_1;
				num = 0x4E331CEU >> (int)num;
				if (!dictionary2.TryGetValue(int_1, out obj2))
				{
					goto IL_52;
				}
			}
			while (0x248529D6U == num);
			FieldInfo result = (FieldInfo)obj2;
			num = 0xB64562CU << (int)num;
			return result;
			IL_52:
			num = (0x7BEB75A6U | num);
			Module module = this.module_0;
			num = 0x1BA30EE0U % num;
			FieldInfo fieldInfo = module.ResolveField(int_1);
			num = (0x4A22140BU & num);
			Dictionary<int, object> dictionary3 = GClass18.dictionary_1;
			num = 0x31297A19U % num;
			object value = fieldInfo;
			num <<= 0x15;
			dictionary3.Add(int_1, value);
			num <<= 6;
			if (num % 0x36B63E24U == 0U)
			{
				goto IL_33;
			}
			result2 = fieldInfo;
		}
		return result2;
	}

	// Token: 0x06001398 RID: 5016 RVA: 0x0009534C File Offset: 0x0009354C
	private GClass18.Class8 method_29(MethodBase methodBase_0)
	{
		uint num = 0xE71630U;
		Dictionary<int, GClass18.Class8> dictionary;
		object[] array;
		object object_2;
		for (;;)
		{
			IL_1BC:
			num = 0x230221AEU - num;
			ParameterInfo[] parameters = methodBase_0.GetParameters();
			num &= 0x37511814U;
			if (0x3FA01B9EU >= num)
			{
				for (;;)
				{
					dictionary = new Dictionary<int, GClass18.Class8>();
					num = 0x35501A76U % num;
					if (0x76536FCFU + num == 0U)
					{
						goto IL_1BC;
					}
					int num2 = parameters.Length;
					num /= 0xCDC4E64U;
					int num3 = num2;
					num = (0x7A9354C8U & num);
					array = new object[num3];
					int num4 = parameters.Length;
					num = 0x248868B7U * num;
					int num5 = (int)(num ^ 1U);
					num ^= 0x64747F13U;
					int num6 = num4 - num5;
					for (;;)
					{
						num = (0x239C71B0U | num);
						if (num6 < (int)(num - 0x67FC7FB3U))
						{
							goto Block_4;
						}
						GClass18.Class8 @class = this.method_1();
						bool flag = @class.vmethod_3();
						num = 0x1A7173A5U;
						if (flag)
						{
							num ^= 0x3310980U;
							if ((num ^ 0x6133211FU) == 0U)
							{
								break;
							}
							Dictionary<int, GClass18.Class8> dictionary2 = dictionary;
							num = 0x3AF26805U - num;
							int key = num6;
							num = 0x572B259CU / num;
							GClass18.Class8 value = @class;
							num |= 0x4FD75D1DU;
							dictionary2[key] = value;
							num ^= 0x55A62EBAU;
						}
						num = 0x623C6D78U - num;
						if (num > 0x63BE1FABU)
						{
							break;
						}
						object[] array2 = array;
						num = 0x2A432F06U << (int)num;
						int num7 = num6;
						num ^= 0x7A97788DU;
						object object_ = @class;
						ParameterInfo[] array3 = parameters;
						num = (0x5EFB534AU | num);
						int num8 = num6;
						num ^= 0x360349EAU;
						array2[num7] = this.method_24(object_, array3[num8].ParameterType).vmethod_1();
						num >>= 0x1D;
						int num9 = num6;
						num ^= 0xC5706C9U;
						int num10 = (int)(num ^ 0xC5706CBU);
						num %= 0x67265598U;
						int num11 = num9 - num10;
						num -= 0x39B66F79U;
						num6 = num11;
						num ^= 0xB6D4E842U;
					}
				}
				Block_4:
				ConstructorInfo constructorInfo = (ConstructorInfo)methodBase_0;
				num &= 0x159527F8U;
				object obj = constructorInfo.Invoke(array);
				num = 0x6EBE14A3U / num;
				object_2 = obj;
				if (0x197E187EU != num)
				{
					break;
				}
			}
		}
		Dictionary<int, GClass18.Class8> dictionary3 = dictionary;
		num ^= 0x327F12C0U;
		Dictionary<int, GClass18.Class8>.Enumerator enumerator = dictionary3.GetEnumerator();
		num = (0x237669C7U | num);
		using (Dictionary<int, GClass18.Class8>.Enumerator enumerator2 = enumerator)
		{
			if (num * 0x51B56474U == 0U)
			{
				goto IL_24D;
			}
			IL_231:
			KeyValuePair<int, GClass18.Class8> keyValuePair;
			while (num << 0xE != 0U)
			{
				num = 0x80D5F8AU * num;
				bool flag2 = enumerator2.MoveNext();
				num ^= 0x3F342C1CU;
				if (flag2)
				{
					num = 0x799345CDU;
					keyValuePair = enumerator2.Current;
					goto IL_24D;
				}
				if (0x219D073FU <= num)
				{
					break;
				}
			}
			goto IL_2A9;
			IL_24D:
			num = 0x34B835E0U >> (int)num;
			GClass18.Class8 value2 = keyValuePair.Value;
			num >>= 2;
			object[] array4 = array;
			num = 0x4A9D3145U / num;
			value2.vmethod_2(array4[keyValuePair.Key]);
			num ^= 0x337FCEFEU;
			goto IL_231;
		}
		IL_2A9:
		return this.method_24(object_2, methodBase_0.DeclaringType);
	}

	// Token: 0x06001399 RID: 5017 RVA: 0x00095634 File Offset: 0x00093834
	private bool method_30(MethodBase methodBase_0, object object_0, ref object object_1, object[] object_2)
	{
		uint num;
		for (;;)
		{
			IL_00:
			Type declaringType = methodBase_0.DeclaringType;
			num = 0x525C56EU;
			if (declaringType == null)
			{
				break;
			}
			while (declaringType.IsGenericType)
			{
				Type genericTypeDefinition = declaringType.GetGenericTypeDefinition();
				num ^= 0x7C405746U;
				Type typeFromHandle = typeof(Nullable<>);
				num <<= 0xA;
				num ^= 0x936D656EU;
				if (genericTypeDefinition != typeFromHandle)
				{
					break;
				}
				num |= 0x6E9A0150U;
				string name = methodBase_0.Name;
				num = 0x7E17998U - num;
				string b = "get_HasValue";
				num = (0x70785114U ^ num);
				if (string.Equals(name, b, (StringComparison)(num ^ 0xE859E50AU)))
				{
					object obj = object_0;
					num >>= 6;
					object obj2 = obj != null;
					num *= 0x493144EAU;
					object_1 = obj2;
					if (0x27AF2784U < num)
					{
						goto IL_1BB;
					}
				}
				else
				{
					if (num == 0x2154413CU)
					{
						goto IL_00;
					}
					string name2 = methodBase_0.Name;
					num /= 0x372A6E10U;
					string b2 = "get_Value";
					num = (0x71A1131AU & num);
					StringComparison comparisonType = (int)num + StringComparison.Ordinal;
					num = (0x1A800081U & num);
					if (string.Equals(name2, b2, comparisonType))
					{
						goto IL_127;
					}
					bool flag = methodBase_0.Name.Equals("GetValueOrDefault", (StringComparison)(num - 0xFFFFFFFCU));
					num ^= 0x385FFD48U;
					if (!flag)
					{
						goto IL_1BB;
					}
					if (num != 0x682D138DU)
					{
						goto Block_7;
					}
					goto IL_00;
				}
			}
			goto IL_1CB;
		}
		return (num ^ 0x525C56EU) != 0U;
		Block_7:
		bool flag2 = object_0 != null;
		num = 0x307F516BU / num;
		if (!flag2)
		{
			num -= 0x281F4CBAU;
			num = (0x1D51515BU ^ num);
			Type declaringType2 = methodBase_0.DeclaringType;
			num = 0x2A6A36C6U << (int)num;
			Type underlyingType = Nullable.GetUnderlyingType(declaringType2);
			num = 0x3328084AU / num;
			object obj3 = Activator.CreateInstance(underlyingType);
			num <<= 8;
			object_0 = obj3;
			num += 0U;
		}
		num ^= 0x2F42687U;
		object_1 = object_0;
		num ^= 0x3AABDBCFU;
		goto IL_1BB;
		IL_127:
		if (object_0 == null)
		{
			num = 0x1B2E6F7AU * num;
			throw new InvalidOperationException();
		}
		num = (0x79E75D38U ^ num);
		object obj4 = object_0;
		num = 0x3C167065U + num;
		object_1 = obj4;
		num ^= 0x8DA230D5U;
		IL_1BB:
		num -= 0x49DA1B4FU;
		return num - 0xEE85E1F8U != 0U;
		IL_1CB:
		num /= 0x48CA3839U;
		return (num ^ 0U) != 0U;
	}

	// Token: 0x0600139A RID: 5018 RVA: 0x0009581C File Offset: 0x00093A1C
	private GClass18.Class8 method_31(MethodBase methodBase_0, bool bool_0)
	{
		uint num = 0x557552F5U;
		MethodInfo methodInfo2;
		Dictionary<int, GClass18.Class8> dictionary2;
		object[] array;
		object obj3;
		object obj4;
		object[] array6;
		Dictionary<MethodBase, DynamicMethod> obj6;
		for (;;)
		{
			IL_572:
			MethodInfo methodInfo = methodBase_0 as MethodInfo;
			num = 0x4E5F0D4EU * num;
			methodInfo2 = methodInfo;
			num = 0x18CE69C8U * num;
			GClass18.Class8 class2;
			for (;;)
			{
				IL_47C:
				num = (0x4A470D5BU | num);
				ParameterInfo[] parameters = methodBase_0.GetParameters();
				num /= 0x10F93CE6U;
				if (0x25607033U == num)
				{
					goto IL_1B9;
				}
				do
				{
					IL_19E:
					Dictionary<int, GClass18.Class8> dictionary = new Dictionary<int, GClass18.Class8>();
					num <<= 0x14;
					dictionary2 = dictionary;
				}
				while (0x48990EDCU - num == 0U);
				IL_1B9:
				int num2 = parameters.Length;
				num ^= 0x2D346E95U;
				array = new object[num2];
				ParameterInfo[] array2 = parameters;
				num = 0x62E54097U << (int)num;
				int num3 = array2.Length;
				num = 0x3553291DU % num;
				int num4 = num3;
				num = (0x91C1066U ^ num);
				int num5 = num4 - (int)(num - 0x68F397AU);
				num = 0x443552ABU % num;
				int num6 = num5;
				for (;;)
				{
					num = 0x36F50CF7U / num;
					uint num7 = (uint)num6;
					num = 0x40627FBBU / num;
					if (num7 < num + 0xFCEF1E7EU)
					{
						num = (0x34733A2EU ^ num);
						num &= 0x21D95D98U;
						bool isStatic = methodBase_0.IsStatic;
						num = 0x15A425B8U - num;
						GClass18.Class8 @class;
						if (!isStatic)
						{
							num = 0x4AD464B9U >> (int)num;
							@class = this.method_1();
						}
						else
						{
							num |= 0x35F4216CU;
							@class = null;
							num += 0xA095D58U;
						}
						class2 = @class;
						num = 0x3E234D5U * num;
						bool flag = class2 != null;
						num = 0x1C1005BU * num;
						if (!flag)
						{
							goto IL_20F;
						}
						num = 0x146063D3U % num;
						if (0x57172615U / num != 0U)
						{
							goto IL_212;
						}
					}
					else
					{
						class2 = this.method_1();
						GClass18.Class8 class3 = class2;
						num = 0x7584202FU;
						if (class3.vmethod_3())
						{
							Dictionary<int, GClass18.Class8> dictionary3 = dictionary2;
							num /= 0x5F40792EU;
							int key = num6;
							num = 0x45400889U / num;
							GClass18.Class8 value = class2;
							num = (0x2D1B2237U & num);
							dictionary3[key] = value;
							num += 0x7084202EU;
						}
						if (0x71AA42B2U > num)
						{
							goto IL_19E;
						}
						object[] array3 = array;
						num <<= 7;
						int num8 = num6;
						num |= 0x7A255DE3U;
						object object_ = class2;
						num &= 0x75214DB2U;
						ParameterInfo[] array4 = parameters;
						int num9 = num6;
						num = 0x2C915CA2U * num;
						Type parameterType = array4[num9].ParameterType;
						num = 0x28CE4C06U << (int)num;
						array3[num8] = this.method_24(object_, parameterType).vmethod_1();
						int num10 = num6 - (int)(num - 0x8CE4C05FU);
						num = 0x6197128FU % num;
						num6 = num10;
						num += 0xA106014EU;
					}
				}
				IL_223:
				object obj2;
				object obj;
				bool flag2 = (obj = obj2) != null;
				num = 0x3BCC6E38U >> (int)num;
				if (!flag2)
				{
					if (0x21A813CEU + num == 0U)
					{
						continue;
					}
					obj = null;
					num ^= 0U;
				}
				obj3 = obj;
				num = 0x2A11718EU / num;
				if (bool_0)
				{
					num -= 0x23B34482U;
					bool flag3 = obj3 != null;
					num ^= 0xDC4CCDFEU;
					if (!flag3)
					{
						goto IL_593;
					}
				}
				obj4 = null;
				num = 0x5645CBCU / num;
				if (num > 0xBDA4DC6U)
				{
					goto IL_572;
				}
				bool isConstructor = methodBase_0.IsConstructor;
				num *= 0x61A0154BU;
				if (isConstructor)
				{
					bool isValueType = methodBase_0.DeclaringType.IsValueType;
					num |= 0x201834E2U;
					num ^= 0x200800C2U;
					if (isValueType)
					{
						break;
					}
				}
				if (num < 0x9B4CB8U)
				{
					goto IL_572;
				}
				num = 0x4B54374EU + num;
				object object_2 = obj3;
				num = 0x441B701AU / num;
				object[] object_3 = array;
				num = 0x47B70C93U << (int)num;
				bool flag4 = this.method_30(methodBase_0, object_2, ref obj4, object_3);
				num += 0x672CEF9EU;
				if (flag4)
				{
					goto IL_AE2;
				}
				if (0x28996847U % num == 0U)
				{
					goto IL_572;
				}
				if (bool_0)
				{
					goto IL_AA5;
				}
				num >>= 9;
				bool isVirtual = methodBase_0.IsVirtual;
				num /= 0x70966E43U;
				num ^= 0xAEE3FC31U;
				if (!isVirtual)
				{
					goto IL_AA5;
				}
				if (num <= 0x8441542U)
				{
					continue;
				}
				num = (0x3FD6545U | num);
				bool isFinal = methodBase_0.IsFinal;
				num &= 0x390320F6U;
				num += 0x85E0DBBDU;
				if (isFinal)
				{
					goto IL_AA5;
				}
				if (num << 0xA == 0U)
				{
					goto IL_572;
				}
				ParameterInfo[] array5 = parameters;
				num |= 0x4F080552U;
				int num11 = array5.Length;
				num /= 0x67D6509CU;
				int num12 = num11 + (int)(num - 1U);
				num = (0x3CE32156U | num);
				array6 = new object[num12];
				if (0x48E1755DU + num == 0U)
				{
					goto IL_572;
				}
				object[] array7 = array6;
				num >>= 0xD;
				int num13 = (int)(num - 0x1E719U);
				num = (0x73835975U ^ num);
				object obj5 = obj3;
				num = 0x7D6B2612U << (int)num;
				array7[num13] = obj5;
				int num14 = (int)(num - 0xB2612000U);
				for (;;)
				{
					num <<= 3;
					if (num <= 0x16651988U)
					{
						goto IL_47C;
					}
					int num15 = num14;
					ParameterInfo[] array8 = parameters;
					num = 0x1D214C24U / num;
					int num16 = array8.Length;
					num <<= 0xE;
					if (num15 >= num16)
					{
						goto IL_55C;
					}
					array6[num14 + 1] = array[num14];
					num14++;
					num = 0xB2612000U;
				}
				IL_20F:
				obj2 = null;
				goto IL_223;
				IL_212:
				obj2 = class2.vmethod_1();
				num ^= 0x61842A5FU;
				goto IL_223;
			}
			num = 0x66360F10U / num;
			num = 0x39A332B2U + num;
			Type declaringType = methodBase_0.DeclaringType;
			num -= 0x6A5FBAU;
			obj3 = Activator.CreateInstance(declaringType, array);
			bool flag5 = class2 != null;
			num = 0x6AFF08F9U * num;
			if (!flag5)
			{
				goto IL_AE2;
			}
			bool flag6 = class2.vmethod_3();
			num ^= 0U;
			if (!flag6)
			{
				goto IL_AE2;
			}
			num = 0x322156FAU * num;
			GClass18.Class8 class4 = class2;
			num = 0xC7557E3U + num;
			num >>= 0x15;
			object object_4 = obj3;
			num = (0x8E47539U ^ num);
			GClass18.Class8 class5 = this.method_24(object_4, methodBase_0.DeclaringType);
			num ^= 0x73934D6CU;
			object object_5 = class5.vmethod_1();
			num += 0x2E040467U;
			class4.vmethod_2(object_5);
			if (0x3AE5048EU < num)
			{
				break;
			}
			continue;
			IL_55C:
			obj6 = GClass18.dictionary_2;
			if (0x60E55BCF << (int)num != 0)
			{
				goto IL_5B2;
			}
		}
		num += 0x568BB86U;
		goto IL_AE2;
		IL_593:
		num = 0x1275505DU / num;
		throw new NullReferenceException();
		IL_5B2:
		DynamicMethod dynamicMethod;
		lock (obj6)
		{
			num = 0x10B60A3EU + num;
			if (num == 0x7A994EAFU)
			{
				goto IL_90D;
			}
			do
			{
				IL_8CC:
				Dictionary<MethodBase, DynamicMethod> dictionary4 = GClass18.dictionary_2;
				num = 0x6F0869BDU % num;
				num = 0x2B2B1895U * num;
				num = 0x74947ECFU / num;
				bool flag7 = dictionary4.TryGetValue(methodBase_0, out dynamicMethod);
				num |= 0x293E16F9U;
				if (flag7)
				{
					goto IL_903;
				}
				num = 0x5E380665U + num;
			}
			while (num == 0x40277BAAU);
			Type[] array11;
			for (;;)
			{
				IL_90D:
				object[] array9 = array6;
				num = (0x6B9755DFU | num);
				int num17 = array9.Length;
				num = (0x75D17C30U & num);
				int num18 = num17;
				num = 0x5F050326U % num;
				Type[] array10 = new Type[num18];
				num += 0x3B161F9BU;
				array11 = array10;
				Type[] array12 = array11;
				int num19 = (int)(num + 0x65E4DD3FU);
				num = 0x36540404U << (int)num;
				array12[num19] = methodBase_0.DeclaringType;
				int num20 = (int)(num ^ 0x6CA80808U);
				num <<= 0x1C;
				int num21 = num20;
				for (;;)
				{
					int num22 = num21;
					ParameterInfo[] parameters;
					ParameterInfo[] array13 = parameters;
					num = 0x6C7214E5U << (int)num;
					int num23 = array13.Length;
					num &= 0x743356BAU;
					int num24 = num23;
					num %= 0x3D2F4FE3U;
					if (num22 >= num24)
					{
						break;
					}
					array11[num21 + 1] = parameters[num21].ParameterType;
					num21++;
					num = 0x80000000U;
				}
				if (0x50F01B29U - num != 0U)
				{
					string name = "";
					num = 0x67055705U + num;
					if (methodInfo2 == null)
					{
						goto IL_6BA;
					}
					num = 0x16FF0CCEU / num;
					MethodInfo methodInfo3 = methodInfo2;
					num &= 0x3B437122U;
					Type returnType = methodInfo3.ReturnType;
					num = 0x714D74E8U - num;
					RuntimeTypeHandle handle = typeof(void).TypeHandle;
					num &= 0x41331E5DU;
					if (returnType == Type.GetTypeFromHandle(handle))
					{
						num += 0x4D07077AU;
						goto IL_6BA;
					}
					Type returnType2 = methodInfo2.ReturnType;
					num ^= 0x4501050AU;
					IL_6C5:
					Type[] parameterTypes = array11;
					Type typeFromHandle = typeof(GClass18);
					num = (0x3CD533D4U & num);
					Module module = typeFromHandle.Module;
					num <<= 6;
					bool skipVisibility = (num ^ 0x45001U) != 0U;
					num %= 0x419B0E89U;
					dynamicMethod = new DynamicMethod(name, returnType2, parameterTypes, module, skipVisibility);
					num = 0x3C2422DFU << (int)num;
					if (num >= 0x22DA3BD7U)
					{
						break;
					}
					continue;
					IL_6BA:
					num = (0x5351146U & num);
					returnType2 = null;
					goto IL_6C5;
				}
				goto IL_8CC;
			}
			DynamicMethod dynamicMethod2 = dynamicMethod;
			num |= 0x79131BDAU;
			ILGenerator ilgenerator = dynamicMethod2.GetILGenerator();
			num -= 0x57267231U;
			ILGenerator ilgenerator2 = ilgenerator;
			num = 0x33A30E16U / num;
			GClass18.Class8 class2;
			GClass18.Class8 class6 = class2;
			num = 0x586E7766U << (int)num;
			OpCode opcode;
			if (!class6.vmethod_3())
			{
				opcode = OpCodes.Ldarg;
			}
			else
			{
				opcode = OpCodes.Ldarga;
				num += 0U;
			}
			ilgenerator2.Emit(opcode, (int)(num ^ 0xB0DCEECCU));
			int num25 = (int)(num ^ 0xB0DCEECDU);
			for (;;)
			{
				int num26 = num25;
				num = 0x549A6F98U + num;
				if (num26 >= array11.Length)
				{
					break;
				}
				ILGenerator ilgenerator3 = ilgenerator;
				Dictionary<int, GClass18.Class8> dictionary5 = dictionary2;
				int num27 = num25;
				int num28 = 1;
				num = 0x20032B03U;
				OpCode opcode2;
				if (!dictionary5.ContainsKey(num27 - num28))
				{
					num >>= 0x1F;
					opcode2 = OpCodes.Ldarg;
				}
				else
				{
					opcode2 = OpCodes.Ldarga;
					num += 0xDFFCD4FDU;
				}
				num ^= 0x425018E4U;
				int arg = num25;
				num ^= 0x4576162CU;
				ilgenerator3.Emit(opcode2, arg);
				if (0x3A945E8FU >> (int)num == 0U)
				{
					goto IL_8CC;
				}
				int num29 = num25;
				num = (0x27381568U | num);
				num25 = num29 + (int)(num + 0xD8C1E019U);
				num ^= 0x97E2F124U;
			}
			ILGenerator ilgenerator4 = ilgenerator;
			num >>= 0;
			OpCode call = OpCodes.Call;
			num <<= 6;
			MethodInfo meth = methodInfo2;
			num = (0x6830738U & num);
			ilgenerator4.Emit(call, meth);
			num <<= 0xC;
			if (num + 0x5FB737A1U == 0U)
			{
				goto IL_8CC;
			}
			ILGenerator ilgenerator5 = ilgenerator;
			num = 0x6612BCAU * num;
			ilgenerator5.Emit(OpCodes.Ret);
			if (0x5EEC79E3U + num == 0U)
			{
				goto IL_8CC;
			}
			Dictionary<MethodBase, DynamicMethod> dictionary6 = GClass18.dictionary_2;
			num |= 0x500A35CFU;
			dictionary6[methodBase_0] = dynamicMethod;
			num += 0x4C93E12AU;
			IL_903:
			if ((0xE893C73U ^ num) == 0U)
			{
				goto IL_90D;
			}
		}
		obj4 = dynamicMethod.Invoke(null, array6);
		num = 0x1B57912CU;
		using (Dictionary<int, GClass18.Class8>.Enumerator enumerator = dictionary2.GetEnumerator())
		{
			if (num << 1 == 0U)
			{
				goto IL_A09;
			}
			IL_9E0:
			KeyValuePair<int, GClass18.Class8> keyValuePair;
			while (num <= 0x416670E8U)
			{
				bool flag8 = enumerator.MoveNext();
				num = 0xB012E16U * num;
				if (flag8)
				{
					keyValuePair = enumerator.Current;
					num = 0x397CCC4BU;
					break;
				}
				if (0x6E653ADEU - num != 0U)
				{
					goto IL_A87;
				}
			}
			IL_A09:
			GClass18.Class8 value2 = keyValuePair.Value;
			object[] array14 = array6;
			num = (0x292B7FBDU ^ num);
			num ^= 0x339A0FAEU;
			int key2 = keyValuePair.Key;
			int num30 = (int)(num - 0x23CDBC57U);
			num %= 0x113A56E5U;
			int num31 = key2 + num30;
			num = (0x7BD40A37U ^ num);
			object object_6 = array14[num31];
			num = 0x5DA72644U % num;
			value2.vmethod_2(object_6);
			num ^= 0x46F0B768U;
			goto IL_9E0;
		}
		IL_A87:
		dictionary2.Clear();
		num = 0xAEE3FC31U;
		goto IL_AE2;
		IL_AA5:
		num = (0x32344CBCU ^ num);
		num = 0x380D6972U - num;
		object obj7 = obj3;
		num <<= 0xA;
		object[] parameters2 = array;
		num -= 0x15D54563U;
		obj4 = methodBase_0.Invoke(obj7, parameters2);
		num ^= 0x6FEDB2ACU;
		IL_AE2:
		num = 0x2AC912A7U / num;
		Dictionary<int, GClass18.Class8> dictionary7 = dictionary2;
		num = (0x434E1BF9U & num);
		using (Dictionary<int, GClass18.Class8>.Enumerator enumerator = dictionary7.GetEnumerator())
		{
			if ((0x33ED1F00U ^ num) != 0U)
			{
			}
			for (;;)
			{
				num = 0x6002047FU + num;
				if (!enumerator.MoveNext())
				{
					break;
				}
				KeyValuePair<int, GClass18.Class8> keyValuePair2 = enumerator.Current;
				keyValuePair2.Value.vmethod_2(array[keyValuePair2.Key]);
				num = 0U;
			}
		}
		if (methodInfo2 != null)
		{
			num = 0x14BB7E61U;
			for (;;)
			{
				Type returnType3 = methodInfo2.ReturnType;
				num ^= 0x28C7361CU;
				Type typeFromHandle2 = typeof(void);
				num = (0x20EC4F10U & num);
				if (returnType3 == typeFromHandle2)
				{
					break;
				}
				if ((num ^ 0x12D70BA9U) != 0U)
				{
					goto IL_BAC;
				}
			}
			goto IL_BC6;
			IL_BAC:
			object object_7 = obj4;
			Type returnType4 = methodInfo2.ReturnType;
			num <<= 0x1A;
			return this.method_24(object_7, returnType4);
		}
		IL_BC6:
		return null;
	}

	// Token: 0x0600139B RID: 5019 RVA: 0x00096444 File Offset: 0x00094644
	private GClass18.Class8 method_32(int int_1, bool bool_0)
	{
		uint num2;
		Dictionary<int, GClass18.Class8> dictionary;
		object[] array;
		int num13;
		object obj2;
		for (;;)
		{
			IL_00:
			int num = this.int_0;
			for (;;)
			{
				this.int_0 = int_1;
				num2 = 0x3DE85C1CU;
				ushort num4;
				do
				{
					ushort num3 = (ushort)this.method_4();
					num2 = 0x63670A9AU - num2;
					num4 = num3;
					dictionary = new Dictionary<int, GClass18.Class8>();
					array = null;
				}
				while (0x624070B2U + num2 == 0U);
				uint num5 = (uint)num4;
				num2 >>= 0x18;
				if (num5 > (num2 ^ 0x25U))
				{
					object[] array2 = new object[(int)num4];
					num2 /= 0x354550B3U;
					array = array2;
					num2 = (0x103E7894U & num2);
					if (0x14A676F0U <= num2)
					{
						goto IL_00;
					}
					int num6 = (int)num4;
					num2 /= 0x7E7D2C09U;
					int num7 = num6 - (int)(num2 + 1U);
					num2 <<= 7;
					int num8 = num7;
					for (;;)
					{
						uint num9 = (uint)num8;
						num2 = 0x464F6FF6U >> (int)num2;
						if (num9 < (num2 ^ 0x464F6FF6U))
						{
							break;
						}
						GClass18.Class8 @class = this.method_1();
						GClass18.Class8 class2 = @class;
						num2 = 0x2600000U;
						if (class2.vmethod_3())
						{
							num2 >>= 0x17;
							if ((num2 & 0x1AF47F89U) != 0U)
							{
								goto IL_00;
							}
							Dictionary<int, GClass18.Class8> dictionary2 = dictionary;
							int key = num8;
							num2 %= 0x3E501B77U;
							GClass18.Class8 value = @class;
							num2 /= 0x5D7A1688U;
							dictionary2[key] = value;
							num2 ^= 0x2600000U;
						}
						num2 /= 0x71F61BB4U;
						object[] array3 = array;
						int num10 = num8;
						num2 = 0x609E1F70U << (int)num2;
						num2 = 0x7D95ACEU >> (int)num2;
						object object_ = @class;
						num2 = 0x361648F6U % num2;
						Type type_ = this.method_26(this.method_5());
						num2 = 0x75044295U - num2;
						GClass18.Class8 class3 = this.method_24(object_, type_);
						num2 = 0x43FF1EC9U << (int)num2;
						object obj = class3.vmethod_1();
						num2 = 0x2CFB7EAEU * num2;
						array3[num10] = obj;
						num2 ^= 0x60367607U;
						if (num2 == 0x538517DBU)
						{
							goto IL_00;
						}
						int num11 = num8 - (int)(num2 ^ 0xD50A7606U);
						num2 = 0x9CD7E6CU >> (int)num2;
						num8 = num11;
						num2 ^= 0x139AFCU;
					}
					num2 ^= 0x464F6FD3U;
				}
				num2 = 0x3A363AA3U >> (int)num2;
				int num12 = this.method_5();
				num2 -= 0x7442BF5U;
				num13 = num12;
				if ((num2 ^ 0x73C344CAU) == 0U)
				{
					goto IL_00;
				}
				num2 = 0x286A347EU + num2;
				int num14 = this.int_0;
				num2 ^= 0x72651D21U;
				int_1 = num14;
				num2 ^= 0x4F46249FU;
				int num15 = num;
				num2 = 0x36FB57E8U / num2;
				this.int_0 = num15;
				if ((num2 ^ 0x1FD53683U) == 0U)
				{
					goto IL_00;
				}
				num2 <<= 0x15;
				if (!bool_0)
				{
					break;
				}
				if (array == null)
				{
					goto IL_30E;
				}
				if (num2 + 0x733E5DDFU != 0U)
				{
					goto IL_289;
				}
			}
			IL_2B4:
			num2 = 0x5C41434U / num2;
			GClass18 gclass = new GClass18();
			num2 %= 0x4D4B3749U;
			object[] object_2 = array;
			num2 >>= 0xC;
			int int_2 = int_1;
			num2 -= 0x7EAE5632U;
			obj2 = gclass.method_112(object_2, int_2);
			num2 = 0x527B44DEU - num2;
			if (num2 - 0x75277BDFU != 0U)
			{
				break;
			}
			continue;
			IL_289:
			object[] array4 = array;
			num2 = 0x4FE03138U % num2;
			bool flag = array4[(int)(num2 ^ 0x3138U)];
			num2 ^= 0x6D2E3410U;
			num2 += 0x92F1FAD8U;
			if (flag)
			{
				goto IL_2B4;
			}
			goto IL_304;
		}
		using (Dictionary<int, GClass18.Class8>.Enumerator enumerator = dictionary.GetEnumerator())
		{
			if (0x7447C89U >> (int)num2 == 0U)
			{
				goto IL_34D;
			}
			IL_32C:
			num2 <<= 0x16;
			if (!enumerator.MoveNext())
			{
				goto IL_3E6;
			}
			IL_34D:
			KeyValuePair<int, GClass18.Class8> keyValuePair = enumerator.Current;
			keyValuePair.Value.vmethod_2(array[keyValuePair.Key]);
			num2 = 0xD1299B10U;
			goto IL_32C;
		}
		IL_3B4:
		num2 /= 0x677B57B2U;
		int int_3 = num13;
		num2 += 0x28B209BAU;
		Type type = this.method_26(int_3);
		num2 = 0x48DD4081U * num2;
		if (0xC3228A4U != num2)
		{
			Type type2 = type;
			num2 = (0x5B01582EU ^ num2);
			Type typeFromHandle = typeof(void);
			num2 ^= 0xE3363E94U;
			if (type2 != typeFromHandle)
			{
				num2 /= 0x4F26376AU;
				goto IL_43D;
			}
			goto IL_427;
		}
		IL_3E6:
		bool flag2 = num13 != 0;
		num2 = 0x1800000U;
		if (flag2)
		{
			goto IL_3B4;
		}
		IL_427:
		num2 = 0x5DA85CD5U / num2;
		if (0x6E014E26U - num2 != 0U)
		{
			return null;
		}
		IL_43D:
		num2 &= 0x53BE4CE9U;
		object object_3 = obj2;
		num2 = (0x2C5A35C0U ^ num2);
		return this.method_24(object_3, type);
		IL_304:
		num2 ^= 0U;
		IL_30E:
		throw new NullReferenceException();
	}

	// Token: 0x0600139C RID: 5020 RVA: 0x000968BC File Offset: 0x00094ABC
	private bool method_33(object object_0, Type type_1)
	{
		uint num = 0x1D2345D0U;
		if (object_0 != null && (0x5699430BU ^ num) != 0U)
		{
			num = 0x53A45900U % num;
			Type type = object_0.GetType();
			num |= 0x4BDE7665U;
			Type type2 = type;
			Type type3 = type2;
			num <<= 8;
			if (type3 != type_1)
			{
				num = 0x4D564E55U % num;
				Type c = type2;
				num += 0xF1C1FA3U;
				if (!type_1.IsAssignableFrom(c))
				{
					return num + 0xA38D9208U != 0U;
				}
				num += 0x838CF708U;
			}
			num &= 0x77785275U;
			return num + 0xA887C001U != 0U;
		}
		num = 0x59D04DE7U - num;
		return (num ^ 0x3CAD0816U) != 0U;
	}

	// Token: 0x0600139D RID: 5021 RVA: 0x00096950 File Offset: 0x00094B50
	private void method_34(Exception exception_1)
	{
		uint num;
		GClass18.Class37 class2;
		for (;;)
		{
			IL_00:
			this.stack_0.Clear();
			num = 0x71630E97U;
			for (;;)
			{
				IL_440:
				num ^= 0x1ABD1D69U;
				this.stack_2.Clear();
				for (;;)
				{
					IL_3A5:
					bool flag = this.class37_0 != null;
					num = (0x722E7AB4U & num);
					if (!flag)
					{
						num ^= 0x31503782U;
						this.exception_0 = exception_1;
						num ^= 0x31503782U;
					}
					IL_37B:
					while (num / 0xC305C98U != 0U)
					{
						Stack<GClass18.Class38> stack = this.stack_1;
						num = 0x73CE5515U >> (int)num;
						bool count = stack.Count != 0;
						num = 0x63AC7970U << (int)num;
						if (!count)
						{
							goto IL_3B7;
						}
						List<GClass18.Class37> list = this.stack_1.Peek().method_4();
						bool flag2 = this.class37_0 != null;
						num = 0x3BB72EEEU;
						int num2;
						if (flag2)
						{
							if (num / 0x1A1A04E9U == 0U)
							{
								goto IL_00;
							}
							List<GClass18.Class37> list2 = list;
							num &= 0x3889442BU;
							GClass18.Class37 item = this.class37_0;
							num = 0xADA7BE5U % num;
							num2 = list2.IndexOf(item) + (int)(num + 0xF525841CU);
						}
						else
						{
							num %= 0x45E747CEU;
							num2 = (int)(num ^ 0x3BB72EEEU);
							num ^= 0x316D550BU;
						}
						num /= 0x570D34DFU;
						num &= 0x29EE3ECAU;
						GClass18.Class37 @class = null;
						num = 0x56D3656EU << (int)num;
						this.class37_0 = @class;
						num %= 0x7DC22739U;
						int num3 = num2;
						if (0x72E1477CU >= num)
						{
							while (0x52B34439U != num)
							{
								int num4 = num3;
								num = 0xF3A4946U * num;
								if (num4 < list.Count)
								{
									class2 = list[num3];
									byte b = class2.method_0();
									num = 0x95502102U;
									if (b != 0)
									{
										byte b2 = b;
										num >>= 0x1F;
										uint num5 = num - 0U;
										num %= 0x6854C69U;
										if (b2 == num5)
										{
											goto IL_45B;
										}
									}
									else
									{
										if (num <= 0x4CF01B2EU)
										{
											goto IL_00;
										}
										Type type = exception_1.GetType();
										num = (0x62497079U & num);
										if (num << 0x1F != 0U)
										{
											goto IL_00;
										}
										int int_ = class2.method_2();
										num = 0x6F2A4DE4U % num;
										Type type2 = this.method_26(int_);
										num += 0xD4A2610U;
										Type type3 = type2;
										if (0x505577A8U <= num)
										{
											goto IL_3A5;
										}
										Type type4 = type;
										num &= 0x310332D7U;
										Type type5 = type3;
										num = (0xB845854U & num);
										if (type4 == type5)
										{
											goto IL_418;
										}
										if (0x20D6124FU * num == 0U)
										{
											goto IL_3A5;
										}
										Type type6 = type;
										num = 0x1BE31AACU / num;
										bool flag3 = type6.IsSubclassOf(type3);
										num += 0xFFFFFFE6U;
										if (flag3)
										{
											goto IL_410;
										}
									}
									num = 0x57221B5CU * num;
									int num6 = num3;
									num %= 0x2EE244CAU;
									int num7 = num6 + (int)(num - 0x283FD691U);
									num = 0x7EC25B73U >> (int)num;
									num3 = num7;
									num ^= 0x56D37ADEU;
								}
								else
								{
									Stack<GClass18.Class38> stack2 = this.stack_1;
									num = 0x200C25C5U >> (int)num;
									stack2.Pop();
									num = 0x241629FU * num;
									num /= 0x333003U;
									int num8 = list.Count;
									for (;;)
									{
										num += 0x203F21B6U;
										if (num <= 0x20252157U)
										{
											goto IL_00;
										}
										if (num8 > (int)(num - 0x203F2444U))
										{
											GClass18.Class37 class3 = list[num8 - 1];
											GClass18.Class37 class4 = class3;
											num = 0x24A22238U;
											if (class4.method_0() == 2)
											{
												goto IL_2DC;
											}
											num = 0xBD63E36U - num;
											if (num == 0x118F5D91U)
											{
												goto IL_00;
											}
											if ((uint)class3.method_0() == num + 0x18CBE406U)
											{
												num ^= 0xC39639C6U;
												goto IL_2DC;
											}
											IL_30E:
											if (0x1DC9342DU <= num)
											{
												int num9 = num8;
												num <<= 1;
												num8 = num9 - (int)(num - 0xCE6837FBU);
												num += 0x3197CA92U;
												continue;
											}
											goto IL_00;
											IL_2DC:
											num /= 0x424E5BBDU;
											Stack<int> stack3 = this.stack_2;
											num = (0xFA54CB8U ^ num);
											int item2 = class3.method_1();
											num = 0x7F3E4AD6U * num;
											stack3.Push(item2);
											num ^= 0x5FDF4A2EU;
											goto IL_30E;
										}
										break;
									}
									num = 0x6D780204U * num;
									if (0x7D490235U == num)
									{
										break;
									}
									num = 0x5B004581U - num;
									bool count2 = this.stack_2.Count != 0;
									num += 0xFA32E643U;
									if (!count2)
									{
										goto IL_37B;
									}
									goto IL_3CC;
								}
							}
							break;
						}
						goto IL_00;
					}
					goto IL_440;
				}
				IL_3B7:
				num = 0x6ABD0BFAU * num;
				if (0x2FA87EF6U >= num)
				{
					goto Block_22;
				}
				continue;
				IL_3CC:
				if (num <= 0x3CE11C44U)
				{
					break;
				}
				num /= 0x2A3875F8U;
				Stack<int> stack4 = this.stack_2;
				num = 0x4E8D06CCU * num;
				int num10 = stack4.Pop();
				num = 0x7026E26U >> (int)num;
				this.int_0 = num10;
				if (0x5AF714FCU != num)
				{
					return;
				}
				continue;
				IL_418:
				num = (0x4FDB3484U ^ num);
				this.stack_1.Pop();
				num = 0xA4A1F87U * num;
				if ((0x77803890U & num) == 0U)
				{
					continue;
				}
				goto IL_4CD;
				IL_410:
				num += 0x1001053U;
				goto IL_418;
			}
		}
		Block_22:
		throw exception_1;
		IL_45B:
		GClass18.Class37 class5 = class2;
		num ^= 0xE9A60F3U;
		this.class37_0 = class5;
		num *= 0x1604459DU;
		num = 0x256F5C1AU + num;
		Stack<GClass18.Class9> stack5 = this.stack_0;
		num = 0x56163135U - num;
		GClass18.Class9 item3 = new GClass18.Class15(this.exception_0);
		num = 0x793C1309U >> (int)num;
		stack5.Push(item3);
		num = 0x1F8D5EF6U * num;
		GClass18.Class37 class6 = class2;
		num += 0x7A670AC7U;
		int num11 = class6.method_2();
		num &= 0x6E34153FU;
		this.int_0 = num11;
		return;
		IL_4CD:
		num = (0x219D702DU ^ num);
		Stack<GClass18.Class9> stack6 = this.stack_0;
		object object_ = this.exception_0;
		num *= 0x17A91294U;
		GClass18.Class9 item4 = new GClass18.Class15(object_);
		num = 0x5F951EF0U << (int)num;
		stack6.Push(item4);
		num &= 0x588B367DU;
		num &= 0x4CDE22CBU;
		GClass18.Class37 class7 = class2;
		num |= 0x601071CEU;
		int num12 = class7.method_1();
		num = (0x635A785DU | num);
		this.int_0 = num12;
	}

	// Token: 0x0600139E RID: 5022 RVA: 0x00096E8C File Offset: 0x0009508C
	private void method_35()
	{
		Type type = this.method_26(this.method_1().vmethod_10());
		uint num = 2U;
		Type type_ = type;
		GClass18.Class8 @class = this.method_1();
		do
		{
			object object_ = this.method_1().vmethod_1();
			num -= 0x31250CF8U;
			GClass18.Class8 class2 = this.method_24(object_, type_);
			num = 0x63936A2BU - num;
			bool flag = @class.vmethod_3();
			num = (0x79EF6F08U & num);
			if (flag)
			{
				GClass18.Class8 class8_ = class2;
				num -= 0xA674D3DU;
				GClass18.Class8 class3 = new GClass18.Class21(class8_, @class);
				num *= 0x6B45400BU;
				class2 = class3;
				num += 0x12DC8B9FU;
			}
			num = 0x4015773DU >> (int)num;
			this.list_0.Add(class2);
		}
		while (0x7B8731B2U < num);
	}

	// Token: 0x0600139F RID: 5023 RVA: 0x00096F38 File Offset: 0x00095138
	private void method_36()
	{
		int num = this.method_1().vmethod_10();
		List<GClass18.Class38> list = this.list_1;
		uint num2 = 0x6C712927U;
		using (List<GClass18.Class38>.Enumerator enumerator = list.GetEnumerator())
		{
			do
			{
				for (;;)
				{
					IL_9D:
					num2 = 0x1FE7774DU + num2;
					if (num2 >= 0x63C45975U)
					{
						num2 = 0xAA40E44U * num2;
						if (!enumerator.MoveNext())
						{
							break;
						}
						GClass18.Class38 @class = enumerator.Current;
						num2 = 0x55776E3AU;
						do
						{
							GClass18.Class38 class2 = @class;
							num2 %= 0x1CEC7660U;
							int num3 = class2.method_0();
							int num4 = num;
							num2 += 0x50D2A7ADU;
							if (num3 != num4)
							{
								goto IL_9D;
							}
						}
						while (num2 > 0x71282869U);
						num2 %= 0x6375438U;
						Stack<GClass18.Class38> stack = this.stack_1;
						num2 = (0x4B822E1U & num2);
						GClass18.Class38 item = @class;
						num2 += 0x329B5204U;
						stack.Push(item);
						num2 += 0x3955D6C2U;
					}
				}
			}
			while (num2 == 0x1A9519C8U);
		}
	}

	// Token: 0x060013A0 RID: 5024 RVA: 0x0000C479 File Offset: 0x0000A679
	private void method_37()
	{
		this.method_0(new GClass18.Class10(this.method_5()));
	}

	// Token: 0x060013A1 RID: 5025 RVA: 0x0000C48C File Offset: 0x0000A68C
	private void method_38()
	{
		this.method_0(new GClass18.Class11(this.method_6()));
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x0000C49F File Offset: 0x0000A69F
	private void method_39()
	{
		this.method_0(new GClass18.Class12(this.method_7()));
	}

	// Token: 0x060013A3 RID: 5027 RVA: 0x00097028 File Offset: 0x00095228
	private void method_40()
	{
		uint num = 0x16476A1BU;
		do
		{
			num = 0x32437B75U * num;
			num += 0x79F52D70U;
			this.method_0(new GClass18.Class13(this.method_8()));
		}
		while (0xEB44970U == num);
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x0000C4B2 File Offset: 0x0000A6B2
	private void method_41()
	{
		this.method_0(new GClass18.Class15(null));
	}

	// Token: 0x060013A5 RID: 5029 RVA: 0x0000C4C0 File Offset: 0x0000A6C0
	private void method_42()
	{
		this.method_0(new GClass18.Class14(this.method_25(this.method_1().vmethod_10())));
	}

	// Token: 0x060013A6 RID: 5030 RVA: 0x00097064 File Offset: 0x00095264
	private void method_43()
	{
		uint num = 0x7DBE7375U;
		do
		{
			GClass18.Class8 class8_ = this.method_2().vmethod_0();
			num <<= 0x15;
			this.method_0(class8_);
		}
		while (num > 0x75552A08U);
	}

	// Token: 0x060013A7 RID: 5031 RVA: 0x00097098 File Offset: 0x00095298
	private void method_44()
	{
		GClass18.Class8 class8_ = this.method_1();
		uint num = 0x2F7B0188U;
		do
		{
			num |= 0x19A9739CU;
			GClass18.Class8 class8_2 = this.method_1();
			num = (0x6EEC7630U ^ num);
			num = 0x11976626U / num;
			GClass18.Class8 class8_3 = this.method_11(class8_, class8_2, (num ^ 0U) != 0U, (num ^ 0U) != 0U);
			num <<= 4;
			this.method_0(class8_3);
		}
		while (0x200E1DD9U <= num);
	}

	// Token: 0x060013A8 RID: 5032 RVA: 0x00097100 File Offset: 0x00095300
	private void method_45()
	{
		GClass18.Class8 @class = this.method_1();
		uint num = 0x32E16D08U;
		GClass18.Class8 class2 = this.method_1();
		do
		{
			num = 0x5F4E4A84U << (int)num;
			GClass18.Class8 class8_ = @class;
			GClass18.Class8 class8_2 = class2;
			bool bool_ = (num ^ 0x4E4A8401U) != 0U;
			num = 0x76FB7936U << (int)num;
			bool bool_2 = (num ^ 0x76FB7936U) != 0U;
			num %= 0x3472D4DU;
			this.method_0(this.method_11(class8_, class8_2, bool_, bool_2));
		}
		while (num * 0x46C12035U == 0U);
	}

	// Token: 0x060013A9 RID: 5033 RVA: 0x00097178 File Offset: 0x00095378
	private void method_46()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_11(class8_, class8_2, true, true));
	}

	// Token: 0x060013AA RID: 5034 RVA: 0x000971A4 File Offset: 0x000953A4
	private void method_47()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_12(class8_2, class8_, false, false));
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x000971D0 File Offset: 0x000953D0
	private void method_48()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_12(class8_2, class8_, true, false));
	}

	// Token: 0x060013AC RID: 5036 RVA: 0x000971FC File Offset: 0x000953FC
	private void method_49()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_12(class8_2, class8_, true, true));
	}

	// Token: 0x060013AD RID: 5037 RVA: 0x00097228 File Offset: 0x00095428
	private void method_50()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_13(class8_2, class8_, false, false));
	}

	// Token: 0x060013AE RID: 5038 RVA: 0x00097254 File Offset: 0x00095454
	private void method_51()
	{
		uint num = 0x2BE67DA7U;
		for (;;)
		{
			GClass18.Class8 @class = this.method_1();
			num = 0x757F150CU - num;
			GClass18.Class8 class2 = @class;
			GClass18.Class8 class3 = this.method_1();
			num |= 0x3BAC4DE2U;
			GClass18.Class8 class4 = class3;
			num >>= 0xE;
			if (num + 0x6BC13FB5U != 0U)
			{
				num *= 0xB9E0295U;
				num = 0x4F9D705CU * num;
				GClass18.Class8 class8_ = class4;
				num -= 0x11425159U;
				GClass18.Class8 class8_2 = class2;
				bool bool_ = (num ^ 0xE30EE28AU) != 0U;
				bool bool_2 = (num ^ 0xE30EE28BU) != 0U;
				num = (0x136F714AU | num);
				GClass18.Class8 class8_3 = this.method_13(class8_, class8_2, bool_, bool_2);
				num = (0x4C4100A5U ^ num);
				this.method_0(class8_3);
				if (num >= 0x6DDA0E9EU)
				{
					break;
				}
			}
		}
	}

	// Token: 0x060013AF RID: 5039 RVA: 0x000972E8 File Offset: 0x000954E8
	private void method_52()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_13(class8_2, class8_, true, true));
	}

	// Token: 0x060013B0 RID: 5040 RVA: 0x00097314 File Offset: 0x00095514
	private void method_53()
	{
		GClass18.Class8 @class = this.method_1();
		uint num = 0x2B20AU;
		do
		{
			GClass18.Class8 class2 = this.method_1();
			num = 0x7CAA5016U / num;
			GClass18.Class8 class3 = class2;
			num += 0x507E63B4U;
			GClass18.Class8 class8_ = class3;
			GClass18.Class8 class8_2 = @class;
			bool bool_ = (num ^ 0x507E91F4U) != 0U;
			num /= 0x370B7020U;
			this.method_0(this.method_14(class8_, class8_2, bool_));
		}
		while (num >= 0x6CC09F7U);
	}

	// Token: 0x060013B1 RID: 5041 RVA: 0x00097378 File Offset: 0x00095578
	private void method_54()
	{
		uint num = 0x3D186740U;
		GClass18.Class8 class8_;
		GClass18.Class8 class3;
		do
		{
			GClass18.Class8 @class = this.method_1();
			num = 0x141827D5U % num;
			class8_ = @class;
			if (0x514F46E3U < num)
			{
				break;
			}
			num = 0x44794D36U >> (int)num;
			GClass18.Class8 class2 = this.method_1();
			num &= 0x22055EAAU;
			class3 = class2;
			num = 0x37854016U - num;
		}
		while (num <= 0xDE66F36U);
		do
		{
			num = (0x152E3941U ^ num);
			GClass18.Class8 class8_2 = class3;
			num = 0x3B747E7BU >> (int)num;
			GClass18.Class8 class8_3 = this.method_14(class8_2, class8_, (num ^ 0x1DAU) != 0U);
			num = (0x4D326BB6U | num);
			this.method_0(class8_3);
		}
		while (num <= 0x11A740B0U);
	}

	// Token: 0x060013B2 RID: 5042 RVA: 0x0009740C File Offset: 0x0009560C
	private void method_55()
	{
		uint num = 0x1FFC781FU;
		for (;;)
		{
			num /= 0x7CD5E2BU;
			GClass18.Class8 @class = this.method_1();
			num = (0x411B1220U & num);
			GClass18.Class8 class2 = @class;
			if (num < 0x5AE34697U)
			{
				num += 0x70F23CA8U;
				GClass18.Class8 class3 = this.method_1();
				num = (0x43D262B9U ^ num);
				num >>= 1;
				GClass18.Class8 class8_ = class3;
				GClass18.Class8 class8_2 = class2;
				num ^= 0x25E26DA1U;
				bool bool_ = (num ^ 0x3C7242A9U) != 0U;
				num = 0x26205FDFU % num;
				this.method_0(this.method_15(class8_, class8_2, bool_));
				if ((0xC312719U & num) != 0U)
				{
					break;
				}
			}
		}
	}

	// Token: 0x060013B3 RID: 5043 RVA: 0x00097490 File Offset: 0x00095690
	private void method_56()
	{
		GClass18.Class8 @class = this.method_1();
		GClass18.Class8 class2 = this.method_1();
		uint num = 0x70000000U;
		GClass18.Class8 class3 = class2;
		do
		{
			GClass18.Class8 class8_ = class3;
			GClass18.Class8 class8_2 = @class;
			num |= 0x39A03BB5U;
			bool bool_ = (num ^ 0x79A03BB4U) != 0U;
			num = 0x2C1E4058U + num;
			GClass18.Class8 class8_3 = this.method_15(class8_, class8_2, bool_);
			num /= 0x3016520EU;
			this.method_0(class8_3);
		}
		while ((0x247C4ABEU ^ num) == 0U);
	}

	// Token: 0x060013B4 RID: 5044 RVA: 0x000974F4 File Offset: 0x000956F4
	private void method_57()
	{
		GClass18.Class8 @class = this.method_1();
		uint num = 8U;
		GClass18.Class8 class8_ = @class;
		do
		{
			num = 0x7D927D83U / num;
			GClass18.Class8 class2 = this.method_1();
			num = 0x13DA57AFU * num;
			num = 0x81D6D6EU / num;
			num += 0xB766D4EU;
			GClass18.Class8 class8_2 = class2;
			num |= 0x64FC648BU;
			this.method_0(this.method_18(class8_2, class8_));
		}
		while (num % 0xE0D138EU == 0U);
	}

	// Token: 0x060013B5 RID: 5045 RVA: 0x0009755C File Offset: 0x0009575C
	private void method_58()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_17(class8_2, class8_));
	}

	// Token: 0x060013B6 RID: 5046 RVA: 0x00097588 File Offset: 0x00095788
	private void method_59()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_16(class8_2, class8_));
	}

	// Token: 0x060013B7 RID: 5047 RVA: 0x000975B4 File Offset: 0x000957B4
	private void method_60()
	{
		GClass18.Class8 class8_ = this.method_1();
		this.method_0(this.method_20(class8_));
	}

	// Token: 0x060013B8 RID: 5048 RVA: 0x000975D8 File Offset: 0x000957D8
	private void method_61()
	{
		GClass18.Class8 class8_ = this.method_1();
		this.method_0(this.method_21(class8_));
	}

	// Token: 0x060013B9 RID: 5049 RVA: 0x000975FC File Offset: 0x000957FC
	private void method_62()
	{
		uint num = 0x65A86681U;
		GClass18.Class8 @class = this.method_1();
		for (;;)
		{
			GClass18.Class8 class2 = this.method_1();
			num = (0x53F35223U & num);
			GClass18.Class8 class3 = class2;
			if ((0x19F4044EU & num) != 0U)
			{
				num &= 0x4C8B6B69U;
				GClass18.Class8 class8_ = class3;
				GClass18.Class8 class8_2 = @class;
				num = (0xC4330C1U & num);
				GClass18.Class8 class8_3 = this.method_22(class8_, class8_2, num - 1U != 0U);
				num += 0x72F1587AU;
				this.method_0(class8_3);
				if (num > 0x5AD05897U)
				{
					break;
				}
			}
		}
	}

	// Token: 0x060013BA RID: 5050 RVA: 0x00097668 File Offset: 0x00095868
	private void method_63()
	{
		uint num = 0x362B7A49U;
		GClass18.Class8 class2;
		GClass18.Class8 class4;
		do
		{
			GClass18.Class8 @class = this.method_1();
			num <<= 0xE;
			class2 = @class;
			num = 0x7A3E4A31U % num;
			num = 0x129D5AFBU + num;
			GClass18.Class8 class3 = this.method_1();
			num /= 0x5A8036FDU;
			class4 = class3;
			num = (0x338477E0U | num);
		}
		while (num >= 0x6A6B05DFU);
		GClass18.Class8 class8_ = class4;
		num = 0x65991727U << (int)num;
		GClass18.Class8 class8_2 = class2;
		num ^= 0x3451330BU;
		this.method_0(this.method_22(class8_, class8_2, (num ^ 0xFF631D44U) != 0U));
	}

	// Token: 0x060013BB RID: 5051 RVA: 0x000976E4 File Offset: 0x000958E4
	private void method_64()
	{
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(this.method_23(class8_2, class8_));
	}

	// Token: 0x060013BC RID: 5052 RVA: 0x00097710 File Offset: 0x00095910
	private void method_65()
	{
		Type type_ = this.method_26(this.method_1().vmethod_10());
		this.method_0(this.method_24(this.method_1(), type_));
	}

	// Token: 0x060013BD RID: 5053 RVA: 0x00097744 File Offset: 0x00095944
	private void method_66()
	{
		Type type_ = this.method_26(this.method_1().vmethod_10());
		this.method_0(this.method_24(this.method_1().BF2B5883(type_, false), type_));
	}

	// Token: 0x060013BE RID: 5054 RVA: 0x00097780 File Offset: 0x00095980
	private void method_67()
	{
		Type type_ = this.method_26(this.method_1().vmethod_10());
		this.method_0(this.method_24(this.method_1().BF2B5883(type_, true), type_));
	}

	// Token: 0x060013BF RID: 5055 RVA: 0x0000C4DE File Offset: 0x0000A6DE
	private void method_68()
	{
		this.method_0(new GClass18.Class10(Marshal.SizeOf(this.method_26(this.method_5()))));
	}

	// Token: 0x060013C0 RID: 5056 RVA: 0x000977BC File Offset: 0x000959BC
	private unsafe void method_69()
	{
		Type type = this.method_26(this.method_1().vmethod_10());
		uint num = 0x516ABCU;
		GClass18.Class8 class2;
		for (;;)
		{
			GClass18.Class8 @class = this.method_1();
			num /= 0x4ADC1EA3U;
			class2 = @class;
			for (;;)
			{
				bool flag = class2.vmethod_3();
				num *= 0x63F008F5U;
				if (!flag)
				{
					num ^= 0x5FB29C2U;
					bool flag2 = class2.vmethod_1() is Pointer;
					num = 0x7AAF4726U + num;
					if (!flag2)
					{
						break;
					}
					GClass18.Class8 class3 = class2;
					num = 0x368A466CU % num;
					void* value = Pointer.Unbox(class3.vmethod_1());
					num = 0x24672960U * num;
					IntPtr intptr_ = new IntPtr(value);
					Type type_ = type;
					num = 0x78EF7259U / num;
					GClass18.Class8 class4 = new GClass18.Class24(intptr_, type_);
					num = (0x1A12506DU & num);
					class2 = class4;
					num ^= 1U;
				}
				num = 0x431B4FAFU + num;
				if (0x219B7114U < num)
				{
					goto Block_1;
				}
			}
			if (num != 0x45561A28U)
			{
				goto Block_4;
			}
		}
		Block_1:
		num >>= 0x16;
		object object_ = class2;
		num = (0x4ABA36A5U ^ num);
		GClass18.Class8 class8_ = this.method_24(object_, type);
		num = (0x4A3775DDU & num);
		this.method_0(class8_);
		return;
		Block_4:
		throw new ArgumentException();
	}

	// Token: 0x060013C1 RID: 5057 RVA: 0x000978BC File Offset: 0x00095ABC
	private void method_70()
	{
		uint num;
		for (;;)
		{
			FieldInfo fieldInfo = this.method_28(this.method_1().vmethod_10());
			GClass18.Class8 @class = this.method_1();
			num = 0x3F32563FU;
			object obj = @class.vmethod_1();
			do
			{
				FieldInfo fieldInfo2 = fieldInfo;
				num -= 0x471C57B5U;
				if (!fieldInfo2.IsStatic)
				{
					num = 0x54C5485BU + num;
					bool flag = obj != null;
					num ^= 0xB4CEB86FU;
					if (!flag)
					{
						goto Block_1;
					}
				}
				num = 0x358A4F39U + num;
			}
			while ((num ^ 0x6261638EU) == 0U);
			object value = fieldInfo.GetValue(obj);
			FieldInfo fieldInfo3 = fieldInfo;
			num = 0x577D7A6EU + num;
			Type fieldType = fieldInfo3.FieldType;
			num *= 0x376D55BCU;
			GClass18.Class8 class8_ = this.method_24(value, fieldType);
			num = 0x30914090U >> (int)num;
			this.method_0(class8_);
			if (num < 0x7E3C3A03U)
			{
				return;
			}
		}
		Block_1:
		num >>= 0xF;
		throw new NullReferenceException();
	}

	// Token: 0x060013C2 RID: 5058 RVA: 0x0009797C File Offset: 0x00095B7C
	private void method_71()
	{
		FieldInfo fieldInfo;
		object obj;
		uint num;
		do
		{
			fieldInfo = this.method_28(this.method_1().vmethod_10());
			obj = this.method_1().vmethod_1();
			bool isStatic = fieldInfo.IsStatic;
			num = 0U;
			if (!isStatic)
			{
				if (num / 0x65B16A79U != 0U)
				{
					continue;
				}
				bool flag = obj != null;
				num = (0x589A5680U & num);
				num += 0U;
				if (!flag)
				{
					if (0x4362500FU >= num)
					{
						goto Block_3;
					}
					continue;
				}
			}
		}
		while (0x502E0085U - num == 0U);
		num -= 0x558F6BBAU;
		FieldInfo fieldInfo_ = fieldInfo;
		num |= 0x12F954F0U;
		GClass18.Class8 class8_ = new GClass18.Class22(fieldInfo_, obj);
		num = 0x45A08E0U >> (int)num;
		this.method_0(class8_);
		return;
		Block_3:
		throw new NullReferenceException();
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x00097A28 File Offset: 0x00095C28
	private void method_72()
	{
		FieldInfo fieldInfo;
		uint num;
		GClass18.Class8 @class;
		object obj2;
		do
		{
			fieldInfo = this.method_28(this.method_1().vmethod_10());
			num = 0xE7BAF920U;
			for (;;)
			{
				@class = this.method_1();
				if (num >= 0x448A3552U)
				{
					do
					{
						num &= 0x735D1174U;
						GClass18.Class8 class2 = this.method_1();
						num *= 0x7A972E2BU;
						object obj = class2.vmethod_1();
						num = 0x71161067U / num;
						obj2 = obj;
					}
					while (num > 0x77D73D65U);
					if (!fieldInfo.IsStatic)
					{
						num += 0x72604901U;
						if (0x5F2F091EU > num)
						{
							continue;
						}
						bool flag = obj2 != null;
						num += 0x8D9FB6FFU;
						if (!flag)
						{
							break;
						}
					}
					if (num < 0x70B01334U)
					{
						goto IL_B3;
					}
				}
			}
			num += 0x1BC20A14U;
		}
		while (0x66A34EFDU == num);
		throw new NullReferenceException();
		IL_B3:
		FieldInfo fieldInfo2 = fieldInfo;
		object obj3 = obj2;
		num ^= 0x700B2E17U;
		num = (0x6DA8623DU | num);
		object object_ = @class;
		FieldInfo fieldInfo3 = fieldInfo;
		num *= 0x63A7619U;
		GClass18.Class8 class3 = this.method_24(object_, fieldInfo3.FieldType);
		num += 0x7F90775EU;
		fieldInfo2.SetValue(obj3, class3.vmethod_1());
	}

	// Token: 0x060013C4 RID: 5060 RVA: 0x00097B24 File Offset: 0x00095D24
	private void method_73()
	{
		FieldInfo fieldInfo = this.method_28(this.method_1().vmethod_10());
		uint num = 0x171B7FD6U;
		FieldInfo fieldInfo2 = fieldInfo;
		do
		{
			GClass18.Class8 @class = this.method_1();
			FieldInfo fieldInfo3 = fieldInfo2;
			object obj = null;
			num %= 0x12910D95U;
			num >>= 5;
			object object_ = @class;
			num -= 0x510A4E5DU;
			FieldInfo fieldInfo4 = fieldInfo2;
			num <<= 0x19;
			Type fieldType = fieldInfo4.FieldType;
			num = (0x20C802E8U & num);
			object value = this.method_24(object_, fieldType).vmethod_1();
			num = 0x410D0615U - num;
			fieldInfo3.SetValue(obj, value);
		}
		while (num - 0x4B2B6E15U == 0U);
	}

	// Token: 0x060013C5 RID: 5061 RVA: 0x00097BA8 File Offset: 0x00095DA8
	private unsafe void method_74()
	{
		uint num = 0x68C04002U;
		Type type_ = this.method_26(this.method_1().vmethod_10());
		GClass18.Class8 @class;
		GClass18.Class8 class2;
		for (;;)
		{
			@class = this.method_1();
			class2 = this.method_1();
			if (0x4D407F15U <= num)
			{
				GClass18.Class8 class3 = class2;
				num = (0x33FC0869U ^ num);
				if (!class3.vmethod_3())
				{
					num = 0x32FC6F40U + num;
					bool flag = class2.vmethod_1() is Pointer;
					num = (0x2469685FU & num);
					if (flag)
					{
						if (num * 0x6D5576D2U == 0U)
						{
							continue;
						}
						GClass18.Class8 class4 = class2;
						num = 0x9612413U * num;
						object ptr = class4.vmethod_1();
						num = (0x464B4381U ^ num);
						void* value = Pointer.Unbox(ptr);
						num = 0x2190E84U >> (int)num;
						class2 = new GClass18.Class24(new IntPtr(value), type_);
						num += 0x5B3C4652U;
					}
					else
					{
						if (0x7628003AU > num)
						{
							break;
						}
						continue;
					}
				}
				num += 0x7B044225U;
				if (0x3B14745CU <= num)
				{
					goto IL_D9;
				}
			}
		}
		throw new ArgumentException();
		IL_D9:
		GClass18.Class8 class5 = class2;
		object object_ = @class;
		num = (0x207D4B9FU & num);
		object object_2 = this.method_24(object_, type_).vmethod_1();
		num ^= 0x494529D6U;
		class5.vmethod_2(object_2);
	}

	// Token: 0x060013C6 RID: 5062 RVA: 0x0000C4FC File Offset: 0x0000A6FC
	private void method_75()
	{
		this.method_0(this.list_0[(int)((ushort)this.method_4())].vmethod_0());
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x0000C51B File Offset: 0x0000A71B
	private void method_76()
	{
		this.method_0(new GClass18.Class20(this.list_0[(int)((ushort)this.method_4())]));
	}

	// Token: 0x060013C8 RID: 5064 RVA: 0x00097CB4 File Offset: 0x00095EB4
	private void method_77()
	{
		uint num = 0x1FB01426U;
		GClass18.Class8 @class;
		do
		{
			@class = this.method_1();
		}
		while (num % 0x40171F83U == 0U);
		GClass18.Class8 class2;
		do
		{
			num = 0x65D60DF7U + num;
			List<GClass18.Class8> list = this.list_0;
			num <<= 4;
			ushort num2 = (ushort)this.method_4();
			num |= 0x58BD68D2U;
			class2 = list[(int)num2];
			num = 0x3F5F4CA5U * num;
		}
		while (num > 0x311A567EU);
		GClass18.Class8 class3 = class2;
		num = 0x65F97F14U * num;
		num -= 0x2BA91D4CU;
		object object_ = @class;
		num &= 0x55EC005DU;
		class3.vmethod_2(this.method_24(object_, class2.vmethod_6()).vmethod_1());
	}

	// Token: 0x060013C9 RID: 5065 RVA: 0x0000C53A File Offset: 0x0000A73A
	private void method_78()
	{
		this.type_0 = this.method_26(this.method_1().vmethod_10());
	}

	// Token: 0x060013CA RID: 5066 RVA: 0x00097D44 File Offset: 0x00095F44
	private void method_79()
	{
		uint num = 0x41C61CBEU;
		GClass18.Class8 class2;
		for (;;)
		{
			num /= 0x6E026CD3U;
			MethodBase methodBase = this.method_27(this.method_1().vmethod_10());
			num = 0x73AB7E57U * num;
			MethodBase methodBase2 = methodBase;
			for (;;)
			{
				num /= 0x544B2403U;
				MethodBase methodBase_ = methodBase2;
				bool bool_ = num + 0U != 0U;
				num |= 0x4A120740U;
				GClass18.Class8 @class = this.method_31(methodBase_, bool_);
				num = 0x7092242EU / num;
				class2 = @class;
				if ((num ^ 0x61E01636U) == 0U)
				{
					break;
				}
				if (class2 == null)
				{
					return;
				}
				if (num * 0x58AE3ADDU != 0U)
				{
					goto IL_68;
				}
			}
		}
		IL_68:
		num = (0x65C459B3U & num);
		GClass18.Class8 class8_ = class2;
		num = (0x29D9305FU | num);
		this.method_0(class8_);
		num += 0xD626CFA2U;
	}

	// Token: 0x060013CB RID: 5067 RVA: 0x00097DD8 File Offset: 0x00095FD8
	private void method_80()
	{
		uint num = 0x604F6845U;
		GClass18.Class8 class3;
		do
		{
			IL_277:
			num = 0x61BB08AFU >> (int)num;
			num >>= 0x1E;
			GClass18.Class8 @class = this.method_1();
			num <<= 0xB;
			int int_ = @class.vmethod_10();
			num = 0x651A4391U + num;
			MethodBase methodBase = this.method_27(int_);
			num = 0x753F085EU + num;
			do
			{
				num &= 0x22470616U;
				bool flag = this.type_0 != null;
				num = (0x55EE1F86U ^ num);
				if (flag)
				{
					num = (0x4B655396U & num);
					if (num >= 0x1F0B1776U)
					{
						goto IL_113;
					}
					goto IL_186;
					IL_169:
					int num3;
					int num2 = num3;
					num ^= 0x266C69E4U;
					ParameterInfo[] array2;
					ParameterInfo[] array = array2;
					num = 0x343067CAU - num;
					Type[] array3;
					if (num2 >= array.Length)
					{
						num = 0x14AA465BU / num;
						Type type = this.type_0;
						num = 0x2DE246E0U << (int)num;
						MemberInfo memberInfo = methodBase;
						num = 0xB7D3E48U - num;
						string name = memberInfo.Name;
						num ^= 0x60FE2D16U;
						BindingFlags bindingAttr = (BindingFlags)(num - 0xBD64A94AU);
						num >>= 0x10;
						Binder binder = null;
						num &= 0x6990A1FU;
						Type[] types = array3;
						num = (0x228C45D1U & num);
						ParameterModifier[] modifiers = null;
						num <<= 0x17;
						MethodInfo method = type.GetMethod(name, bindingAttr, binder, types, modifiers);
						if (num - 0x5A11265BU == 0U)
						{
							goto IL_113;
						}
						bool flag2 = method != null;
						num = (0x28275B38U & num);
						if (flag2)
						{
							methodBase = method;
							num += 0U;
						}
						num = 0x59BE5A4FU + num;
						if (num >> 0x10 != 0U)
						{
							Type type2 = null;
							num *= 0x1FE86ADBU;
							this.type_0 = type2;
							num ^= 0xA87CEA15U;
							goto IL_0C;
						}
						continue;
					}
					IL_186:
					ParameterInfo parameterInfo = array2[num3];
					int num4;
					array3[num4++] = parameterInfo.ParameterType;
					num3++;
					num = 0x3A3BE0D8U;
					goto IL_169;
					IL_113:
					ParameterInfo[] parameters = methodBase.GetParameters();
					int num5 = parameters.Length;
					num = (0x14E95417U ^ num);
					int num6 = num5;
					num <<= 1;
					array3 = new Type[num6];
					int num7 = (int)(num ^ 0xAF988B2EU);
					num >>= 0x19;
					num4 = num7;
					num <<= 0xD;
					array2 = parameters;
					int num8 = (int)(num ^ 0xAE000U);
					num += 0x3A3100D8U;
					num3 = num8;
					goto IL_169;
				}
				IL_0C:
				num += 0x731A2C90U;
				if (num == 0x693D1AFAU)
				{
					goto IL_277;
				}
				num >>= 0x13;
				MethodBase methodBase_ = methodBase;
				num = 0x3B095532U * num;
				bool bool_ = num + 0x906F7F9FU != 0U;
				num %= 0x22D47070U;
				GClass18.Class8 class2 = this.method_31(methodBase_, bool_);
				num = (0x2EF006ADU & num);
				class3 = class2;
				num = (0x3A07546FU & num);
			}
			while (0x40BE48F8U + num == 0U);
			if (class3 == null)
			{
				return;
			}
		}
		while ((0xB84007AU ^ num) == 0U);
		this.method_0(class3);
		num ^= 0U;
	}

	// Token: 0x060013CC RID: 5068 RVA: 0x000980BC File Offset: 0x000962BC
	private void method_81()
	{
		uint num = 0xA65BCD65U;
		MethodBase methodBase = this.method_1().vmethod_1() as MethodBase;
		while (methodBase != null || 0x66A40494U == num)
		{
			num = 0x5D0F4038U + num;
			num %= 0x419314E5U;
			MethodBase methodBase_ = methodBase;
			bool bool_ = (num ^ 0x36B0D9DU) != 0U;
			num /= 0x1BE4A7FU;
			GClass18.Class8 @class = this.method_31(methodBase_, bool_);
			num = 0x3D7A388FU % num;
			GClass18.Class8 class2 = @class;
			bool flag = class2 != null;
			num = (0x29DC02DBU | num);
			if (!flag)
			{
				goto IL_95;
			}
			num = 0x7A274B76U >> (int)num;
			if (0x6B4C3A32U < num)
			{
				continue;
			}
			IL_86:
			this.method_0(class2);
			num ^= 0x29DC02D4U;
			IL_95:
			if (0x23DD52E2U - num != 0U)
			{
				return;
			}
			goto IL_86;
		}
		throw new ArgumentException();
	}

	// Token: 0x060013CD RID: 5069 RVA: 0x00098168 File Offset: 0x00096368
	private void method_82()
	{
		GClass18.Class8 @class = this.method_32(this.method_1().vmethod_10(), false);
		uint num = 1U;
		if (@class != null)
		{
			num /= 0x2C946E24U;
			this.method_0(@class);
			num += 1U;
		}
	}

	// Token: 0x060013CE RID: 5070 RVA: 0x000981B8 File Offset: 0x000963B8
	private void method_83()
	{
		GClass18.Class8 @class = this.method_32(this.method_1().vmethod_10(), true);
		uint num = 0xBB295BA8U;
		if (@class == null)
		{
			goto IL_59;
		}
		num = (0x65FD28DBU ^ num);
		IL_42:
		num &= 0x59DD6192U;
		this.method_0(@class);
		num ^= 0xE3FD3ABAU;
		IL_59:
		if (num > 0x4306541EU)
		{
			return;
		}
		goto IL_42;
	}

	// Token: 0x060013CF RID: 5071 RVA: 0x00098228 File Offset: 0x00096428
	private void method_84()
	{
		uint num = 0x348B5F76U;
		for (;;)
		{
			num = (0x47D1270BU ^ num);
			int int_ = this.method_1().vmethod_10();
			num /= 0x74D7CAEU;
			MethodBase methodBase = this.method_27(int_);
			if (0x2ED81FACU % num == 0U)
			{
				num = 0xD083776U / num;
				MethodBase methodBase_ = methodBase;
				num %= 0x719D0E9AU;
				GClass18.Class8 @class = this.method_29(methodBase_);
				num = 0x68336C8EU - num;
				GClass18.Class8 class2 = @class;
				if (class2 != null)
				{
					GClass18.Class8 class8_ = class2;
					num = 0x5DFC443DU >> (int)num;
					this.method_0(class8_);
					num ^= 0x67550301U;
				}
				if (0x7EF80233U != num)
				{
					break;
				}
			}
		}
	}

	// Token: 0x060013D0 RID: 5072 RVA: 0x000982B4 File Offset: 0x000964B4
	private void method_85()
	{
		uint num;
		GClass18.Class8 class2;
		for (;;)
		{
			IL_00:
			Type type = this.method_26(this.method_1().vmethod_10());
			GClass18.Class8 @class = this.method_1();
			num = 0x73321E50U;
			class2 = @class;
			for (;;)
			{
				Type type2 = type;
				num = 0x494106DDU << (int)num;
				bool isGenericType = type2.IsGenericType;
				num %= 0x4F6F6090U;
				if (isGenericType)
				{
					Type genericTypeDefinition = type.GetGenericTypeDefinition();
					num = 0xE7458DDU - num;
					RuntimeTypeHandle handle = typeof(Nullable<>).TypeHandle;
					num = (0x2A697CCFU ^ num);
					Type typeFromHandle = Type.GetTypeFromHandle(handle);
					num ^= 0x2B232412U;
					if (genericTypeDefinition == typeFromHandle)
					{
						goto Block_6;
					}
				}
				num = 0x2DAD12F8U + num;
				if (type.IsValueType)
				{
					if (0xE1B45B8U >= num)
					{
						goto IL_00;
					}
					Type type3 = type;
					num = (0x518E1D95U | num);
					BindingFlags bindingAttr = (int)num + (BindingFlags)(-0x758E1F89);
					num |= 0x6B5D281AU;
					FieldInfo[] fields = type3.GetFields(bindingAttr);
					int num2 = (int)(num ^ 0x7FDF3FFFU);
					for (;;)
					{
						int num3 = num2;
						FieldInfo[] array = fields;
						num <<= 0xE;
						int num4 = array.Length;
						num = 0x17FC61A7U * num;
						if (num3 >= num4)
						{
							goto Block_4;
						}
						FieldInfo fieldInfo = fields[num2];
						FieldInfo fieldInfo2 = fieldInfo;
						object obj = class2.vmethod_1();
						bool isValueType = fieldInfo.FieldType.IsValueType;
						num = 0xE490814EU;
						object value;
						if (!isValueType)
						{
							num = 0x2C7B4C1DU << (int)num;
							value = null;
						}
						else
						{
							num = 0x694D143EU + num;
							FieldInfo fieldInfo3 = fieldInfo;
							num = 0x1FEC6753U + num;
							Type fieldType = fieldInfo3.FieldType;
							num = (0x63A94D0FU ^ num);
							value = Activator.CreateInstance(fieldType);
							num += 0xC4A68E30U;
						}
						num = 0x18AC6229U << (int)num;
						fieldInfo2.SetValue(obj, value);
						num += 0x69387191U;
						if (0x2D8B4224U > num)
						{
							break;
						}
						int num5 = num2;
						num = (0x737237D3U ^ num);
						int num6 = num5 + (int)(num ^ 0xF296E468U);
						num = (0x6FEF685DU | num);
						num2 = num6;
						num += 0x7FDF5382U;
					}
				}
				else if (num != 0x4E323678U)
				{
					goto Block_5;
				}
			}
			Block_4:
			if (0x77517881U <= num)
			{
				return;
			}
		}
		Block_5:
		GClass18.Class8 class3 = class2;
		object object_ = null;
		num -= 0x1D456466U;
		class3.vmethod_2(object_);
		return;
		Block_6:
		num -= 0x16C167CBU;
		GClass18.Class8 class4 = class2;
		object object_2 = null;
		num = (0x28B817E6U & num);
		class4.vmethod_2(object_2);
	}

	// Token: 0x060013D1 RID: 5073 RVA: 0x000984A8 File Offset: 0x000966A8
	private void method_86()
	{
		int num = this.method_1().vmethod_10();
		uint num2 = 0x156CU;
		GClass18.Class8 @class = this.method_1();
		do
		{
			num2 |= 0x12DD18ECU;
			GClass18.Class8 class2 = this.method_1();
			num2 *= 0x7B2E3AE5U;
			num2 = (0x6BD159C3U | num2);
			num2 = 0x5CD7707FU + num2;
			GClass18.Class8 class8_ = class2;
			num2 %= 0x3F6F3208U;
			GClass18.Class8 class8_2 = @class;
			bool bool_ = num2 + 0xE29C43AAU != 0U;
			num2 = (0x3D8B44CDU & num2);
			int int_ = num;
			num2 = 0x564F6629U - num2;
			GClass18.Class8 class8_3 = new GClass18.Class10(this.method_19(class8_, class8_2, bool_, int_));
			num2 <<= 2;
			this.method_0(class8_3);
		}
		while (num2 <= 0xCB13B35U);
	}

	// Token: 0x060013D2 RID: 5074 RVA: 0x00098544 File Offset: 0x00096744
	private void method_87()
	{
		int int_ = this.method_1().vmethod_10();
		GClass18.Class8 class8_ = this.method_1();
		GClass18.Class8 class8_2 = this.method_1();
		this.method_0(new GClass18.Class10(this.method_19(class8_2, class8_, true, int_)));
	}

	// Token: 0x060013D3 RID: 5075 RVA: 0x00098580 File Offset: 0x00096780
	private void method_88()
	{
		Type elementType = this.method_26(this.method_1().vmethod_10());
		this.method_0(new GClass18.Class18(Array.CreateInstance(elementType, this.method_1().vmethod_10())));
	}

	// Token: 0x060013D4 RID: 5076 RVA: 0x000985BC File Offset: 0x000967BC
	private void method_89()
	{
		uint num;
		for (;;)
		{
			Type type = this.method_26(this.method_1().vmethod_10());
			num = 0xD2BC1242U;
			GClass18.Class8 class2;
			GClass18.Class8 class3;
			Array array2;
			do
			{
				num <<= 0x1F;
				GClass18.Class8 @class = this.method_1();
				num += 0x7F8C0C00U;
				class2 = @class;
				num = 0x3A17F54U << (int)num;
				num = 0x7B7D5F08U / num;
				class3 = this.method_1();
				num = 0x71641335U << (int)num;
				Array array = this.method_1().vmethod_1() as Array;
				num <<= 0x19;
				array2 = array;
				num = 0x41DD5788U + num;
				bool flag = array2 != null;
				num = 0x24E11191U - num;
				if (!flag)
				{
					goto Block_0;
				}
				num |= 0x5D96704BU;
			}
			while (0x3C9E373FU >= num);
			Array array3 = array2;
			num >>= 0xA;
			num >>= 0xA;
			object object_ = class2;
			Type type_ = type;
			num &= 0x55965925U;
			object object_2 = this.method_24(object_, type_);
			num ^= 0x44377DDBU;
			object obj = array2;
			num = 0x8DF4B7FU << (int)num;
			object value = this.method_24(object_2, obj.GetType().GetElementType()).vmethod_1();
			GClass18.Class8 class4 = class3;
			num = 0x2C8344D6U << (int)num;
			int index = class4.vmethod_10();
			num = 0x2D777C53U - num;
			array3.SetValue(value, index);
			if (0x351D0C3BU * num != 0U)
			{
				return;
			}
		}
		Block_0:
		num = (0x4A9C6E6BU ^ num);
		throw new ArgumentException();
	}

	// Token: 0x060013D5 RID: 5077 RVA: 0x00098704 File Offset: 0x00096904
	private void method_90()
	{
		uint num = 0x66F435DDU;
		for (;;)
		{
			IL_C7:
			num -= 0x334E7F18U;
			num = 0x749930B5U % num;
			Type type = this.method_26(this.method_1().vmethod_10());
			num = 0x642A5256U << (int)num;
			Type type2 = type;
			for (;;)
			{
				GClass18.Class8 @class = this.method_1();
				num |= 0xB904C8BU;
				GClass18.Class8 class2 = @class;
				num <<= 0x1F;
				for (;;)
				{
					num /= 0x30739C6U;
					GClass18.Class8 class3 = this.method_1();
					num = (0x1D1F57ABU ^ num);
					Array array = class3.vmethod_1() as Array;
					num %= 0x3D2D3A80U;
					Array array2 = array;
					num *= 0x1D523372U;
					if (num < 0x7A3B661DU)
					{
						goto IL_C7;
					}
					if (array2 == null)
					{
						goto IL_F9;
					}
					if (num <= 0xC2C794EU)
					{
						break;
					}
					num *= 0x57B054DCU;
					Array array3 = array2;
					num = 0x187C7E0AU - num;
					GClass18.Class8 class4 = class2;
					num = 0x26CA551DU * num;
					int index = class4.vmethod_10();
					num = 0x72C640AAU % num;
					object value = array3.GetValue(index);
					num = (0x6B37868U | num);
					Type type_ = type2;
					num = (0x35B96960U ^ num);
					this.method_0(this.method_24(value, type_));
					if (0x5B8E1D21U >= num)
					{
						return;
					}
				}
			}
		}
		IL_F9:
		num /= 0x42E707E3U;
		throw new ArgumentException();
	}

	// Token: 0x060013D6 RID: 5078 RVA: 0x00098818 File Offset: 0x00096A18
	private void method_91()
	{
		uint num;
		for (;;)
		{
			IL_00:
			Array array = this.method_1().vmethod_1() as Array;
			num = 0x58673ACEU;
			Array array2 = array;
			while (array2 != null)
			{
				if (0x703C6CE7U / num == 0U)
				{
					goto IL_00;
				}
				this.method_0(new GClass18.Class10(array2.Length));
				if (0x46202CDD << (int)num != 0)
				{
					return;
				}
			}
			break;
		}
		num &= 0x4514604EU;
		if (num < 0x6FC7583DU)
		{
			throw new ArgumentException();
		}
	}

	// Token: 0x060013D7 RID: 5079 RVA: 0x00098880 File Offset: 0x00096A80
	private void method_92()
	{
		GClass18.Class8 @class = this.method_1();
		Array array = this.method_1().vmethod_1() as Array;
		bool flag = array != null;
		uint num = 0x39U;
		if (!flag)
		{
			num ^= 0x2990731BU;
			throw new ArgumentException();
		}
		num += 0x3872265EU;
		Array array_ = array;
		num += 0x425452BU;
		GClass18.Class8 class2 = @class;
		num >>= 0x16;
		int int_ = class2.vmethod_10();
		num &= 0x20B56E33U;
		GClass18.Class8 class8_ = new GClass18.Class23(array_, int_);
		num = 0x2B9F0F46U * num;
		this.method_0(class8_);
	}

	// Token: 0x060013D8 RID: 5080 RVA: 0x00098918 File Offset: 0x00096B18
	private void method_93()
	{
		uint num = 0x326E224DU;
		do
		{
			num >>= 0xF;
			num = (0x288955D5U ^ num);
			num = 0x1CD53852U * num;
			this.method_0(new GClass18.Class25(this.method_27(this.method_1().vmethod_10())));
		}
		while (num - 0x30F958F3U == 0U);
	}

	// Token: 0x060013D9 RID: 5081 RVA: 0x00098968 File Offset: 0x00096B68
	private void method_94()
	{
		uint num = 0x6FF77CF5U;
		for (;;)
		{
			IL_2B8:
			num %= 0x3EA64263U;
			num += 0x57F00D3FU;
			MethodBase methodBase = this.method_27(this.method_1().vmethod_10());
			num = 0x537D334EU * num;
			MethodBase methodBase2 = methodBase;
			num >>= 0x1A;
			for (;;)
			{
				IL_284:
				num = (0x63DD6674U | num);
				GClass18.Class8 @class = this.method_1();
				num &= 0x7107184U;
				Type type = @class.vmethod_1().GetType();
				num |= 0x3E987B7AU;
				Type type2 = type;
				for (;;)
				{
					IL_205:
					Type declaringType = methodBase2.DeclaringType;
					num &= 0x590334E0U;
					Type type3 = declaringType;
					MethodBase methodBase3 = methodBase2;
					num = (0x5B2E3681U & num);
					ParameterInfo[] parameters = methodBase3.GetParameters();
					num = (0x6E9C4FE5U & num);
					int num2 = parameters.Length;
					num = (0x1CE11ABU | num);
					int num3 = num2;
					num = 0x11BC09F3U + num;
					Type[] array = new Type[num3];
					num = 0x781C3016U >> (int)num;
					Type[] array2 = array;
					num = 0x773A11B4U * num;
					int num4 = (int)(num ^ 0x773A11B4U);
					num = 0xA75612FU % num;
					int num5 = num4;
					ParameterInfo[] array3 = parameters;
					for (;;)
					{
						num += 0x5A0F3B82U;
						int num6 = (int)(num ^ 0x64849CB1U);
						if (num == 0x413872A3U)
						{
							goto IL_2B8;
						}
						for (;;)
						{
							num |= 0x38300640U;
							int num7 = num6;
							num = 0x46C2794U << (int)num;
							int num8 = array3.Length;
							num = 0x5562713BU + num;
							if (num7 >= num8)
							{
								break;
							}
							ParameterInfo parameterInfo = array3[num6];
							array2[num5++] = parameterInfo.ParameterType;
							num6++;
							num = 0x64849CB1U;
						}
						if (num >> 8 != 0U)
						{
							MethodInfo method;
							for (;;)
							{
								num = (0x17465BEU | num);
								bool flag = type2 != null;
								num += 0x5A018A41U;
								if (!flag)
								{
									break;
								}
								num = (0x648754C5U ^ num);
								if (0x52761296U >> (int)num == 0U)
								{
									goto IL_205;
								}
								Type type4 = type2;
								Type type5 = type3;
								num = 0x193357A7U + num;
								if (type4 == type5)
								{
									goto Block_4;
								}
								for (;;)
								{
									method = type2.GetMethod(methodBase2.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array2, null);
									bool flag2 = method != null;
									num = 0U;
									if (!flag2)
									{
										break;
									}
									num += 0x28587A97U;
									MethodInfo baseDefinition = method.GetBaseDefinition();
									MethodBase methodBase4 = methodBase2;
									num /= 0x4D4261E1U;
									num ^= 0U;
									if (baseDefinition != methodBase4)
									{
										break;
									}
									num /= 0x71E7143BU;
									if (0x3C9712C7U * num == 0U)
									{
										goto IL_1A5;
									}
								}
								num = (0x32365203U ^ num);
								Type type6 = type2;
								num = 0x6CB549C0U % num;
								Type baseType = type6.BaseType;
								num = 0x564F39A0U / num;
								type2 = baseType;
								num += 0xA48A7131U;
							}
							IL_1B3:
							num += 0x3A851925U;
							num = 0x46107477U * num;
							this.method_0(new GClass18.Class25(methodBase2));
							if ((0x60405609U ^ num) == 0U)
							{
								continue;
							}
							return;
							Block_4:
							num += 0x82455394U;
							goto IL_1B3;
							IL_1A5:
							MethodBase methodBase5 = method;
							num &= 0x375B2AD8U;
							methodBase2 = methodBase5;
							goto IL_1B3;
						}
						goto IL_284;
					}
				}
			}
		}
	}

	// Token: 0x060013DA RID: 5082 RVA: 0x0000C553 File Offset: 0x0000A753
	private void method_95()
	{
		this.int_0 = this.method_1().vmethod_10();
	}

	// Token: 0x060013DB RID: 5083 RVA: 0x0000C566 File Offset: 0x0000A766
	private void method_96()
	{
		this.method_1();
	}

	// Token: 0x060013DC RID: 5084 RVA: 0x00098C6C File Offset: 0x00096E6C
	private void method_97()
	{
		uint num = 0x7DFB06F9U;
		for (;;)
		{
			IL_1C6:
			Stack<int> stack = this.stack_2;
			num = 0x44AE58DBU - num;
			stack.Push(this.method_1().vmethod_10());
			num = 0x6B1E2AE3U << (int)num;
			if ((0x579E7E18U & num) != 0U)
			{
				num = 0x1841023U * num;
				int num2 = this.method_1().vmethod_10();
				num += 0x1B443E25U;
				int num3 = num2;
				for (;;)
				{
					num = 0x23012A57U >> (int)num;
					Stack<GClass18.Class38> stack2 = this.stack_1;
					num = 0x4B1968D1U % num;
					if (stack2.Count == 0)
					{
						break;
					}
					num += 0x2EF13358U;
					if (num << 0xB != 0U)
					{
						int num4 = num3;
						num *= 0x3895456U;
						Stack<GClass18.Class38> stack3 = this.stack_1;
						num = (0x3E0749A3U ^ num);
						GClass18.Class38 @class = stack3.Peek();
						num = 0x12E5AA6U / num;
						if (num4 <= @class.method_1())
						{
							goto IL_17B;
						}
						List<GClass18.Class37> list = this.stack_1.Pop().method_4();
						int count = list.Count;
						num = 0x30D874F7U;
						int num5 = count;
						for (;;)
						{
							num ^= 0x1FE3039CU;
							if (num5 <= (int)(num ^ 0x2F3B776BU))
							{
								break;
							}
							GClass18.Class37 class2 = list[num5 - 1];
							byte b = class2.method_0();
							int num6 = 2;
							num = 0x7FBC77DBU;
							if (b == num6)
							{
								num <<= 0xC;
								this.stack_2.Push(class2.method_1());
								num = 0x7FBC77DBU;
							}
							if ((num ^ 0x73E9634EU) == 0U)
							{
								goto IL_1C6;
							}
							int num7 = num5;
							int num8 = (int)(num + 0x80438826U);
							num <<= 0x1B;
							int num9 = num7 - num8;
							num += 0x24D5BB4U;
							num5 = num9;
							num += 0x568B1943U;
						}
						num ^= 0x15970522U;
					}
				}
				IL_183:
				num = 0x52654DCU + num;
				this.exception_0 = null;
				if (num == 0xCFA467DU)
				{
					continue;
				}
				Stack<GClass18.Class9> stack4 = this.stack_0;
				num += 0x24FB360EU;
				stack4.Clear();
				this.int_0 = this.stack_2.Pop();
				if (num > 0x328B2448U)
				{
					continue;
				}
				break;
				IL_17B:
				num ^= 0x7E9BFU;
				goto IL_183;
			}
		}
	}

	// Token: 0x060013DD RID: 5085 RVA: 0x00098E7C File Offset: 0x0009707C
	private void method_98()
	{
		uint num = 0x62C12CBEU;
		if (this.exception_0 == null && (num ^ 0x1D951DB5U) != 0U)
		{
			num = 0xB212CB8U >> (int)num;
			this.int_0 = this.stack_2.Pop();
		}
		else
		{
			num = 0x3B2E2341U << (int)num;
			if (num != 0x437F67A0U)
			{
				num = (0x2CCF6E21U | num);
				num += 0x277975AAU;
				Exception exception_ = this.exception_0;
				num = (0x621F3B01U ^ num);
				this.method_34(exception_);
				return;
			}
		}
	}

	// Token: 0x060013DE RID: 5086 RVA: 0x00098EFC File Offset: 0x000970FC
	private void method_99()
	{
		uint num = 0x7BEB3E14U;
		do
		{
			GClass18.Class8 @class = this.method_1();
			num = 0x2DE55B57U / num;
			if (@class.vmethod_10() != 0)
			{
				num /= 0x176F53DCU;
				num = 0xEE60264U - num;
				this.stack_1.Pop();
				if (num == 0x9DD0CA2U)
				{
					continue;
				}
			}
			else if (0x2BC15CB7U >= num)
			{
				goto IL_99;
			}
			num <<= 0;
			Stack<GClass18.Class9> stack = this.stack_0;
			num ^= 0x34222465U;
			num = 0x4CAF0D01U / num;
			GClass18.Class9 item = new GClass18.Class15(this.exception_0);
			num = 0x5EED614BU >> (int)num;
			stack.Push(item);
		}
		while (num == 0x42C53E2AU);
		num *= 0x5A531AF2U;
		int num2 = this.class37_0.method_1();
		num = 0x38C556E8U << (int)num;
		this.int_0 = num2;
		num += 0x40546AFBU;
		GClass18.Class37 class2 = null;
		num = 0x9892AC0U >> (int)num;
		this.class37_0 = class2;
		return;
		IL_99:
		num -= 0x20DF25C8U;
		this.method_34(this.exception_0);
	}

	// Token: 0x060013DF RID: 5087 RVA: 0x00098FFC File Offset: 0x000971FC
	private void method_100()
	{
		Type type_ = this.method_26(this.method_1().vmethod_10());
		this.method_0(new GClass18.Class15(this.method_24(this.method_1(), type_).vmethod_1()));
	}

	// Token: 0x060013E0 RID: 5088 RVA: 0x00099038 File Offset: 0x00097238
	private void method_101()
	{
		Type type_ = this.method_26(this.method_1().vmethod_10());
		this.method_0(this.method_24(this.method_1().vmethod_1(), type_));
	}

	// Token: 0x060013E1 RID: 5089 RVA: 0x00099070 File Offset: 0x00097270
	private void method_102()
	{
		uint num;
		object obj2;
		for (;;)
		{
			IL_00:
			num = 0xE39D0900U;
			Type type = this.method_26(this.method_1().vmethod_10());
			for (;;)
			{
				GClass18.Class8 @class = this.method_1();
				num /= 0x7D17217AU;
				GClass18.Class8 class2 = @class;
				num -= 0x4B4B72BCU;
				if (num <= 0x5A727117U)
				{
					goto IL_00;
				}
				for (;;)
				{
					IL_12E:
					object obj = class2.vmethod_1();
					num = 0x73513615U << (int)num;
					obj2 = obj;
					for (;;)
					{
						bool flag = obj2 != null;
						num = 0x3F7B123DU % num;
						if (!flag)
						{
							goto Block_4;
						}
						if (num == 0xFFE004FU)
						{
							goto IL_00;
						}
						Type type2 = type;
						num >>= 9;
						bool isValueType = type2.IsValueType;
						num = 0x6B305C48U / num;
						if (isValueType)
						{
							break;
						}
						if (num != 0x4C5E3F55U)
						{
							Type type3 = type;
							num = 0x22FE585FU * num;
							TypeCode typeCode = Type.GetTypeCode(type3);
							object obj3 = typeCode;
							num = (0x110444BFU & num);
							object obj4 = num - 0x1000409DU;
							num = (0x2AF503C5U ^ num);
							object obj5 = obj3 - obj4;
							num = (0x75697DE7U & num);
							switch (obj5)
							{
							case 0:
								if (0x9401549U + num == 0U)
								{
									continue;
								}
								goto IL_339;
							case 1:
								goto IL_240;
							case 2:
								goto IL_158;
							case 3:
								goto IL_34D;
							case 4:
								goto IL_373;
							case 5:
								goto IL_196;
							case 6:
								goto IL_2BB;
							case 7:
								goto IL_2D6;
							case 8:
								goto IL_3FA;
							case 9:
								goto IL_2E7;
							case 0xA:
								goto IL_432;
							case 0xB:
								goto IL_1AF;
							}
							goto Block_3;
						}
						goto IL_12E;
					}
					if (0x1B2A55B7U / num == 0U)
					{
						goto IL_00;
					}
					if (type != obj2.GetType())
					{
						break;
					}
					num = 0x4D2B344DU + num;
					GClass18.Class8 class8_ = class2;
					num = 0x393D09B6U + num;
					this.method_0(class8_);
					if (0x38DA75E6U * num != 0U)
					{
						return;
					}
				}
				if (num < 0x1FF73DD0U)
				{
					goto Block_7;
				}
				continue;
				IL_158:
				num *= 0x556375F3U;
				num ^= 0x696933A7U;
				sbyte sbyte_ = (sbyte)obj2;
				num = 0x9D941C9U - num;
				this.method_0(new GClass18.Class34(sbyte_));
				if (num * 0x69033DDU != 0U)
				{
					return;
				}
				continue;
				IL_196:
				num = 0x7CB61ACAU + num;
				if (0x16C12191U - num != 0U)
				{
					goto Block_9;
				}
				continue;
				IL_1AF:
				if ((0x4DEB64B9U ^ num) == 0U)
				{
					goto IL_00;
				}
				num *= 0x49D07F2CU;
				object obj6 = obj2;
				num <<= 0x10;
				GClass18.Class8 class8_2 = new GClass18.Class13((double)obj6);
				num = 0x9334DFBU / num;
				this.method_0(class8_2);
				if (0x4A0F6C61U != num)
				{
					return;
				}
			}
			Block_4:
			num -= 0x2CFD30D0U;
			if (num != 0x1A192ECAU)
			{
				goto Block_13;
			}
			continue;
			Block_9:
			object obj7 = obj2;
			num = (0x652903D4U | num);
			ushort ushort_ = (ushort)obj7;
			num -= 0x411A46CCU;
			this.method_0(new GClass18.Class30(ushort_));
			if (num >> 4 != 0U)
			{
				return;
			}
			continue;
			IL_240:
			num = 0x2AFE1733U % num;
			if (0x3DF40604U * num == 0U)
			{
				continue;
			}
			GClass18.Class8 class8_3 = new GClass18.Class32((char)obj2);
			num = (0x3D5A3D1AU ^ num);
			this.method_0(class8_3);
			if (0x24594714U - num != 0U)
			{
				return;
			}
			continue;
			IL_2BB:
			num = 0x36B301F9U % num;
			if (num <= 0x7C7264D8U)
			{
				goto Block_17;
			}
			continue;
			IL_2D6:
			if (num < 0x6D757F9BU)
			{
				goto Block_18;
			}
			continue;
			IL_2E7:
			if (0x4D695867U > num)
			{
				GClass18.Class8 class8_4 = new GClass18.Class36((ulong)obj2);
				num = 0x3D654BE6U >> (int)num;
				this.method_0(class8_4);
				if ((num ^ 0x3C83121U) != 0U)
				{
					return;
				}
			}
		}
		Block_3:
		throw new InvalidCastException();
		Block_7:
		throw new InvalidCastException();
		Block_13:
		throw new NullReferenceException();
		Block_17:
		num &= 0x6D2A67B2U;
		object obj8 = obj2;
		num ^= 0x24001657U;
		GClass18.Class8 class8_5 = new GClass18.Class10((int)obj8);
		num = 0x42432DC9U % num;
		this.method_0(class8_5);
		return;
		Block_18:
		num = 0x194F54C7U % num;
		uint uint_ = (uint)obj2;
		num %= 0x605251ADU;
		GClass18.Class8 class8_6 = new GClass18.Class35(uint_);
		num = 0x573762ECU + num;
		this.method_0(class8_6);
		return;
		IL_339:
		this.method_0(new GClass18.Class31((bool)obj2));
		return;
		IL_34D:
		object obj9 = obj2;
		num = 0x2C2428F2U + num;
		GClass18.Class8 class8_7 = new GClass18.Class33((byte)obj9);
		num &= 0x2B25043U;
		this.method_0(class8_7);
		return;
		IL_373:
		object obj10 = obj2;
		num &= 0x689215BEU;
		short short_ = (short)obj10;
		num = (0x629F6135U & num);
		this.method_0(new GClass18.Class29(short_));
		return;
		IL_3FA:
		num <<= 0x1C;
		num &= 0x6DE13608U;
		object obj11 = obj2;
		num <<= 0xA;
		this.method_0(new GClass18.Class11((long)obj11));
		return;
		IL_432:
		num <<= 0x12;
		this.method_0(new GClass18.Class12((float)obj2));
	}

	// Token: 0x060013E2 RID: 5090 RVA: 0x0000C56F File Offset: 0x0000A76F
	private void method_103()
	{
		this.method_0(new GClass18.Class10(Marshal.ReadInt32(new IntPtr(this.long_0 + (long)((ulong)this.method_1().vmethod_13())))));
	}

	// Token: 0x060013E3 RID: 5091 RVA: 0x000994DC File Offset: 0x000976DC
	private void method_104()
	{
		int num;
		uint num2;
		ModuleHandle moduleHandle2;
		for (;;)
		{
			IL_00:
			num = this.method_1().vmethod_10();
			num2 = 0x3A7E7D77U;
			for (;;)
			{
				int num3 = num;
				int num4 = (int)(num2 + 0xC58182A1U);
				num2 |= 0x2275600AU;
				int num5 = num3 >> num4;
				num2 ^= 0x3E956D5U;
				if (0x7CEE24D4U <= num2)
				{
					goto IL_1D;
				}
				int num6 = num5;
				uint num7 = num2 - 0x39962BA0U;
				num2 >>= 0x1A;
				if (num6 <= num7)
				{
					num2 >>= 9;
					goto IL_1D;
				}
				int num8 = num5;
				num2 = 0x4A5165EBU + num2;
				uint num9 = num2 - 0x4A5165DEU;
				num2 ^= 0x4A5165F9U;
				if (num8 == num9)
				{
					goto IL_98;
				}
				if (0xA750F56U >= num2)
				{
					int num10 = num5;
					num2 ^= 0x7C2B00C2U;
					uint num11 = num2 ^ 0x7C2B00E9U;
					num2 %= 0x59764CEEU;
					num2 ^= 0x22B4B3D4U;
					if (num10 == num11)
					{
						goto IL_1A5;
					}
					if (0x7FF77599U < num2)
					{
						continue;
					}
					goto IL_1B6;
				}
				IL_6B:
				int num12 = num5;
				num2 &= 0x2D2E7EA1U;
				uint num13 = num2 - 0x92E43F7U;
				num2 |= 0xD4623A0U;
				if (num12 == num13)
				{
					goto IL_1D0;
				}
				if (0x1AC45AF6U >= num2)
				{
					goto Block_2;
				}
				continue;
				IL_1D:
				object obj = num5;
				num2 |= 0xCF944FEU;
				object obj2 = num2 - 0xCF944FDU;
				num2 /= 0x3065849U;
				object obj3 = obj - obj2;
				num2 >>= 0x11;
				switch (obj3)
				{
				case 0:
				case 1:
				{
					IL_98:
					num2 |= 0xF3B6993U;
					num2 /= 0x2C8B6F17U;
					ModuleHandle moduleHandle = this.module_0.ModuleHandle;
					num2 = (0x91004AFU ^ num2);
					moduleHandle2 = moduleHandle;
					num2 = 0x136E3BA0U - num2;
					object object_ = moduleHandle2.ResolveTypeHandle(num);
					num2 *= 0x3497753FU;
					this.method_0(new GClass18.Class17(object_));
					if (num2 > 0x5B5C4B51U)
					{
						return;
					}
					break;
				}
				case 2:
				case 4:
					goto IL_2BB;
				case 3:
					goto IL_18C;
				case 5:
					goto IL_1A5;
				default:
					num2 = 0x597E444DU + num2;
					if (0x627D004CU != num2)
					{
						goto IL_6B;
					}
					goto IL_00;
				}
			}
			IL_18C:
			num2 /= 0x5CE7053FU;
			if ((0x3A9763A0U & num2) == 0U)
			{
				goto Block_9;
			}
			continue;
			IL_1A5:
			if (0x44EB3059U * num2 == 0U)
			{
				goto Block_10;
			}
		}
		Block_2:
		num2 += 0xF291985FU;
		goto IL_2BB;
		Block_9:
		num2 = (0x52C6798CU | num2);
		ModuleHandle moduleHandle3 = this.module_0.ModuleHandle;
		num2 *= 0x73B02149U;
		moduleHandle2 = moduleHandle3;
		num2 = (0x3D435616U & num2);
		num2 = (0x4CB453DEU | num2);
		this.method_0(new GClass18.Class17(moduleHandle2.ResolveFieldHandle(num)));
		return;
		Block_10:
		num2 = 0x16204D60U << (int)num2;
		num2 *= 0x4DD8074FU;
		Module module = this.module_0;
		num2 |= 0x49BA12F5U;
		ModuleHandle moduleHandle4 = module.ModuleHandle;
		num2 = 0x4BDA1E97U / num2;
		moduleHandle2 = moduleHandle4;
		int methodToken = num;
		num2 = (0x15677E86U & num2);
		RuntimeMethodHandle runtimeMethodHandle = moduleHandle2.ResolveMethodHandle(methodToken);
		num2 = 0x2FA40FD3U + num2;
		object object_2 = runtimeMethodHandle;
		num2 |= 0x5ADB3245U;
		this.method_0(new GClass18.Class17(object_2));
		return;
		IL_1B6:
		num2 += 0U;
		goto IL_2BB;
		IL_1D0:
		num2 /= 0x7D0A0D8EU;
		try
		{
			num2 = 0x5539432BU >> (int)num2;
			Module module2 = this.module_0;
			num2 >>= 0x11;
			moduleHandle2 = module2.ModuleHandle;
			num2 *= 0x407537DCU;
			RuntimeFieldHandle runtimeFieldHandle = moduleHandle2.ResolveFieldHandle(num);
			num2 |= 0x4D455B2FU;
			GClass18.Class8 class8_ = new GClass18.Class17(runtimeFieldHandle);
			num2 = (0x2A0876BFU & num2);
			this.method_0(class8_);
		}
		catch
		{
			this.method_0(new GClass18.Class17(this.module_0.ModuleHandle.ResolveMethodHandle(num)));
		}
		return;
		IL_2BB:
		num2 = 0x2F3107AFU * num2;
		throw new InvalidOperationException();
	}

	// Token: 0x060013E4 RID: 5092 RVA: 0x0000C599 File Offset: 0x0000A799
	private void method_105()
	{
		Exception ex = this.method_1().vmethod_1() as Exception;
		if (ex == null)
		{
			throw new ArgumentException();
		}
		throw ex;
	}

	// Token: 0x060013E5 RID: 5093 RVA: 0x00099824 File Offset: 0x00097A24
	private void method_106()
	{
		uint num;
		do
		{
			num = 0x6FAB241EU;
			if (this.exception_0 != null)
			{
				goto IL_21;
			}
			num = 0x5C20956U % num;
		}
		while (num + 0x42D1215DU == 0U);
		goto IL_30;
		IL_21:
		if (0x693D1CD1U <= num)
		{
			throw this.exception_0;
		}
		IL_30:
		throw new InvalidOperationException();
	}

	// Token: 0x060013E6 RID: 5094 RVA: 0x00099868 File Offset: 0x00097A68
	private void method_107()
	{
		uint num = 0x31FD425BU;
		Type type_;
		do
		{
			GClass18.Class8 @class = this.method_1();
			num = 0xBD308F8U / num;
			int int_ = @class.vmethod_10();
			num = 0x20C86B9DU >> (int)num;
			Type type = this.method_26(int_);
			num += 0x2435708DU;
			type_ = type;
		}
		while ((0x42BD1D8DU ^ num) == 0U);
		GClass18.Class8 class3;
		for (;;)
		{
			GClass18.Class8 class2 = this.method_1();
			num = 0x2A4578C7U - num;
			class3 = class2;
			num = (0x5B010E31U ^ num);
			for (;;)
			{
				num += 0x1E167482U;
				object object_ = class3.vmethod_1();
				num &= 0x50742DE0U;
				bool flag = this.method_33(object_, type_);
				num |= 0x1AC30D2AU;
				if (flag)
				{
					break;
				}
				num = 0x28340771U - num;
				if (0x5F5A7B5CU <= num)
				{
					goto IL_A2;
				}
			}
			num = (0x7AE43E8AU ^ num);
			if (0x69931B14U - num != 0U)
			{
				goto IL_A8;
			}
		}
		IL_A2:
		throw new InvalidCastException();
		IL_A8:
		GClass18.Class8 class8_ = class3;
		num *= 0x286C1DF2U;
		this.method_0(class8_);
	}

	// Token: 0x060013E7 RID: 5095 RVA: 0x0009992C File Offset: 0x00097B2C
	private void method_108()
	{
		uint num = 0x6F9D7A3AU;
		GClass18.Class8 class2;
		for (;;)
		{
			num *= 0x509E5C19U;
			int int_ = this.method_1().vmethod_10();
			num = (0x440327A9U ^ num);
			Type type = this.method_26(int_);
			num %= 0x7892636CU;
			if (0x296328E1U < num)
			{
				GClass18.Class8 @class = this.method_1();
				num = 0x21446E54U << (int)num;
				class2 = @class;
				if (num >= 0x15BB6FD5U)
				{
					goto IL_C6;
				}
				num <<= 4;
				GClass18.Class8 class3 = class2;
				num |= 0x1F144904U;
				object object_ = class3.vmethod_1();
				num -= 0x4E3C2739U;
				Type type_ = type;
				num *= 0x46D91161U;
				bool flag = this.method_33(object_, type_);
				num = 0xC4D65DAU * num;
				if (flag)
				{
					goto IL_C6;
				}
				num += 0x352C1969U;
				if (num - 0x7FBC79B4U != 0U)
				{
					break;
				}
			}
		}
		object object_2 = null;
		num ^= 0x1B254845U;
		GClass18.Class8 class4 = new GClass18.Class15(object_2);
		num += 0x72E4510CU;
		class2 = class4;
		num += 0x7312DD50U;
		IL_C6:
		num *= 0x34345A7AU;
		num ^= 0x29DF0235U;
		GClass18.Class8 class8_ = class2;
		num &= 0x5730417U;
		this.method_0(class8_);
	}

	// Token: 0x060013E8 RID: 5096 RVA: 0x00099A20 File Offset: 0x00097C20
	private void method_109()
	{
		uint num = 0x79D8124EU;
		GClass18.Class8 class2;
		do
		{
			num -= 0x50F13AA4U;
			GClass18.Class8 @class = this.method_1();
			num -= 0x61CB0970U;
			class2 = @class;
			if (0x370F4C52U != num)
			{
				for (;;)
				{
					object obj = class2.vmethod_1();
					num = 0x15000B1AU >> (int)num;
					bool flag = obj is IConvertible;
					num ^= 0x5A01656CU;
					if (flag)
					{
						break;
					}
					num -= 0x2E3C6078U;
					if (num != 0x3DE34EBCU)
					{
						goto Block_5;
					}
				}
				num &= 0x23A244D3U;
			}
			double d = class2.F979B236();
			bool flag2 = double.IsNaN(d);
			num -= 0x3EB94C1CU;
			if (!flag2)
			{
				num *= 0x206A3D19U;
				if (num <= 0x3A3E76E1U)
				{
					continue;
				}
				bool flag3 = double.IsInfinity(d);
				num = (0x4D156671U | num);
				if (!flag3)
				{
					goto IL_FE;
				}
				num ^= 0x9C3396D8U;
			}
			num /= 0x586C6154U;
		}
		while (0x4CEF55AAU >> (int)num == 0U);
		throw new OverflowException();
		Block_5:
		double naN = double.NaN;
		num ^= 0xE9930B6U;
		GClass18.Class8 class3 = new GClass18.Class13(naN);
		num = (0x4D2E0467U | num);
		class2 = class3;
		num += 0xF1F73A96U;
		IL_FE:
		num *= 0x42EA178CU;
		num *= 0x7F83701BU;
		this.method_0(class2);
	}

	// Token: 0x060013E9 RID: 5097 RVA: 0x00099B44 File Offset: 0x00097D44
	private unsafe void method_110()
	{
		IntPtr item = Marshal.AllocHGlobal(this.method_1().C2F10BC1());
		this.list_2.Add(item);
		this.method_0(new GClass18.Class15(Pointer.Box(item.ToPointer(), typeof(void*))));
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x00099B90 File Offset: 0x00097D90
	private void method_111()
	{
		List<IntPtr>.Enumerator enumerator = this.list_2.GetEnumerator();
		uint num = 0x8FACE032U;
		using (List<IntPtr>.Enumerator enumerator2 = enumerator)
		{
			do
			{
				for (;;)
				{
					num <<= 0x1C;
					if (!enumerator2.MoveNext())
					{
						break;
					}
					Marshal.FreeHGlobal(enumerator2.Current);
					num = 0x8FACE032U;
				}
			}
			while (num << 5 != 0U);
		}
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x00099C18 File Offset: 0x00097E18
	public object method_112(object[] object_0, int int_1)
	{
		this.int_0 = int_1;
		this.method_0(new GClass18.Class18(object_0));
		object result;
		try
		{
			for (;;)
			{
				try
				{
					this.dictionary_0[(uint)this.method_3()]();
					bool flag = this.int_0 != 0;
					uint num = 0x669BFFFEU;
					if (flag && 0xACF4AE6U >> (int)num == 0U)
					{
						continue;
					}
				}
				catch (Exception ex)
				{
					uint num = 0x127E31D4U;
					do
					{
						num *= 0x75205CB1U;
						Exception exception_ = ex;
						num = 0x76776021U * num;
						this.method_34(exception_);
					}
					while (0x2870371F << (int)num == 0);
					continue;
				}
				break;
			}
			result = this.method_1().vmethod_1();
		}
		finally
		{
			this.method_111();
		}
		return result;
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x0000C5B4 File Offset: 0x0000A7B4
	// Note: this type is marked as 'beforefieldinit'.
	static GClass18()
	{
		GClass18.dictionary_1 = new Dictionary<int, object>();
		GClass18.dictionary_2 = new Dictionary<MethodBase, DynamicMethod>();
	}

	// Token: 0x04000ACB RID: 2763
	private readonly Dictionary<uint, GClass18.Delegate2> dictionary_0;

	// Token: 0x04000ACC RID: 2764
	private readonly Module module_0;

	// Token: 0x04000ACD RID: 2765
	private readonly long long_0;

	// Token: 0x04000ACE RID: 2766
	private int int_0;

	// Token: 0x04000ACF RID: 2767
	private Type type_0;

	// Token: 0x04000AD0 RID: 2768
	private Stack<GClass18.Class9> stack_0;

	// Token: 0x04000AD1 RID: 2769
	private static readonly Dictionary<int, object> dictionary_1;

	// Token: 0x04000AD2 RID: 2770
	private static readonly Dictionary<MethodBase, DynamicMethod> dictionary_2;

	// Token: 0x04000AD3 RID: 2771
	private List<GClass18.Class8> list_0;

	// Token: 0x04000AD4 RID: 2772
	private List<GClass18.Class38> list_1;

	// Token: 0x04000AD5 RID: 2773
	private Stack<GClass18.Class38> stack_1;

	// Token: 0x04000AD6 RID: 2774
	private Stack<int> stack_2;

	// Token: 0x04000AD7 RID: 2775
	private Exception exception_0;

	// Token: 0x04000AD8 RID: 2776
	private GClass18.Class37 class37_0;

	// Token: 0x04000AD9 RID: 2777
	private List<IntPtr> list_2;

	// Token: 0x020001EB RID: 491
	private static class Class7
	{
	}

	// Token: 0x020001EC RID: 492
	private abstract class Class8
	{
		// Token: 0x060013ED RID: 5101
		public abstract GClass18.Class8 vmethod_0();

		// Token: 0x060013EE RID: 5102
		public abstract object vmethod_1();

		// Token: 0x060013EF RID: 5103
		public abstract void vmethod_2(object object_0);

		// Token: 0x060013F0 RID: 5104 RVA: 0x0000C5CA File Offset: 0x0000A7CA
		public virtual bool vmethod_3()
		{
			return false;
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		public virtual GClass18.Class9 vmethod_4()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x0000C5D4 File Offset: 0x0000A7D4
		public virtual GClass18.Class8 vmethod_5()
		{
			return this;
		}

		// Token: 0x060013F3 RID: 5107 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		public virtual Type vmethod_6()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		public virtual TypeCode vmethod_7()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x0000C5D7 File Offset: 0x0000A7D7
		public virtual bool E6731BF1()
		{
			return Convert.ToBoolean(this.vmethod_1());
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x0000C5E4 File Offset: 0x0000A7E4
		public virtual sbyte vmethod_8()
		{
			return Convert.ToSByte(this.vmethod_1());
		}

		// Token: 0x060013F7 RID: 5111 RVA: 0x0000C5F1 File Offset: 0x0000A7F1
		public virtual short vmethod_9()
		{
			return Convert.ToInt16(this.vmethod_1());
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x0000C5FE File Offset: 0x0000A7FE
		public virtual int vmethod_10()
		{
			return Convert.ToInt32(this.vmethod_1());
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x0000C60B File Offset: 0x0000A80B
		public virtual long AFC5EABA()
		{
			return Convert.ToInt64(this.vmethod_1());
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x0000C618 File Offset: 0x0000A818
		public virtual char vmethod_11()
		{
			return Convert.ToChar(this.vmethod_1());
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x0000C625 File Offset: 0x0000A825
		public virtual byte vmethod_12()
		{
			return Convert.ToByte(this.vmethod_1());
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x0000C632 File Offset: 0x0000A832
		public virtual ushort A7B71418()
		{
			return Convert.ToUInt16(this.vmethod_1());
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x0000C63F File Offset: 0x0000A83F
		public virtual uint vmethod_13()
		{
			return Convert.ToUInt32(this.vmethod_1());
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x0000C64C File Offset: 0x0000A84C
		public virtual ulong vmethod_14()
		{
			return Convert.ToUInt64(this.vmethod_1());
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x0000C659 File Offset: 0x0000A859
		public virtual float C0EC1D52()
		{
			return Convert.ToSingle(this.vmethod_1());
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x0000C666 File Offset: 0x0000A866
		public virtual double F979B236()
		{
			return Convert.ToDouble(this.vmethod_1());
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x00099D18 File Offset: 0x00097F18
		public override string ToString()
		{
			object obj2;
			for (;;)
			{
				object obj = this.vmethod_1();
				uint num = 0x7254E210U;
				obj2 = obj;
				for (;;)
				{
					bool flag = obj2 != null;
					num = 0x208E1A67U * num;
					if (!flag)
					{
						break;
					}
					num ^= 0x11DA3F2EU;
					if (num != 0x79610560U)
					{
						goto Block_0;
					}
				}
				if ((num ^ 0x4A5A79EFU) != 0U)
				{
					goto Block_2;
				}
			}
			Block_0:
			return Convert.ToString(obj2);
			Block_2:
			return null;
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		public virtual IntPtr C2F10BC1()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		public virtual UIntPtr vmethod_15()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		public unsafe virtual void* vmethod_16()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		public virtual object BF2B5883(Type type_0, bool bool_0)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x020001ED RID: 493
	private abstract class Class9 : GClass18.Class8
	{
		// Token: 0x06001407 RID: 5127 RVA: 0x0000C5D4 File Offset: 0x0000A7D4
		public override GClass18.Class9 vmethod_4()
		{
			return this;
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0000C5CA File Offset: 0x0000A7CA
		public override TypeCode vmethod_7()
		{
			return TypeCode.Empty;
		}
	}

	// Token: 0x020001EE RID: 494
	private sealed class Class10 : GClass18.Class9
	{
		// Token: 0x0600140A RID: 5130 RVA: 0x0000C67B File Offset: 0x0000A87B
		public Class10(int int_1)
		{
			this.int_0 = int_1;
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x0000C68A File Offset: 0x0000A88A
		public override Type vmethod_6()
		{
			return typeof(int);
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x0000C696 File Offset: 0x0000A896
		public override TypeCode vmethod_7()
		{
			return TypeCode.Int32;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x0000C69A File Offset: 0x0000A89A
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class10(this.int_0);
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x0000C6A7 File Offset: 0x0000A8A7
		public override object vmethod_1()
		{
			return this.int_0;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x00099D68 File Offset: 0x00097F68
		public override void vmethod_2(object object_0)
		{
			uint num = 0x5830B45U;
			do
			{
				num = 0x6C431ED2U / num;
				num /= 0x274E7C9CU;
				this.int_0 = Convert.ToInt32(object_0);
			}
			while (0x105C2A05U < num);
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x0000C6B4 File Offset: 0x0000A8B4
		public override bool E6731BF1()
		{
			return this.int_0 != 0;
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x0000C6BF File Offset: 0x0000A8BF
		public override sbyte vmethod_8()
		{
			return (sbyte)this.int_0;
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x0000C6C8 File Offset: 0x0000A8C8
		public override short vmethod_9()
		{
			return (short)this.int_0;
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x0000C6D1 File Offset: 0x0000A8D1
		public override int vmethod_10()
		{
			return this.int_0;
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x0000C6D9 File Offset: 0x0000A8D9
		public override long AFC5EABA()
		{
			return (long)this.int_0;
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x0000C6E2 File Offset: 0x0000A8E2
		public override char vmethod_11()
		{
			return (char)this.int_0;
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x0000C6EB File Offset: 0x0000A8EB
		public override byte vmethod_12()
		{
			return (byte)this.int_0;
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x0000C6E2 File Offset: 0x0000A8E2
		public override ushort A7B71418()
		{
			return (ushort)this.int_0;
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x0000C6D1 File Offset: 0x0000A8D1
		public override uint vmethod_13()
		{
			return (uint)this.int_0;
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x0000C6F4 File Offset: 0x0000A8F4
		public override ulong vmethod_14()
		{
			return (ulong)this.int_0;
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x0000C6FD File Offset: 0x0000A8FD
		public override float C0EC1D52()
		{
			return (float)this.int_0;
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x0000C706 File Offset: 0x0000A906
		public override double F979B236()
		{
			return (double)this.int_0;
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x0000C70F File Offset: 0x0000A90F
		public override IntPtr C2F10BC1()
		{
			return new IntPtr(this.int_0);
		}

		// Token: 0x0600141D RID: 5149 RVA: 0x0000C71C File Offset: 0x0000A91C
		public override UIntPtr vmethod_15()
		{
			return new UIntPtr((uint)this.int_0);
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x0000C729 File Offset: 0x0000A929
		public override GClass18.Class8 vmethod_5()
		{
			return new GClass18.Class35((uint)this.int_0);
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x00099DA0 File Offset: 0x00097FA0
		public override object BF2B5883(Type type_0, bool bool_0)
		{
			uint num;
			for (;;)
			{
				num = 0x65152AF3U;
				if (type_0 == typeof(IntPtr))
				{
					num = 0x66C25075U / num;
					if ((num ^ 0x2ED1108CU) == 0U)
					{
						continue;
					}
				}
				else
				{
					num = (0x7C9E51C9U ^ num);
					RuntimeTypeHandle handle = typeof(UIntPtr).TypeHandle;
					num = 0x35EE07F3U - num;
					Type typeFromHandle = Type.GetTypeFromHandle(handle);
					num += 0x75A045F8U;
					if (type_0 == typeFromHandle)
					{
						num /= 0x49B5285AU;
						if (0x3A906C6DU * num == 0U)
						{
							continue;
						}
						if (!bool_0)
						{
							goto IL_2E9;
						}
						num = (0x270F431EU ^ num);
						if (num < 0x314B37CCU)
						{
							break;
						}
						continue;
					}
					else if ((num & 0x6904328BU) != 0U)
					{
						TypeCode typeCode = Type.GetTypeCode(type_0);
						num = (0x1AC1199EU | num);
						TypeCode typeCode2 = typeCode;
						object obj = typeCode2;
						num |= 0x626523D4U;
						object obj2 = num + 0x5180406U;
						num = 0xE9B60ACU >> (int)num;
						object obj3 = obj - obj2;
						num /= 0x73A543ACU;
						switch (obj3)
						{
						case 0:
							num = 0x7A00492AU >> (int)num;
							num |= 0x78997BBDU;
							if (!bool_0)
							{
								num = 0x41C714E4U - num;
								if (0x501B4D6D << (int)num != 0)
								{
									goto Block_9;
								}
								continue;
							}
							else
							{
								num &= 0x3EBD1A0CU;
								if (num << 0x14 != 0U)
								{
									goto Block_10;
								}
								goto IL_28D;
							}
							break;
						case 1:
							goto IL_36D;
						case 2:
							goto IL_3B7;
						case 3:
							if (0x57D463C1U != num)
							{
								num = 0x21C769ACU - num;
								if (!bool_0)
								{
									goto IL_3F9;
								}
								num = 0x30F30BDDU * num;
								if (0x75AA4FACU / num != 0U)
								{
									goto Block_13;
								}
								goto IL_28D;
							}
							break;
						case 4:
							num %= 0x74E40903U;
							if (num < 0x3EAB5D0FU)
							{
								goto Block_14;
							}
							break;
						case 5:
							num /= 0x5EE57BE5U;
							if (0x16A20334U < num)
							{
								goto IL_28D;
							}
							num %= 0x6C066645U;
							if (!bool_0)
							{
								num = (0x7841118AU & num);
								if (0x50984FD3U >> (int)num != 0U)
								{
									goto Block_17;
								}
							}
							else
							{
								num = (0x38AD46D3U & num);
								if (num < 0x7E9B27C6U)
								{
									goto Block_18;
								}
								continue;
							}
							break;
						case 6:
							if (num <= 0x2D7D1969U)
							{
								goto Block_19;
							}
							continue;
						case 7:
							num += 0x409D4B2DU;
							if (!bool_0)
							{
								num = 0x33756DB7U >> (int)num;
								if (num <= 0x24C1564AU)
								{
									goto Block_21;
								}
								continue;
							}
							else
							{
								if (0x4EBD17BDU / num != 0U)
								{
									goto Block_22;
								}
								continue;
							}
							break;
						case 8:
							goto IL_512;
						case 9:
							if (0x140E6C87U == num)
							{
								continue;
							}
							num ^= 0x357C24B4U;
							if (bool_0)
							{
								goto IL_539;
							}
							num = 0x7AAD3086U >> (int)num;
							if (num * 0x7A3F56FEU != 0U)
							{
								goto Block_25;
							}
							continue;
						default:
							if (0x5E3F1AE6U > num)
							{
								goto Block_7;
							}
							goto IL_298;
						}
					}
				}
				for (;;)
				{
					IL_2AB:
					int size = IntPtr.Size;
					uint num2 = num - 0xFFFFFFFDU;
					num = 0x63B36846U + num;
					if (size == num2)
					{
						break;
					}
					num = (0x76BB7F9CU ^ num);
					num = (0x3BD03076U & num);
					if (bool_0)
					{
						goto IL_5B1;
					}
					num <<= 0x17;
					if (0x4B325932U >= num)
					{
						goto Block_27;
					}
				}
				num = 0x408750E5U + num;
				IL_28D:
				num += 0x4BF97F1EU;
				if (!bool_0)
				{
					if (0x4A61766BU < num)
					{
						goto Block_29;
					}
					continue;
				}
				IL_298:
				num = (0x68E4475DU | num);
				if (num <= 0x685C203BU)
				{
					goto IL_2AB;
				}
				goto IL_57D;
			}
			num ^= 0x11CD366CU;
			uint value = (uint)this.int_0;
			num += 0xF218D2DDU;
			goto IL_310;
			Block_7:
			num ^= 0U;
			goto IL_512;
			Block_9:
			sbyte b = checked((sbyte)this.int_0);
			goto IL_367;
			Block_10:
			uint num3 = (uint)this.int_0;
			num = (0x2FD67FB5U ^ num);
			sbyte b2 = (sbyte)num3;
			num = (0x32A62C4CU | num);
			b = b2;
			num ^= 0xF0C2F4D8U;
			goto IL_367;
			Block_13:
			uint num4 = (uint)this.int_0;
			num %= 0x7446306EU;
			ushort num5 = (ushort)num4;
			num -= 0x29E47E0FU;
			ushort num6 = num5;
			num ^= 0x59521F6DU;
			goto IL_438;
			Block_14:
			int num7;
			if (!bool_0)
			{
				num <<= 5;
				num7 = this.int_0;
			}
			else
			{
				uint num8 = (uint)this.int_0;
				num = (0x19800911U & num);
				num7 = checked((int)num8);
				num += 0U;
			}
			return num7;
			Block_17:
			num -= 0x3345155BU;
			uint num9 = (uint)this.int_0;
			num &= 0x4D5C2A0AU;
			uint num10 = num9;
			goto IL_49E;
			Block_18:
			num10 = (uint)this.int_0;
			num ^= 0x4C182A00U;
			goto IL_49E;
			Block_19:
			num = (0x26DA41A6U ^ num);
			long num12;
			if (!bool_0)
			{
				num = 0x267C4F39U * num;
				num -= 0x68D25C6U;
				long num11 = (long)this.int_0;
				num &= 0x6C1C649AU;
				num12 = num11;
			}
			else
			{
				num12 = (long)((ulong)this.int_0);
				num += 0x4139DE6AU;
			}
			return num12;
			Block_21:
			uint num13 = (uint)this.int_0;
			num = (0x4293590BU | num);
			uint num14 = num13;
			goto IL_50C;
			Block_22:
			num %= 0x15C02094U;
			num14 = (uint)this.int_0;
			num ^= 0x578ED1AEU;
			goto IL_50C;
			Block_25:
			num = 0x12EA7723U / num;
			double num15 = (double)this.int_0;
			num %= 0x52135CAEU;
			double num16 = num15;
			goto IL_567;
			Block_27:
			long value2 = (long)this.int_0;
			goto IL_5C8;
			Block_29:
			int value3 = this.int_0;
			goto IL_595;
			IL_2E9:
			num = (0x28DB4851U ^ num);
			checked
			{
				value = (uint)this.int_0;
				IL_310:
				num = 0x64F85966U >> (int)num;
				UIntPtr uintPtr = new UIntPtr(value);
				num = (0x7FF45D33U | num);
				return uintPtr;
				IL_367:
				return b;
				IL_36D:
				byte b3;
				if (!bool_0)
				{
					num |= 0x13B256A2U;
					num = (0xFD2EA3U | num);
					b3 = (byte)this.int_0;
				}
				else
				{
					num = (0x3AF1714AU ^ num);
					byte b4 = (byte)((uint)this.int_0);
					num = (0x1827153FU ^ num);
					b3 = b4;
					num ^= 0x31291AD6U;
				}
				num = (0x7E5D3310U & num);
				return b3;
				IL_3B7:;
			}
			short num18;
			if (!bool_0)
			{
				num ^= 0x7F1B2811U;
				num ^= 0x543857FDU;
				short num17 = (short)this.int_0;
				num = 0x4D0F4BFDU % num;
				num18 = num17;
			}
			else
			{
				num -= 0x1F4D63C2U;
				num18 = checked((short)((uint)this.int_0));
				num += 0x41392FD3U;
			}
			return num18;
			IL_3F9:
			num = 0x5D8564F4U << (int)num;
			num &= 0x47E22876U;
			num6 = checked((ushort)this.int_0);
			IL_438:
			num <<= 5;
			return num6;
			IL_49E:
			return num10;
			IL_50C:
			return num14;
			IL_512:
			num = (0x3A107A07U ^ num);
			throw new ArgumentException();
			IL_539:
			num = (0x208C4F2EU | num);
			int num19 = this.int_0;
			num -= 0x47992692U;
			double num20 = num19;
			num = 0x167A7D48U >> (int)num;
			num16 = num20;
			num ^= 0x31070U;
			IL_567:
			num &= 0x77F8145CU;
			return num16;
			IL_57D:
			uint num21 = (uint)this.int_0;
			num = 0x275F7AFFU * num;
			value3 = checked((int)num21);
			num ^= 0xCD4B1DEBU;
			IL_595:
			num /= 0x1C014534U;
			return new IntPtr(value3);
			IL_5B1:
			num &= 0x335105A3U;
			value2 = (long)((ulong)this.int_0);
			num += 0x17FFFFFEU;
			IL_5C8:
			IntPtr intPtr = new IntPtr(value2);
			num %= 0x98C1D5BU;
			return intPtr;
		}

		// Token: 0x04000ADA RID: 2778
		private int int_0;
	}

	// Token: 0x020001EF RID: 495
	private sealed class Class11 : GClass18.Class9
	{
		// Token: 0x06001420 RID: 5152 RVA: 0x0009A388 File Offset: 0x00098588
		public Class11(long long_1)
		{
			uint num = 0x1D4D1486U;
			do
			{
				base..ctor();
				num &= 0x5C465143U;
			}
			while (0x6912303CU >> (int)num == 0U);
			this.long_0 = long_1;
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x0000C736 File Offset: 0x0000A936
		public override Type vmethod_6()
		{
			return typeof(long);
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x0000C742 File Offset: 0x0000A942
		public override TypeCode vmethod_7()
		{
			return TypeCode.Int64;
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x0000C746 File Offset: 0x0000A946
		public override GClass18.Class8 vmethod_5()
		{
			return new GClass18.Class36((ulong)this.long_0);
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x0000C753 File Offset: 0x0000A953
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class11(this.long_0);
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x0000C760 File Offset: 0x0000A960
		public override object vmethod_1()
		{
			return this.long_0;
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x0009A3C0 File Offset: 0x000985C0
		public override void vmethod_2(object object_0)
		{
			uint num = 0x5445E7FU;
			do
			{
				num /= 0x41950E79U;
				num = (0x2A7B6C2BU | num);
				long num2 = Convert.ToInt64(object_0);
				num *= 0x2D682BEFU;
				this.long_0 = num2;
			}
			while (0x516E64EFU * num == 0U);
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x0000C76D File Offset: 0x0000A96D
		public override bool E6731BF1()
		{
			return this.long_0 != 0L;
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x0000C780 File Offset: 0x0000A980
		public override char vmethod_11()
		{
			return (char)this.long_0;
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x0000C789 File Offset: 0x0000A989
		public override byte vmethod_12()
		{
			return (byte)this.long_0;
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0000C792 File Offset: 0x0000A992
		public override sbyte vmethod_8()
		{
			return (sbyte)this.long_0;
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x0000C79B File Offset: 0x0000A99B
		public override short vmethod_9()
		{
			return (short)this.long_0;
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x0000C7A4 File Offset: 0x0000A9A4
		public override int vmethod_10()
		{
			return (int)this.long_0;
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x0000C7AD File Offset: 0x0000A9AD
		public override long AFC5EABA()
		{
			return this.long_0;
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x0000C780 File Offset: 0x0000A980
		public override ushort A7B71418()
		{
			return (ushort)this.long_0;
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x0000C7B5 File Offset: 0x0000A9B5
		public override uint vmethod_13()
		{
			return (uint)this.long_0;
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x0000C7AD File Offset: 0x0000A9AD
		public override ulong vmethod_14()
		{
			return (ulong)this.long_0;
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x0000C7BE File Offset: 0x0000A9BE
		public override float C0EC1D52()
		{
			return (float)this.long_0;
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x0000C7C7 File Offset: 0x0000A9C7
		public override double F979B236()
		{
			return (double)this.long_0;
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x0009A400 File Offset: 0x00098600
		public override IntPtr C2F10BC1()
		{
			uint num;
			do
			{
				int size = IntPtr.Size;
				num = 0x3E7B0BFFU;
				if (size != 4 && num != 0x438D6C05U)
				{
					goto Block_2;
				}
				num = (0x3BDD2964U | num);
			}
			while (0x2B237DE0U >= num);
			int num2 = (int)this.long_0;
			num = 0x75835755U >> (int)num;
			long num3 = (long)num2;
			num += 0x117C52E8U;
			long value = num3;
			num += 0x8760BC3DU;
			goto IL_60;
			Block_2:
			num += 0x5A620326U;
			value = this.long_0;
			IL_60:
			num = (0x5BE53E15U & num);
			return new IntPtr(value);
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x0009A47C File Offset: 0x0009867C
		public override UIntPtr vmethod_15()
		{
			uint num = 0x55830B14U;
			for (;;)
			{
				int size = UIntPtr.Size;
				num = 0x184C1C6CU / num;
				uint num2 = num + 4U;
				num ^= 0x3CF73F06U;
				if (size != num2)
				{
					break;
				}
				num = 0x71E3BF4U << (int)num;
				if (0x74F3323CU % num != 0U)
				{
					goto IL_45;
				}
			}
			ulong value = (ulong)this.long_0;
			goto IL_5D;
			IL_45:
			num = (0x6D476F24U & num);
			value = (ulong)((uint)this.long_0);
			num += 0xF7F0D206U;
			IL_5D:
			num ^= 0x71FA0543U;
			return new UIntPtr(value);
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x0009A4F4 File Offset: 0x000986F4
		public override object BF2B5883(Type type_0, bool bool_0)
		{
			uint num;
			for (;;)
			{
				RuntimeTypeHandle handle = typeof(IntPtr).TypeHandle;
				num = 0x1C34F76U;
				if (type_0 == Type.GetTypeFromHandle(handle))
				{
					break;
				}
				if (num != 0x40750E27U)
				{
					num = (0x72B9422FU | num);
					if (type_0 == typeof(UIntPtr))
					{
						goto Block_2;
					}
					num /= 0x2F1B5DADU;
					if (0x4C6F24AEU >= num)
					{
						uint typeCode = (uint)Type.GetTypeCode(type_0);
						num |= 0x145D306BU;
						switch (typeCode - (num - 0x145D3066U))
						{
						case 0U:
							num = (0x490B4642U ^ num);
							if (0x277B70A6U >> (int)num == 0U)
							{
								continue;
							}
							if (!bool_0)
							{
								num = 0x76CD10EAU << (int)num;
								if (num + 0xE993FD6U != 0U)
								{
									goto Block_7;
								}
								continue;
							}
							else
							{
								num %= 0x5EEA6B0BU;
								if ((num ^ 0x13C1A36U) != 0U)
								{
									goto Block_8;
								}
								continue;
							}
							break;
						case 1U:
							if (num > 0x73DF2C4BU)
							{
								continue;
							}
							num /= 0x74BA79A7U;
							if (!bool_0)
							{
								num %= 0x583C35C2U;
								if ((num ^ 0x381511ACU) != 0U)
								{
									goto Block_11;
								}
								continue;
							}
							else
							{
								num ^= 0x5F951A6CU;
								if (num >= 0xE9F6160U)
								{
									goto Block_12;
								}
								continue;
							}
							break;
						case 2U:
							goto IL_286;
						case 3U:
							goto IL_2C6;
						case 4U:
							goto IL_32C;
						case 5U:
							goto IL_397;
						case 6U:
							num |= 0xC4C181FU;
							if (bool_0)
							{
								goto IL_3ED;
							}
							num = 0x356C2A32U >> (int)num;
							if ((0x49B964E6U & num) == 0U)
							{
								goto Block_14;
							}
							continue;
						case 7U:
							num = 0x1B0A263EU - num;
							if (0x28AA3EF5U <= num)
							{
								continue;
							}
							num = (0x42EB491AU | num);
							if (!bool_0)
							{
								if (num < 0x6112797AU)
								{
									goto Block_17;
								}
								continue;
							}
							else
							{
								if ((0x6BF46867U ^ num) != 0U)
								{
									goto Block_18;
								}
								continue;
							}
							break;
						case 8U:
							goto IL_4B1;
						case 9U:
							num = 0x589924B0U % num;
							if (!bool_0)
							{
								goto IL_4BF;
							}
							num -= 0x5BAE6ED8U;
							if (num >> 9 != 0U)
							{
								goto Block_20;
							}
							continue;
						}
						goto Block_4;
					}
					goto IL_4F6;
				}
			}
			num = (0x677A23F3U & num);
			if (num >> 0x13 != 0U)
			{
				goto IL_4F6;
			}
			goto IL_501;
			Block_2:
			if (0xE494F68U <= num)
			{
				goto IL_431;
			}
			goto IL_501;
			Block_4:
			if (0x615268A3U / num != 0U)
			{
				num += 0U;
				goto IL_4B1;
			}
			goto IL_4F6;
			Block_7:
			num *= 0x33C03697U;
			sbyte b = (sbyte)this.long_0;
			num -= 0x3E413D52U;
			sbyte b2 = b;
			goto IL_239;
			Block_8:
			ulong num2 = (ulong)this.long_0;
			num <<= 0x1D;
			b2 = checked((sbyte)num2);
			num += 0xAE6ACEAEU;
			goto IL_239;
			Block_11:
			byte b3 = (byte)this.long_0;
			num ^= 0x45483611U;
			byte b4 = b3;
			goto IL_278;
			Block_12:
			num += 0x7D8A24D3U;
			byte b5 = (byte)(checked((ulong)this.long_0));
			num = (0x3A1238BFU ^ num);
			b4 = b5;
			num += 0x5E3B2E91U;
			goto IL_278;
			Block_14:
			long num3 = this.long_0;
			goto IL_41D;
			Block_17:
			num = (0x463116D0U ^ num);
			ulong num4 = checked((ulong)this.long_0);
			goto IL_4A3;
			Block_18:
			num = (0x214D0432U & num);
			num4 = (ulong)this.long_0;
			num ^= 0x93EF19U;
			goto IL_4A3;
			Block_20:
			long num5 = this.long_0;
			num = (0x4B672514U & num);
			double num6 = num5;
			num = 0x19641304U % num;
			double num7 = num6;
			num += 0x602581A3U;
			goto IL_4F0;
			IL_239:
			num = (0x32B626A7U | num);
			return b2;
			IL_278:
			num = 0x20E04433U % num;
			return b4;
			IL_286:
			short num9;
			if (!bool_0)
			{
				num /= 0x5CF267C0U;
				short num8 = (short)this.long_0;
				num = 0x1B24658U >> (int)num;
				num9 = num8;
			}
			else
			{
				num = (0x70E45CAAU ^ num);
				num9 = checked((short)((ulong)this.long_0));
				num += 0x9CF8D997U;
			}
			return num9;
			IL_2C6:
			ushort num11;
			if (!bool_0)
			{
				num = 0x5A79658BU + num;
				num <<= 3;
				ushort num10 = (ushort)this.long_0;
				num += 0xFEF1858U;
				num11 = num10;
			}
			else
			{
				num >>= 1;
				if (0x2F9E2ED2U / num == 0U)
				{
					goto IL_509;
				}
				num = (0x6369330DU ^ num);
				uint num12 = (uint)this.long_0;
				num = (0x3C8C5784U | num);
				ushort num13 = (ushort)num12;
				num <<= 4;
				num11 = num13;
				num += 0xA9A3CC48U;
			}
			return num11;
			IL_32C:
			num = 0x1D760D82U / num;
			num ^= 0x2C0D1FABU;
			int num15;
			if (!bool_0)
			{
				num = 0x2BF057D0U * num;
				num &= 0x3FFB3FE2U;
				int num14 = (int)this.long_0;
				num >>= 5;
				num15 = num14;
			}
			else
			{
				if (num >= 0x2F912306U)
				{
					goto IL_431;
				}
				ulong num16 = (ulong)this.long_0;
				num = 0x7EAC6EE1U >> (int)num;
				int num17 = (int)num16;
				num -= 0x594D7FD1U;
				num15 = num17;
				num += 0x5B1C14B7U;
			}
			return num15;
			IL_397:
			num += 0x237B6D35U;
			uint num19;
			if (!bool_0)
			{
				if (num >> 0x1B == 0U)
				{
					goto IL_4F6;
				}
				uint num18 = (uint)this.long_0;
				num = 0x385F25B5U + num;
				num19 = num18;
			}
			else
			{
				ulong num20 = (ulong)this.long_0;
				num &= 0x664E5037U;
				num19 = checked((uint)num20);
				num ^= 0x567FD375U;
			}
			num &= 0xA8D6984U;
			return num19;
			IL_3ED:
			if (num > 0x35807391U)
			{
				goto IL_431;
			}
			num ^= 0x99455F8U;
			ulong num21 = (ulong)this.long_0;
			num %= 0x5DE26C12U;
			long num22 = (long)num21;
			num = 0x286143ABU * num;
			num3 = num22;
			num ^= 0xDD5D7E2DU;
			IL_41D:
			num = 0x16F198EU >> (int)num;
			return num3;
			IL_431:
			ulong value;
			if (!bool_0)
			{
				num |= 0x3F4148C8U;
				num = (0xDF542FFU & num);
				ulong num23 = (ulong)this.long_0;
				num = 0x2A150AF1U >> (int)num;
				value = num23;
			}
			else
			{
				value = (ulong)this.long_0;
				num ^= 0x73FB4F7FU;
			}
			num &= 0x643F48C5U;
			return new UIntPtr(value);
			IL_4A3:
			num %= 0x70427337U;
			return num4;
			IL_4B1:
			num = 0xB884031U / num;
			throw new ArgumentException();
			IL_4BF:
			num ^= 0x659B2F9BU;
			num7 = (double)this.long_0;
			IL_4F0:
			return num7;
			IL_4F6:
			num *= 0x787A18B6U;
			if (bool_0)
			{
				goto IL_509;
			}
			IL_501:
			long value2 = this.long_0;
			goto IL_521;
			IL_509:
			ulong num24 = (ulong)this.long_0;
			num = 0x47775BC9U * num;
			value2 = checked((long)num24);
			num += 0xE1735AA0U;
			IL_521:
			num ^= 0x3660463EU;
			IntPtr intPtr = new IntPtr(value2);
			num = 0x52AB2542U + num;
			return intPtr;
		}

		// Token: 0x04000ADB RID: 2779
		private long long_0;
	}

	// Token: 0x020001F0 RID: 496
	private sealed class Class12 : GClass18.Class9
	{
		// Token: 0x06001436 RID: 5174 RVA: 0x0000C7D0 File Offset: 0x0000A9D0
		public Class12(float float_1)
		{
			this.float_0 = float_1;
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x0000C7DF File Offset: 0x0000A9DF
		public override Type vmethod_6()
		{
			return typeof(float);
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x0000C7EB File Offset: 0x0000A9EB
		public override TypeCode vmethod_7()
		{
			return TypeCode.Single;
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x0000C7EF File Offset: 0x0000A9EF
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class12(this.float_0);
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x0000C7FC File Offset: 0x0000A9FC
		public override object vmethod_1()
		{
			return this.float_0;
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x0009AA3C File Offset: 0x00098C3C
		public override void vmethod_2(object object_0)
		{
			uint num = 0x4BAC49D9U;
			do
			{
				num = 0x49C477CBU - num;
				num ^= 0x50C04A23U;
				float num2 = Convert.ToSingle(object_0);
				num ^= 0x183A6DB7U;
				this.float_0 = num2;
			}
			while ((num & 0x70672807U) == 0U);
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x0000C809 File Offset: 0x0000AA09
		public override bool E6731BF1()
		{
			return Convert.ToBoolean(this.float_0);
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x0000C816 File Offset: 0x0000AA16
		public override sbyte vmethod_8()
		{
			return (sbyte)this.float_0;
		}

		// Token: 0x0600143E RID: 5182 RVA: 0x0000C81F File Offset: 0x0000AA1F
		public override short vmethod_9()
		{
			return (short)this.float_0;
		}

		// Token: 0x0600143F RID: 5183 RVA: 0x0000C828 File Offset: 0x0000AA28
		public override int vmethod_10()
		{
			return (int)this.float_0;
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x0000C831 File Offset: 0x0000AA31
		public override long AFC5EABA()
		{
			return (long)this.float_0;
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x0000C83A File Offset: 0x0000AA3A
		public override char vmethod_11()
		{
			return (char)this.float_0;
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x0000C843 File Offset: 0x0000AA43
		public override byte vmethod_12()
		{
			return (byte)this.float_0;
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x0000C83A File Offset: 0x0000AA3A
		public override ushort A7B71418()
		{
			return (ushort)this.float_0;
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x0000C84C File Offset: 0x0000AA4C
		public override uint vmethod_13()
		{
			return (uint)this.float_0;
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x0000C855 File Offset: 0x0000AA55
		public override ulong vmethod_14()
		{
			return (ulong)this.float_0;
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x0000C85E File Offset: 0x0000AA5E
		public override float C0EC1D52()
		{
			return this.float_0;
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x0000C866 File Offset: 0x0000AA66
		public override double F979B236()
		{
			return (double)this.float_0;
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x0009AA7C File Offset: 0x00098C7C
		public override IntPtr C2F10BC1()
		{
			uint num2;
			do
			{
				int size = IntPtr.Size;
				int num = 4;
				num2 = 0x2AA87EC4U;
				if (size != num && num2 != 0x43D947B7U)
				{
					goto Block_2;
				}
			}
			while ((num2 & 0x2DFB5F41U) == 0U);
			num2 = 0x7EB13B20U % num2;
			int num3 = (int)this.float_0;
			num2 /= 0x52E43477U;
			long value = (long)num3;
			num2 += 0x83E1A1C1U;
			goto IL_62;
			Block_2:
			num2 *= 0x36056546U;
			long num4 = (long)this.float_0;
			num2 ^= 0x76085C59U;
			value = num4;
			IL_62:
			return new IntPtr(value);
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x0009AAF0 File Offset: 0x00098CF0
		public override UIntPtr vmethod_15()
		{
			uint num = 0x34F53B1DU;
			for (;;)
			{
				if (IntPtr.Size != (int)(num - 0x34F53B19U))
				{
					num = 0x3BD95596U - num;
					if ((num ^ 0x736B2B1DU) != 0U)
					{
						goto IL_3B;
					}
				}
				else
				{
					num = 0x79904EB8U % num;
					if (0x3508771CU >= num)
					{
						break;
					}
				}
			}
			num = 0x2FC10939U << (int)num;
			uint num2 = (uint)this.float_0;
			num += 0x30C4354EU;
			ulong num3 = (ulong)num2;
			num |= 0x1EBE2F45U;
			ulong value = num3;
			num += 0x1643D7A2U;
			goto IL_88;
			IL_3B:
			num = 0x369155F8U << (int)num;
			ulong num4 = (ulong)this.float_0;
			num ^= 0x654216F1U;
			value = num4;
			IL_88:
			num = 0x735B4778U % num;
			return new UIntPtr(value);
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0009AB94 File Offset: 0x00098D94
		public override object BF2B5883(Type type_0, bool bool_0)
		{
			uint num = 0x39395FCFU;
			for (;;)
			{
				if (type_0 != typeof(IntPtr))
				{
					for (;;)
					{
						num *= 0x3424201FU;
						if (num == 0x65B62D29U)
						{
							goto IL_294;
						}
						num = 0x380E4C82U + num;
						RuntimeTypeHandle handle = typeof(UIntPtr).TypeHandle;
						num += 0x222C2593U;
						Type typeFromHandle = Type.GetTypeFromHandle(handle);
						num = 0x23400D36U % num;
						if (type_0 == typeFromHandle)
						{
							goto Block_1;
						}
						if (0x49C97891U + num != 0U)
						{
							num = 0x59AB6279U >> (int)num;
							TypeCode typeCode = Type.GetTypeCode(type_0);
							TypeCode typeCode2 = typeCode;
							num = 0x9516A44U / num;
							uint num2 = num + 0xFFF95640U;
							num = (0x26A44EBDU ^ num);
							switch (typeCode2 - num2)
							{
							case 0:
								num /= 0x1A044B6EU;
								if (!bool_0)
								{
									goto IL_DB;
								}
								if ((0x3EDC6F7DU & num) != 0U)
								{
									goto Block_5;
								}
								continue;
							case 1:
								goto IL_144;
							case 2:
								goto IL_167;
							case 3:
								goto IL_1F2;
							case 4:
								goto IL_217;
							case 5:
								goto IL_242;
							case 6:
								goto IL_ED;
							case 7:
								if (num != 0x79B418E2U)
								{
									goto Block_6;
								}
								continue;
							}
							goto Block_3;
						}
						goto IL_294;
					}
					IL_DB:
					num = 0x7911253U / num;
					if (0x383A750FU > num)
					{
						goto Block_8;
					}
					continue;
					IL_ED:
					if (num + 0x4D2669F7U != 0U)
					{
						goto Block_9;
					}
					continue;
					Block_3:
					num += 0U;
					goto IL_ED;
				}
				if (num < 0x627D166DU)
				{
					goto IL_294;
				}
			}
			Block_1:
			goto IL_1C8;
			Block_5:
			num = (0x3701608BU ^ num);
			sbyte b = checked((sbyte)((uint)this.float_0));
			num += 0xD08FB1C9U;
			goto IL_136;
			Block_6:
			num = 0x67CA642AU >> (int)num;
			checked
			{
				ulong num3 = (ulong)this.float_0;
				num = 0x68AF1DA5U >> (int)num;
				return num3;
				Block_8:
				b = (sbyte)this.float_0;
				goto IL_136;
				Block_9:
				throw new ArgumentException();
				IL_136:;
			}
			num -= 0x7F0B1BDAU;
			return b;
			IL_144:
			num = 0x4BAF4AAEU >> (int)num;
			byte b2 = (byte)this.float_0;
			num = 0x43450ABDU - num;
			return b2;
			IL_167:
			if (num % 0x7CFC35CCU != 0U)
			{
				num += 0x416167D1U;
				short num5;
				if (!bool_0)
				{
					num = (0x2781725U ^ num);
					short num4 = (short)this.float_0;
					num <<= 0x16;
					num5 = num4;
				}
				else
				{
					num = 0x31684EF3U << (int)num;
					num >>= 0x11;
					uint num6 = (uint)this.float_0;
					num &= 0x1ED21620U;
					num5 = checked((short)num6);
					num ^= 0x1B000000U;
				}
				return num5;
			}
			IL_1C8:
			num /= 0x41DF1F8FU;
			ulong num7 = (ulong)this.float_0;
			num /= 0x52AC4642U;
			UIntPtr uintPtr = new UIntPtr(num7);
			num = 0x19581C9CU * num;
			return uintPtr;
			IL_1F2:
			num >>= 0x1D;
			num = 0x21BD4CA0U % num;
			uint num11;
			checked
			{
				ushort num8 = (ushort)this.float_0;
				num /= 0x7F9A276DU;
				return num8;
				IL_217:
				num <<= 0xE;
				if (0x69921C20U <= num)
				{
					int num9 = (int)this.float_0;
					num = 0x2FB868A9U << (int)num;
					return num9;
				}
				goto IL_294;
				IL_242:
				uint num10 = (uint)this.float_0;
				num = 0x14976A66U >> (int)num;
				num11 = num10;
			}
			num += 0x787C121FU;
			return num11;
			IL_294:
			long value = checked((long)this.float_0);
			num = 0x7EC62102U + num;
			return new IntPtr(value);
		}

		// Token: 0x04000ADC RID: 2780
		private float float_0;
	}

	// Token: 0x020001F1 RID: 497
	private sealed class Class13 : GClass18.Class9
	{
		// Token: 0x0600144B RID: 5195 RVA: 0x0009AE50 File Offset: 0x00099050
		public Class13(double double_1)
		{
			uint num = 0x1A56070CU;
			do
			{
				num %= 0x29CC3DA7U;
				this.double_0 = double_1;
			}
			while (0x4077FA0U == num);
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x0000C86F File Offset: 0x0000AA6F
		public override Type vmethod_6()
		{
			return typeof(double);
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x0000C87B File Offset: 0x0000AA7B
		public override TypeCode vmethod_7()
		{
			return TypeCode.Double;
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x0000C87F File Offset: 0x0000AA7F
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class13(this.double_0);
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x0000C88C File Offset: 0x0000AA8C
		public override object vmethod_1()
		{
			return this.double_0;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x0000C899 File Offset: 0x0000AA99
		public override void vmethod_2(object object_0)
		{
			this.double_0 = (double)object_0;
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x0000C8A7 File Offset: 0x0000AAA7
		public override bool E6731BF1()
		{
			return Convert.ToBoolean(this.double_0);
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x0000C8B4 File Offset: 0x0000AAB4
		public override sbyte vmethod_8()
		{
			return (sbyte)this.double_0;
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x0000C8BD File Offset: 0x0000AABD
		public override short vmethod_9()
		{
			return (short)this.double_0;
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x0000C8C6 File Offset: 0x0000AAC6
		public override int vmethod_10()
		{
			return (int)this.double_0;
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x0000C8CF File Offset: 0x0000AACF
		public override long AFC5EABA()
		{
			return (long)this.double_0;
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x0000C8D8 File Offset: 0x0000AAD8
		public override char vmethod_11()
		{
			return (char)this.double_0;
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x0000C8E1 File Offset: 0x0000AAE1
		public override byte vmethod_12()
		{
			return (byte)this.double_0;
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x0000C8D8 File Offset: 0x0000AAD8
		public override ushort A7B71418()
		{
			return (ushort)this.double_0;
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0000C8EA File Offset: 0x0000AAEA
		public override uint vmethod_13()
		{
			return (uint)this.double_0;
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0000C8F3 File Offset: 0x0000AAF3
		public override ulong vmethod_14()
		{
			return (ulong)this.double_0;
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x0000C8FC File Offset: 0x0000AAFC
		public override float C0EC1D52()
		{
			return (float)this.double_0;
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x0000C905 File Offset: 0x0000AB05
		public override double F979B236()
		{
			return this.double_0;
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x0009AE80 File Offset: 0x00099080
		public override IntPtr C2F10BC1()
		{
			int size = IntPtr.Size;
			uint num = 0x615480U;
			long value;
			if (size != 4)
			{
				long num2 = (long)this.double_0;
				num %= 0x65A6757FU;
				value = num2;
			}
			else
			{
				num %= 0x19C90FB0U;
				long num3 = (long)((int)this.double_0);
				num = 0x51136E08U << (int)num;
				value = num3;
				num += 0xAF4DE678U;
			}
			return new IntPtr(value);
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x0009AEE0 File Offset: 0x000990E0
		public override UIntPtr vmethod_15()
		{
			uint num = 0x5D1F1F42U;
			ulong value;
			while (IntPtr.Size == (int)(num ^ 0x5D1F1F46U))
			{
				num >>= 1;
				if (num != 0x2D725A7FU)
				{
					ulong num2 = (ulong)((uint)this.double_0);
					num = 0x427411C7U >> (int)num;
					value = num2;
					num += 0x6203470DU;
					IL_67:
					return new UIntPtr(value);
				}
			}
			num = (0x1C50042AU | num);
			num = 0x3E385CC1U + num;
			ulong num3 = (ulong)this.double_0;
			num -= 0x185A2C3BU;
			value = num3;
			goto IL_67;
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x0009AF5C File Offset: 0x0009915C
		public override object BF2B5883(Type type_0, bool bool_0)
		{
			uint num = 0x2F463687U;
			for (;;)
			{
				num = 0x68DF65CEU >> (int)num;
				RuntimeTypeHandle handle = typeof(IntPtr).TypeHandle;
				num /= 0x30300544U;
				if (type_0 == Type.GetTypeFromHandle(handle))
				{
					goto Block_7;
				}
				num = (0x260A4A0FU ^ num);
				Type typeFromHandle = typeof(UIntPtr);
				num *= 0x49B774C0U;
				if (type_0 == typeFromHandle)
				{
					break;
				}
				for (;;)
				{
					num = 0x47B5700U << (int)num;
					TypeCode typeCode = Type.GetTypeCode(type_0);
					num = 0x7B7C6A83U >> (int)num;
					TypeCode typeCode2 = typeCode;
					num = (0x6CB309FAU ^ num);
					TypeCode typeCode3 = typeCode2;
					uint num2 = num ^ 0x17CF637CU;
					num -= 0x98842ECU;
					switch (typeCode3 - num2)
					{
					case 0:
						goto IL_BB;
					case 1:
						goto IL_16B;
					case 2:
						goto IL_CE;
					case 3:
						goto IL_1C3;
					case 4:
						goto IL_1E8;
					case 5:
						goto IL_230;
					case 6:
						if (0x2B4F3E94U >> (int)num == 0U)
						{
							continue;
						}
						goto IL_255;
					case 7:
						goto IL_262;
					case 8:
						goto IL_E9;
					case 9:
						goto IL_2B0;
					}
					goto Block_2;
				}
				IL_BB:
				num = (0x181B717FU ^ num);
				if (0x4F6D545EU + num != 0U)
				{
					goto Block_4;
				}
				continue;
				IL_CE:
				if (bool_0)
				{
					goto IL_19D;
				}
				num /= 0x27D539A1U;
				if (0x33421F93U > num)
				{
					goto Block_6;
				}
				continue;
				IL_E9:
				if (num >> 0xA == 0U)
				{
					continue;
				}
				goto IL_2AA;
				Block_2:
				if ((num ^ 0x295F4418U) != 0U)
				{
					num ^= 0U;
					goto IL_E9;
				}
				goto IL_BB;
			}
			num *= 0x9B39B0U;
			if ((0x3618781FU & num) != 0U)
			{
				goto IL_288;
			}
			goto IL_20E;
			Block_4:
			short num3;
			checked
			{
				sbyte b2;
				if (!bool_0)
				{
					num = (0x7F150786U ^ num);
					sbyte b = (sbyte)this.double_0;
					num &= 0xB306A83U;
					b2 = b;
				}
				else
				{
					b2 = (sbyte)((uint)this.double_0);
					num ^= 0x1F5C13F2U;
				}
				return b2;
				Block_6:
				num3 = (short)this.double_0;
				goto IL_1B5;
				Block_7:
				goto IL_20E;
				IL_16B:;
			}
			if ((0x69896B27U ^ num) != 0U)
			{
				byte b3 = (byte)this.double_0;
				num = 0x3DDC4CCEU + num;
				byte b4 = b3;
				num = 0x6D91374U * num;
				return b4;
			}
			goto IL_20E;
			IL_19D:
			num = 0x28721867U % num;
			num3 = checked((short)((uint)this.double_0));
			num += 0xF41C28B3U;
			IL_1B5:
			num >>= 0x1D;
			return num3;
			IL_1C3:
			num = (0x10464D20U | num);
			ushort num4 = (ushort)this.double_0;
			num |= 0x66C00230U;
			ushort num5 = num4;
			num -= 0x42EB55C2U;
			return num5;
			IL_1E8:
			if (num / 0x326961BFU == 0U)
			{
				num = 0x6A6E34F4U * num;
				int num6 = (int)this.double_0;
				num ^= 0x4AFB3BE3U;
				return num6;
			}
			IL_20E:
			long num7 = (long)this.double_0;
			num &= 0x5FAA2C27U;
			long value = num7;
			num -= 0x280D00F3U;
			return new IntPtr(value);
			IL_230:
			num = (0x2C5492AU & num);
			num += 0x7626712DU;
			uint num8 = (uint)this.double_0;
			num /= 0x174365EU;
			return num8;
			IL_255:
			return checked((long)this.double_0);
			IL_262:
			if (0x70245662U - num != 0U)
			{
				num = 0x7DD60E63U % num;
				ulong num9 = checked((ulong)this.double_0);
				num >>= 0x1D;
				return num9;
			}
			IL_288:
			ulong num10 = (ulong)this.double_0;
			num %= 0x4C600035U;
			UIntPtr uintPtr = new UIntPtr(num10);
			num = 0x2DF548E6U / num;
			return uintPtr;
			IL_2AA:
			throw new ArgumentException();
			IL_2B0:
			num = (0x136474D9U ^ num);
			return this.double_0;
		}

		// Token: 0x04000ADD RID: 2781
		private double double_0;
	}

	// Token: 0x020001F2 RID: 498
	private sealed class Class14 : GClass18.Class9
	{
		// Token: 0x06001460 RID: 5216 RVA: 0x0000C90D File Offset: 0x0000AB0D
		public Class14(string string_1)
		{
			this.string_0 = string_1;
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x0000C91C File Offset: 0x0000AB1C
		public override Type vmethod_6()
		{
			return typeof(string);
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x00009FAD File Offset: 0x000081AD
		public override TypeCode vmethod_7()
		{
			return TypeCode.Object;
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x0000C928 File Offset: 0x0000AB28
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class14(this.string_0);
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x0000C935 File Offset: 0x0000AB35
		public override object vmethod_1()
		{
			return this.string_0;
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x0009B22C File Offset: 0x0009942C
		public override void vmethod_2(object object_0)
		{
			uint num;
			do
			{
				num = 0x243F0293U;
				string text;
				if (object_0 != null)
				{
					text = Convert.ToString(object_0);
					num ^= 0x58002D6CU;
				}
				else
				{
					num = (0x7C0A2F6FU | num);
					text = null;
				}
				this.string_0 = text;
			}
			while (num <= 0x2BAE29E5U);
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0000C93D File Offset: 0x0000AB3D
		public override bool E6731BF1()
		{
			return this.string_0 != null;
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0000C935 File Offset: 0x0000AB35
		public override string ToString()
		{
			return this.string_0;
		}

		// Token: 0x04000ADE RID: 2782
		private string string_0;
	}

	// Token: 0x020001F3 RID: 499
	private sealed class Class29 : GClass18.Class8
	{
		// Token: 0x06001468 RID: 5224 RVA: 0x0009B26C File Offset: 0x0009946C
		public Class29(short short_1)
		{
			uint num = 0x46F71BFU;
			do
			{
				base..ctor();
				num = (0x50E32768U & num);
			}
			while (num > 0x10CA4976U);
			do
			{
				num += 0x3BC3178EU;
				num = (0x2E2E51F5U ^ num);
				this.short_0 = short_1;
			}
			while (num + 0x14B14848U == 0U);
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x0000C948 File Offset: 0x0000AB48
		public override Type vmethod_6()
		{
			return typeof(short);
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0000C954 File Offset: 0x0000AB54
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class29(this.short_0);
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x0000C961 File Offset: 0x0000AB61
		public override object vmethod_1()
		{
			return this.short_0;
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x0000C96E File Offset: 0x0000AB6E
		public override void vmethod_2(object object_0)
		{
			this.short_0 = Convert.ToInt16(object_0);
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class10(this.vmethod_10());
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x0000C989 File Offset: 0x0000AB89
		public override sbyte vmethod_8()
		{
			return (sbyte)this.short_0;
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x0000C992 File Offset: 0x0000AB92
		public override byte vmethod_12()
		{
			return (byte)this.short_0;
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x0000C99B File Offset: 0x0000AB9B
		public override short vmethod_9()
		{
			return this.short_0;
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x0000C9A3 File Offset: 0x0000ABA3
		public override ushort A7B71418()
		{
			return (ushort)this.short_0;
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x0000C99B File Offset: 0x0000AB9B
		public override int vmethod_10()
		{
			return (int)this.short_0;
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x0000C99B File Offset: 0x0000AB9B
		public override uint vmethod_13()
		{
			return (uint)this.short_0;
		}

		// Token: 0x04000ADF RID: 2783
		private short short_0;
	}

	// Token: 0x020001F4 RID: 500
	private sealed class Class30 : GClass18.Class8
	{
		// Token: 0x06001474 RID: 5236 RVA: 0x0000C9AC File Offset: 0x0000ABAC
		public Class30(ushort ushort_1)
		{
			this.ushort_0 = ushort_1;
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x0000C9BB File Offset: 0x0000ABBB
		public override Type vmethod_6()
		{
			return typeof(ushort);
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x0000C9C7 File Offset: 0x0000ABC7
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class30(this.ushort_0);
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x0000C9D4 File Offset: 0x0000ABD4
		public override object vmethod_1()
		{
			return this.ushort_0;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x0000C9E1 File Offset: 0x0000ABE1
		public override void vmethod_2(object object_0)
		{
			this.ushort_0 = Convert.ToUInt16(object_0);
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class10(this.vmethod_10());
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x0000C9EF File Offset: 0x0000ABEF
		public override sbyte vmethod_8()
		{
			return (sbyte)this.ushort_0;
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x0000C9F8 File Offset: 0x0000ABF8
		public override byte vmethod_12()
		{
			return (byte)this.ushort_0;
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x0000CA01 File Offset: 0x0000AC01
		public override short vmethod_9()
		{
			return (short)this.ushort_0;
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x0000CA0A File Offset: 0x0000AC0A
		public override ushort A7B71418()
		{
			return this.ushort_0;
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x0000CA0A File Offset: 0x0000AC0A
		public override int vmethod_10()
		{
			return (int)this.ushort_0;
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x0000CA0A File Offset: 0x0000AC0A
		public override uint vmethod_13()
		{
			return (uint)this.ushort_0;
		}

		// Token: 0x04000AE0 RID: 2784
		private ushort ushort_0;
	}

	// Token: 0x020001F5 RID: 501
	private sealed class Class31 : GClass18.Class8
	{
		// Token: 0x06001480 RID: 5248 RVA: 0x0000CA12 File Offset: 0x0000AC12
		public Class31(bool bool_1)
		{
			this.bool_0 = bool_1;
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x0000CA21 File Offset: 0x0000AC21
		public override Type vmethod_6()
		{
			return typeof(bool);
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x0000CA2D File Offset: 0x0000AC2D
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class31(this.bool_0);
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x0000CA3A File Offset: 0x0000AC3A
		public override object vmethod_1()
		{
			return this.bool_0;
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x0000CA47 File Offset: 0x0000AC47
		public override void vmethod_2(object object_0)
		{
			this.bool_0 = Convert.ToBoolean(object_0);
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class10(this.vmethod_10());
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x0009B2B8 File Offset: 0x000994B8
		public override int vmethod_10()
		{
			bool flag = this.bool_0;
			uint num = 2U;
			if (!flag)
			{
				return (int)(num ^ 2U);
			}
			num = 0x66BD4638U + num;
			return (int)(num - 0x66BD4639U);
		}

		// Token: 0x04000AE1 RID: 2785
		private bool bool_0;
	}

	// Token: 0x020001F6 RID: 502
	private sealed class Class32 : GClass18.Class8
	{
		// Token: 0x06001487 RID: 5255 RVA: 0x0009B2EC File Offset: 0x000994EC
		public Class32(char char_1)
		{
			uint num = 0x19D8F343U;
			do
			{
				num = 0x2A6482BU - num;
				this.char_0 = char_1;
			}
			while (num <= 0x122E394FU);
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0000CA55 File Offset: 0x0000AC55
		public override Type vmethod_6()
		{
			return typeof(char);
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0000CA61 File Offset: 0x0000AC61
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class32(this.char_0);
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0000CA6E File Offset: 0x0000AC6E
		public override object vmethod_1()
		{
			return this.char_0;
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0009B324 File Offset: 0x00099524
		public override void vmethod_2(object object_0)
		{
			uint num = 0x35A9432FU;
			do
			{
				num ^= 0x5A2A2CEBU;
				char c = Convert.ToChar(object_0);
				num -= 0x66964CCEU;
				this.char_0 = c;
			}
			while (num == 0x350D4628U);
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class10(this.vmethod_10());
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0000CA7B File Offset: 0x0000AC7B
		public override sbyte vmethod_8()
		{
			return (sbyte)this.char_0;
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0000CA84 File Offset: 0x0000AC84
		public override byte vmethod_12()
		{
			return (byte)this.char_0;
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x0000CA8D File Offset: 0x0000AC8D
		public override short vmethod_9()
		{
			return (short)this.char_0;
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x0000CA96 File Offset: 0x0000AC96
		public override ushort A7B71418()
		{
			return (ushort)this.char_0;
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x0000CA96 File Offset: 0x0000AC96
		public override int vmethod_10()
		{
			return (int)this.char_0;
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x0000CA96 File Offset: 0x0000AC96
		public override uint vmethod_13()
		{
			return (uint)this.char_0;
		}

		// Token: 0x04000AE2 RID: 2786
		private char char_0;
	}

	// Token: 0x020001F7 RID: 503
	private sealed class Class33 : GClass18.Class8
	{
		// Token: 0x06001493 RID: 5267 RVA: 0x0000CA9E File Offset: 0x0000AC9E
		public Class33(byte byte_1)
		{
			this.byte_0 = byte_1;
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0000CAAD File Offset: 0x0000ACAD
		public override Type vmethod_6()
		{
			return typeof(byte);
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0000CAB9 File Offset: 0x0000ACB9
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class33(this.byte_0);
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x0000CAC6 File Offset: 0x0000ACC6
		public override object vmethod_1()
		{
			return this.byte_0;
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x0000CAD3 File Offset: 0x0000ACD3
		public override void vmethod_2(object object_0)
		{
			this.byte_0 = Convert.ToByte(object_0);
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class10(this.vmethod_10());
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x0000CAE1 File Offset: 0x0000ACE1
		public override sbyte vmethod_8()
		{
			return (sbyte)this.byte_0;
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x0000CAEA File Offset: 0x0000ACEA
		public override byte vmethod_12()
		{
			return this.byte_0;
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x0000CAEA File Offset: 0x0000ACEA
		public override short vmethod_9()
		{
			return (short)this.byte_0;
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0000CAEA File Offset: 0x0000ACEA
		public override ushort A7B71418()
		{
			return (ushort)this.byte_0;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0000CAEA File Offset: 0x0000ACEA
		public override int vmethod_10()
		{
			return (int)this.byte_0;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x0000CAEA File Offset: 0x0000ACEA
		public override uint vmethod_13()
		{
			return (uint)this.byte_0;
		}

		// Token: 0x04000AE3 RID: 2787
		private byte byte_0;
	}

	// Token: 0x020001F8 RID: 504
	private sealed class Class34 : GClass18.Class8
	{
		// Token: 0x0600149F RID: 5279 RVA: 0x0000CAF2 File Offset: 0x0000ACF2
		public Class34(sbyte sbyte_1)
		{
			this.sbyte_0 = sbyte_1;
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x0000CB01 File Offset: 0x0000AD01
		public override Type vmethod_6()
		{
			return typeof(sbyte);
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x0000CB0D File Offset: 0x0000AD0D
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class34(this.sbyte_0);
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x0000CB1A File Offset: 0x0000AD1A
		public override object vmethod_1()
		{
			return this.sbyte_0;
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x0000CB27 File Offset: 0x0000AD27
		public override void vmethod_2(object object_0)
		{
			this.sbyte_0 = Convert.ToSByte(object_0);
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class10(this.vmethod_10());
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x0000CB35 File Offset: 0x0000AD35
		public override sbyte vmethod_8()
		{
			return this.sbyte_0;
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x0000CB3D File Offset: 0x0000AD3D
		public override byte vmethod_12()
		{
			return (byte)this.sbyte_0;
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x0000CB35 File Offset: 0x0000AD35
		public override short vmethod_9()
		{
			return (short)this.sbyte_0;
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x0000CB46 File Offset: 0x0000AD46
		public override ushort A7B71418()
		{
			return (ushort)this.sbyte_0;
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x0000CB35 File Offset: 0x0000AD35
		public override int vmethod_10()
		{
			return (int)this.sbyte_0;
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x0000CB35 File Offset: 0x0000AD35
		public override uint vmethod_13()
		{
			return (uint)this.sbyte_0;
		}

		// Token: 0x04000AE4 RID: 2788
		private sbyte sbyte_0;
	}

	// Token: 0x020001F9 RID: 505
	private sealed class Class35 : GClass18.Class8
	{
		// Token: 0x060014AB RID: 5291 RVA: 0x0000CB4F File Offset: 0x0000AD4F
		public Class35(uint uint_1)
		{
			this.uint_0 = uint_1;
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x0000CB5E File Offset: 0x0000AD5E
		public override Type vmethod_6()
		{
			return typeof(uint);
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x0000CB6A File Offset: 0x0000AD6A
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class35(this.uint_0);
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x0000CB77 File Offset: 0x0000AD77
		public override object vmethod_1()
		{
			return this.uint_0;
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x0000CB84 File Offset: 0x0000AD84
		public override void vmethod_2(object object_0)
		{
			this.uint_0 = Convert.ToUInt32(object_0);
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class10(this.vmethod_10());
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x0000CB92 File Offset: 0x0000AD92
		public override sbyte vmethod_8()
		{
			return (sbyte)this.uint_0;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0000CB9B File Offset: 0x0000AD9B
		public override byte vmethod_12()
		{
			return (byte)this.uint_0;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x0000CBA4 File Offset: 0x0000ADA4
		public override short vmethod_9()
		{
			return (short)this.uint_0;
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0000CBAD File Offset: 0x0000ADAD
		public override ushort A7B71418()
		{
			return (ushort)this.uint_0;
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x0000CBB6 File Offset: 0x0000ADB6
		public override int vmethod_10()
		{
			return (int)this.uint_0;
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x0000CBB6 File Offset: 0x0000ADB6
		public override uint vmethod_13()
		{
			return this.uint_0;
		}

		// Token: 0x04000AE5 RID: 2789
		private uint uint_0;
	}

	// Token: 0x020001FA RID: 506
	private sealed class Class36 : GClass18.Class8
	{
		// Token: 0x060014B7 RID: 5303 RVA: 0x0009B35C File Offset: 0x0009955C
		public Class36(ulong ulong_1)
		{
			uint num = 0x71385981U;
			base..ctor();
			do
			{
				num /= 0x32B43069U;
				num &= 0x77A81FD0U;
				this.ulong_0 = ulong_1;
			}
			while (num * 0x5F4571B8U != 0U);
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x0000CBBE File Offset: 0x0000ADBE
		public override Type vmethod_6()
		{
			return typeof(ulong);
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x0000CBCA File Offset: 0x0000ADCA
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class36(this.ulong_0);
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0000CBD7 File Offset: 0x0000ADD7
		public override object vmethod_1()
		{
			return this.ulong_0;
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
		public override void vmethod_2(object object_0)
		{
			this.ulong_0 = Convert.ToUInt64(object_0);
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x0000CBF2 File Offset: 0x0000ADF2
		public override GClass18.Class9 vmethod_4()
		{
			return new GClass18.Class11(this.AFC5EABA());
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x0000CBFF File Offset: 0x0000ADFF
		public override sbyte vmethod_8()
		{
			return (sbyte)this.ulong_0;
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0000CC08 File Offset: 0x0000AE08
		public override byte vmethod_12()
		{
			return (byte)this.ulong_0;
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0000CC11 File Offset: 0x0000AE11
		public override short vmethod_9()
		{
			return (short)this.ulong_0;
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0000CC1A File Offset: 0x0000AE1A
		public override ushort A7B71418()
		{
			return (ushort)this.ulong_0;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0000CC23 File Offset: 0x0000AE23
		public override int vmethod_10()
		{
			return (int)this.ulong_0;
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0000CC2C File Offset: 0x0000AE2C
		public override uint vmethod_13()
		{
			return (uint)this.ulong_0;
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0000CC35 File Offset: 0x0000AE35
		public override long AFC5EABA()
		{
			return (long)this.ulong_0;
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0000CC35 File Offset: 0x0000AE35
		public override ulong vmethod_14()
		{
			return this.ulong_0;
		}

		// Token: 0x04000AE6 RID: 2790
		private ulong ulong_0;
	}

	// Token: 0x020001FB RID: 507
	private sealed class Class15 : GClass18.Class9
	{
		// Token: 0x060014C5 RID: 5317 RVA: 0x0009B398 File Offset: 0x00099598
		public Class15(object object_1)
		{
			uint num = 0x6BB02B89U;
			base..ctor();
			do
			{
				this.object_0 = object_1;
			}
			while (num - 0x66DD71DBU == 0U);
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x0000CC3D File Offset: 0x0000AE3D
		public override Type vmethod_6()
		{
			return typeof(object);
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x00009FAD File Offset: 0x000081AD
		public override TypeCode vmethod_7()
		{
			return TypeCode.Object;
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0000CC49 File Offset: 0x0000AE49
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class15(this.object_0);
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x0000CC56 File Offset: 0x0000AE56
		public override object vmethod_1()
		{
			return this.object_0;
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x0000CC5E File Offset: 0x0000AE5E
		public override void vmethod_2(object object_1)
		{
			this.object_0 = object_1;
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x0000CC67 File Offset: 0x0000AE67
		public override bool E6731BF1()
		{
			return this.object_0 != null;
		}

		// Token: 0x04000AE7 RID: 2791
		private object object_0;
	}

	// Token: 0x020001FC RID: 508
	private sealed class Class16 : GClass18.Class9
	{
		// Token: 0x060014CC RID: 5324 RVA: 0x0000CC72 File Offset: 0x0000AE72
		public Class16(object object_1, Type type_1)
		{
			this.object_0 = object_1;
			this.type_0 = type_1;
			this.class8_0 = GClass18.Class16.smethod_0(object_1);
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x0009B3C4 File Offset: 0x000995C4
		private static GClass18.Class8 smethod_0(object object_1)
		{
			uint num;
			do
			{
				num = 0x410A6D76U;
				if (object_1 != null)
				{
					goto IL_13;
				}
			}
			while (0x3EF36806U >= num);
			IntPtr intPtr = IntPtr.Zero;
			num += 0xBFFFB690U;
			goto IL_35;
			IL_13:
			num &= 0x2D0A2407U;
			intPtr = new IntPtr(Pointer.Unbox(object_1));
			IL_35:
			IntPtr intPtr2 = intPtr;
			num += 0x213439EAU;
			if (IntPtr.Size == (int)(num ^ 0x223E5DF4U))
			{
				num >>= 0x14;
				int int_ = intPtr2.ToInt32();
				num -= 0x62286F23U;
				return new GClass18.Class10(int_);
			}
			return new GClass18.Class11(intPtr2.ToInt64());
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x0000CC94 File Offset: 0x0000AE94
		public override Type vmethod_6()
		{
			return this.type_0;
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x0009B448 File Offset: 0x00099648
		public override TypeCode vmethod_7()
		{
			uint num = 0x62131C50U;
			if (IntPtr.Size != 4)
			{
				num = 0x6EA148FCU * num;
				return (int)num + (TypeCode)(-0x19165EB4);
			}
			return (TypeCode)(num ^ 0x62131C5AU);
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x0000CC9C File Offset: 0x0000AE9C
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class16(this.object_0, this.type_0);
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x0000CCAF File Offset: 0x0000AEAF
		public override object vmethod_1()
		{
			return this.object_0;
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x0009B47C File Offset: 0x0009967C
		public override void vmethod_2(object object_1)
		{
			uint num = 0x2DB322A5U;
			do
			{
				num = (0x36EE30A7U | num);
				this.object_0 = object_1;
				num = 0x7FF265E2U + num;
			}
			while (num < 0x4DC06886U);
			do
			{
				num = 0x48277754U - num;
				this.class8_0 = GClass18.Class16.smethod_0(object_1);
			}
			while (num == 0x748631DDU);
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x0000CCB7 File Offset: 0x0000AEB7
		public override bool E6731BF1()
		{
			return this.object_0 != null;
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x0000CCC2 File Offset: 0x0000AEC2
		public override sbyte vmethod_8()
		{
			return this.class8_0.vmethod_8();
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x0000CCCF File Offset: 0x0000AECF
		public override short vmethod_9()
		{
			return this.class8_0.vmethod_9();
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x0000CCDC File Offset: 0x0000AEDC
		public override int vmethod_10()
		{
			return this.class8_0.vmethod_10();
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x0000CCE9 File Offset: 0x0000AEE9
		public override long AFC5EABA()
		{
			return this.class8_0.AFC5EABA();
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x0000CCF6 File Offset: 0x0000AEF6
		public override byte vmethod_12()
		{
			return this.class8_0.vmethod_12();
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x0000CD03 File Offset: 0x0000AF03
		public override ushort A7B71418()
		{
			return this.class8_0.A7B71418();
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x0000CD10 File Offset: 0x0000AF10
		public override uint vmethod_13()
		{
			return this.class8_0.vmethod_13();
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x0000CD1D File Offset: 0x0000AF1D
		public override ulong vmethod_14()
		{
			return this.class8_0.vmethod_14();
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0000CD2A File Offset: 0x0000AF2A
		public override float C0EC1D52()
		{
			return this.class8_0.C0EC1D52();
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x0000CD37 File Offset: 0x0000AF37
		public override double F979B236()
		{
			return this.class8_0.F979B236();
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0000CD44 File Offset: 0x0000AF44
		public override IntPtr C2F10BC1()
		{
			return this.class8_0.C2F10BC1();
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0000CD51 File Offset: 0x0000AF51
		public override UIntPtr vmethod_15()
		{
			return this.class8_0.vmethod_15();
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x0000CD5E File Offset: 0x0000AF5E
		public unsafe override void* vmethod_16()
		{
			return Pointer.Unbox(this.object_0);
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x0000CD6B File Offset: 0x0000AF6B
		public override object BF2B5883(Type type_1, bool bool_0)
		{
			return this.class8_0.BF2B5883(type_1, bool_0);
		}

		// Token: 0x04000AE8 RID: 2792
		private object object_0;

		// Token: 0x04000AE9 RID: 2793
		private Type type_0;

		// Token: 0x04000AEA RID: 2794
		private GClass18.Class8 class8_0;
	}

	// Token: 0x020001FD RID: 509
	private sealed class Class17 : GClass18.Class9
	{
		// Token: 0x060014E2 RID: 5346 RVA: 0x0009B4CC File Offset: 0x000996CC
		public Class17(object object_1)
		{
			uint num = 0x11C82947U;
			base..ctor();
			if (object_1 != null && 0x49FC0687 << (int)num != 0)
			{
				num = 0x53667808U * num;
				bool flag = object_1 is ValueType;
				num += 0x38E3970FU;
				if (!flag)
				{
					throw new ArgumentException();
				}
			}
			this.object_0 = object_1;
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x0000CD7A File Offset: 0x0000AF7A
		public override Type vmethod_6()
		{
			return typeof(ValueType);
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x0000CD86 File Offset: 0x0000AF86
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class17(this.object_0);
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x0000CD93 File Offset: 0x0000AF93
		public override object vmethod_1()
		{
			return this.object_0;
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0000CD9B File Offset: 0x0000AF9B
		public override void vmethod_2(object object_1)
		{
			if (object_1 != null && !(object_1 is ValueType))
			{
				throw new ArgumentException();
			}
			this.object_0 = object_1;
		}

		// Token: 0x04000AEB RID: 2795
		private object object_0;
	}

	// Token: 0x020001FE RID: 510
	private sealed class Class18 : GClass18.Class9
	{
		// Token: 0x060014E7 RID: 5351 RVA: 0x0000CDB5 File Offset: 0x0000AFB5
		public Class18(Array array_1)
		{
			this.array_0 = array_1;
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x0000CDC4 File Offset: 0x0000AFC4
		public override Type vmethod_6()
		{
			return typeof(Array);
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x0000CDD0 File Offset: 0x0000AFD0
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class18(this.array_0);
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x0000CDDD File Offset: 0x0000AFDD
		public override object vmethod_1()
		{
			return this.array_0;
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x0009B51C File Offset: 0x0009971C
		public override void vmethod_2(object object_0)
		{
			uint num = 0x6FDF7EF1U;
			do
			{
				this.array_0 = (Array)object_0;
			}
			while (0x549E1381U == num);
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x0000CDE5 File Offset: 0x0000AFE5
		public override bool E6731BF1()
		{
			return this.array_0 != null;
		}

		// Token: 0x04000AEC RID: 2796
		private Array array_0;
	}

	// Token: 0x020001FF RID: 511
	private abstract class Class19 : GClass18.Class9
	{
		// Token: 0x060014ED RID: 5357 RVA: 0x00009FAD File Offset: 0x000081AD
		public override bool vmethod_3()
		{
			return true;
		}
	}

	// Token: 0x02000200 RID: 512
	private sealed class Class20 : GClass18.Class19
	{
		// Token: 0x060014EF RID: 5359 RVA: 0x0000CDF8 File Offset: 0x0000AFF8
		public Class20(GClass18.Class8 class8_1)
		{
			this.class8_0 = class8_1;
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x0000CE07 File Offset: 0x0000B007
		public override Type vmethod_6()
		{
			return this.class8_0.vmethod_6();
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x0000CE14 File Offset: 0x0000B014
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class20(this.class8_0);
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x0000CE21 File Offset: 0x0000B021
		public override object vmethod_1()
		{
			return this.class8_0.vmethod_1();
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x0000CE2E File Offset: 0x0000B02E
		public override void vmethod_2(object object_0)
		{
			this.class8_0.vmethod_2(object_0);
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0000CE3C File Offset: 0x0000B03C
		public override bool E6731BF1()
		{
			return this.class8_0 != null;
		}

		// Token: 0x04000AED RID: 2797
		private GClass18.Class8 class8_0;
	}

	// Token: 0x02000201 RID: 513
	private sealed class Class21 : GClass18.Class19
	{
		// Token: 0x060014F5 RID: 5365 RVA: 0x0000CE47 File Offset: 0x0000B047
		public Class21(GClass18.Class8 class8_2, GClass18.Class8 class8_3)
		{
			this.class8_0 = class8_2;
			this.class8_1 = class8_3;
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x0000CE5D File Offset: 0x0000B05D
		public override Type vmethod_6()
		{
			return this.class8_0.vmethod_6();
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x0000CE6A File Offset: 0x0000B06A
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class21(this.class8_0, this.class8_1);
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x0000CE7D File Offset: 0x0000B07D
		public override object vmethod_1()
		{
			return this.class8_0.vmethod_1();
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x0009B544 File Offset: 0x00099744
		public override void vmethod_2(object object_0)
		{
			uint num = 0x5D64168U;
			for (;;)
			{
				num -= 0x518C115FU;
				GClass18.Class8 @class = this.class8_0;
				num = (0x4C6A5468U | num);
				@class.vmethod_2(object_0);
				if (0x331000F4U % num != 0U)
				{
					num -= 0x3343F40U;
					GClass18.Class8 class2 = this.class8_1;
					num = (0x678F5E11U | num);
					GClass18.Class8 class3 = this.class8_0;
					num %= 0x3A79178EU;
					class2.vmethod_2(class3.vmethod_1());
					if (num != 0x3BF44223U)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x0000CE8A File Offset: 0x0000B08A
		public override bool E6731BF1()
		{
			return this.class8_0 != null;
		}

		// Token: 0x04000AEE RID: 2798
		private GClass18.Class8 class8_0;

		// Token: 0x04000AEF RID: 2799
		private GClass18.Class8 class8_1;
	}

	// Token: 0x02000202 RID: 514
	private sealed class Class22 : GClass18.Class19
	{
		// Token: 0x060014FB RID: 5371 RVA: 0x0009B5B8 File Offset: 0x000997B8
		public Class22(FieldInfo fieldInfo_1, object object_1)
		{
			for (;;)
			{
				base..ctor();
				uint num = 0x3B3F0BBAU;
				for (;;)
				{
					this.fieldInfo_0 = fieldInfo_1;
					if (0x369477E8U - num == 0U)
					{
						break;
					}
					num = 0x47062ECU << (int)num;
					this.object_0 = object_1;
					if (0x5AC3248 << (int)num != 0)
					{
						return;
					}
				}
			}
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x0000CE95 File Offset: 0x0000B095
		public override Type vmethod_6()
		{
			return this.fieldInfo_0.FieldType;
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x0000CEA2 File Offset: 0x0000B0A2
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class22(this.fieldInfo_0, this.object_0);
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x0000CEB5 File Offset: 0x0000B0B5
		public override object vmethod_1()
		{
			return this.fieldInfo_0.GetValue(this.object_0);
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x0009B610 File Offset: 0x00099810
		public override void vmethod_2(object object_1)
		{
			uint num = 0x69D13C3CU;
			do
			{
				FieldInfo fieldInfo = this.fieldInfo_0;
				num &= 0x734B43B3U;
				object obj = this.object_0;
				num = 0x6A5A7742U % num;
				num ^= 0x69D31D79U;
				fieldInfo.SetValue(obj, object_1);
			}
			while (0x3B97F2CU * num == 0U);
		}

		// Token: 0x04000AF0 RID: 2800
		private FieldInfo fieldInfo_0;

		// Token: 0x04000AF1 RID: 2801
		private object object_0;
	}

	// Token: 0x02000203 RID: 515
	private sealed class Class23 : GClass18.Class19
	{
		// Token: 0x06001500 RID: 5376 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
		public Class23(Array array_1, int int_1)
		{
			this.array_0 = array_1;
			this.int_0 = int_1;
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x0000CEDE File Offset: 0x0000B0DE
		public override Type vmethod_6()
		{
			return this.array_0.GetType().GetElementType();
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x0000CEF0 File Offset: 0x0000B0F0
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class23(this.array_0, this.int_0);
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x0000CF03 File Offset: 0x0000B103
		public override object vmethod_1()
		{
			return this.array_0.GetValue(this.int_0);
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x0000CF16 File Offset: 0x0000B116
		public override void vmethod_2(object object_0)
		{
			this.array_0.SetValue(object_0, this.int_0);
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x0009B658 File Offset: 0x00099858
		public override UIntPtr vmethod_15()
		{
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(UIntPtr), new Type[]
			{
				this.array_0.GetType(),
				typeof(int)
			}, typeof(GClass18).Module, true);
			ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
			ilgenerator.Emit(OpCodes.Ldarg, 0);
			ilgenerator.Emit(OpCodes.Ldarg, 1);
			ilgenerator.Emit(OpCodes.Ldelema, this.array_0.GetType().GetElementType());
			ilgenerator.Emit(OpCodes.Conv_U);
			ilgenerator.Emit(OpCodes.Ret);
			return (UIntPtr)dynamicMethod.Invoke(null, new object[]
			{
				this.array_0,
				this.int_0
			});
		}

		// Token: 0x04000AF2 RID: 2802
		private Array array_0;

		// Token: 0x04000AF3 RID: 2803
		private int int_0;
	}

	// Token: 0x02000204 RID: 516
	private sealed class Class25 : GClass18.Class9
	{
		// Token: 0x06001506 RID: 5382 RVA: 0x0000CF2A File Offset: 0x0000B12A
		public Class25(MethodBase methodBase_1)
		{
			this.methodBase_0 = methodBase_1;
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x0000CF39 File Offset: 0x0000B139
		public override Type vmethod_6()
		{
			return typeof(MethodBase);
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x0000CF45 File Offset: 0x0000B145
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class25(this.methodBase_0);
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x0000CF52 File Offset: 0x0000B152
		public override object vmethod_1()
		{
			return this.methodBase_0;
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x0000CF5A File Offset: 0x0000B15A
		public override void vmethod_2(object object_0)
		{
			this.methodBase_0 = (MethodBase)object_0;
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x0000CF68 File Offset: 0x0000B168
		public override bool E6731BF1()
		{
			return this.methodBase_0 != null;
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x0009B720 File Offset: 0x00099920
		public override IntPtr C2F10BC1()
		{
			return this.methodBase_0.MethodHandle.GetFunctionPointer();
		}

		// Token: 0x04000AF4 RID: 2804
		private MethodBase methodBase_0;
	}

	// Token: 0x02000205 RID: 517
	private sealed class Class26 : GClass18.Class9
	{
		// Token: 0x0600150D RID: 5389 RVA: 0x0009B740 File Offset: 0x00099940
		public Class26(IntPtr intptr_1)
		{
			uint num = 0x7DE21C7U;
			for (;;)
			{
				base..ctor();
				num = 0x580C761DU >> (int)num;
				if (0x71653D34U / num != 0U)
				{
					num = (0x3D2D0791U & num);
					num *= 0x27672465U;
					this.intptr_0 = intptr_1;
					if ((num & 0x772B3D20U) != 0U)
					{
						break;
					}
				}
			}
			do
			{
				num = (0x4D006474U & num);
				IntPtr intptr_2 = this.intptr_0;
				num >>= 1;
				this.class8_0 = GClass18.Class26.smethod_0(intptr_2);
			}
			while (0x2AB67700U / num == 0U);
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x0009B7C0 File Offset: 0x000999C0
		private static GClass18.Class8 smethod_0(IntPtr intptr_1)
		{
			int size = IntPtr.Size;
			int num = 4;
			uint num2 = 0x61C5540DU;
			if (size == num)
			{
				num2 <<= 2;
			}
			else if (num2 <= 0x69D247DDU)
			{
				num2 <<= 0x1B;
				return new GClass18.Class11(intptr_1.ToInt64());
			}
			int int_ = intptr_1.ToInt32();
			num2 <<= 4;
			return new GClass18.Class10(int_);
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x0000CF73 File Offset: 0x0000B173
		public override Type vmethod_6()
		{
			return typeof(IntPtr);
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0000CF7F File Offset: 0x0000B17F
		public override TypeCode vmethod_7()
		{
			return this.class8_0.vmethod_7();
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0000CF8C File Offset: 0x0000B18C
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class26(this.intptr_0);
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0000CF99 File Offset: 0x0000B199
		public override object vmethod_1()
		{
			return this.intptr_0;
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x0000CFA6 File Offset: 0x0000B1A6
		public override void vmethod_2(object object_0)
		{
			this.intptr_0 = (IntPtr)object_0;
			this.class8_0 = GClass18.Class26.smethod_0(this.intptr_0);
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x0000CFC5 File Offset: 0x0000B1C5
		public override bool E6731BF1()
		{
			return this.intptr_0 != IntPtr.Zero;
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x0000CFD7 File Offset: 0x0000B1D7
		public override sbyte vmethod_8()
		{
			return this.class8_0.vmethod_8();
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x0000CFE4 File Offset: 0x0000B1E4
		public override short vmethod_9()
		{
			return this.class8_0.vmethod_9();
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0000CFF1 File Offset: 0x0000B1F1
		public override int vmethod_10()
		{
			return this.class8_0.vmethod_10();
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0000CFFE File Offset: 0x0000B1FE
		public override long AFC5EABA()
		{
			return this.class8_0.AFC5EABA();
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x0000D00B File Offset: 0x0000B20B
		public override byte vmethod_12()
		{
			return this.class8_0.vmethod_12();
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x0000D018 File Offset: 0x0000B218
		public override ushort A7B71418()
		{
			return this.class8_0.A7B71418();
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x0000D025 File Offset: 0x0000B225
		public override uint vmethod_13()
		{
			return this.class8_0.vmethod_13();
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x0000D032 File Offset: 0x0000B232
		public override ulong vmethod_14()
		{
			return this.class8_0.vmethod_14();
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0000D03F File Offset: 0x0000B23F
		public override float C0EC1D52()
		{
			return this.class8_0.C0EC1D52();
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x0000D04C File Offset: 0x0000B24C
		public override double F979B236()
		{
			return this.class8_0.F979B236();
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x0000D059 File Offset: 0x0000B259
		public override IntPtr C2F10BC1()
		{
			return this.intptr_0;
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x0000D061 File Offset: 0x0000B261
		public override UIntPtr vmethod_15()
		{
			return this.class8_0.vmethod_15();
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x0000D06E File Offset: 0x0000B26E
		public unsafe override void* vmethod_16()
		{
			return this.intptr_0.ToPointer();
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x0000D07B File Offset: 0x0000B27B
		public override object BF2B5883(Type type_0, bool bool_0)
		{
			return this.class8_0.BF2B5883(type_0, bool_0);
		}

		// Token: 0x04000AF5 RID: 2805
		private IntPtr intptr_0;

		// Token: 0x04000AF6 RID: 2806
		private GClass18.Class8 class8_0;
	}

	// Token: 0x02000206 RID: 518
	private sealed class Class27 : GClass18.Class9
	{
		// Token: 0x06001523 RID: 5411 RVA: 0x0000D08A File Offset: 0x0000B28A
		public Class27(UIntPtr uintptr_1)
		{
			this.uintptr_0 = uintptr_1;
			this.class8_0 = GClass18.Class27.smethod_0(this.uintptr_0);
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x0009B818 File Offset: 0x00099A18
		private static GClass18.Class8 smethod_0(UIntPtr uintptr_1)
		{
			int size = IntPtr.Size;
			uint num = 0x3BB7206FU;
			if (size == 4)
			{
				num = (0x60285012U ^ num);
			}
			else if (num - 0x5D8741EBU != 0U)
			{
				num = 0x2FEA353FU + num;
				return new GClass18.Class11((long)uintptr_1.ToUInt64());
			}
			num %= 0x5DDB17F8U;
			return new GClass18.Class10((int)uintptr_1.ToUInt32());
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x0000D0AA File Offset: 0x0000B2AA
		public override Type vmethod_6()
		{
			return typeof(UIntPtr);
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x0000D0B6 File Offset: 0x0000B2B6
		public override TypeCode vmethod_7()
		{
			return this.class8_0.vmethod_7();
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x0000D0C3 File Offset: 0x0000B2C3
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class27(this.uintptr_0);
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x0000D0D0 File Offset: 0x0000B2D0
		public override object vmethod_1()
		{
			return this.uintptr_0;
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x0000D0DD File Offset: 0x0000B2DD
		public override void vmethod_2(object object_0)
		{
			this.uintptr_0 = (UIntPtr)object_0;
			this.class8_0 = GClass18.Class27.smethod_0(this.uintptr_0);
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x0000D0FC File Offset: 0x0000B2FC
		public override bool E6731BF1()
		{
			return this.uintptr_0 != UIntPtr.Zero;
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x0000D10E File Offset: 0x0000B30E
		public override sbyte vmethod_8()
		{
			return this.class8_0.vmethod_8();
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x0000D11B File Offset: 0x0000B31B
		public override short vmethod_9()
		{
			return this.class8_0.vmethod_9();
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x0000D128 File Offset: 0x0000B328
		public override int vmethod_10()
		{
			return this.class8_0.vmethod_10();
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x0000D135 File Offset: 0x0000B335
		public override long AFC5EABA()
		{
			return this.class8_0.AFC5EABA();
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x0000D142 File Offset: 0x0000B342
		public override byte vmethod_12()
		{
			return this.class8_0.vmethod_12();
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x0000D14F File Offset: 0x0000B34F
		public override ushort A7B71418()
		{
			return this.class8_0.A7B71418();
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x0000D15C File Offset: 0x0000B35C
		public override uint vmethod_13()
		{
			return this.class8_0.vmethod_13();
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0000D169 File Offset: 0x0000B369
		public override ulong vmethod_14()
		{
			return this.class8_0.vmethod_14();
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0000D176 File Offset: 0x0000B376
		public override float C0EC1D52()
		{
			return this.class8_0.C0EC1D52();
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0000D183 File Offset: 0x0000B383
		public override double F979B236()
		{
			return this.class8_0.F979B236();
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0000D190 File Offset: 0x0000B390
		public override IntPtr C2F10BC1()
		{
			return this.class8_0.C2F10BC1();
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x0000D19D File Offset: 0x0000B39D
		public override UIntPtr vmethod_15()
		{
			return this.uintptr_0;
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0000D1A5 File Offset: 0x0000B3A5
		public unsafe override void* vmethod_16()
		{
			return this.uintptr_0.ToPointer();
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0000D1B2 File Offset: 0x0000B3B2
		public override object BF2B5883(Type type_0, bool bool_0)
		{
			return this.class8_0.BF2B5883(type_0, bool_0);
		}

		// Token: 0x04000AF7 RID: 2807
		private UIntPtr uintptr_0;

		// Token: 0x04000AF8 RID: 2808
		private GClass18.Class8 class8_0;
	}

	// Token: 0x02000207 RID: 519
	private sealed class Class28 : GClass18.Class9
	{
		// Token: 0x06001539 RID: 5433 RVA: 0x0009B878 File Offset: 0x00099A78
		public Class28(Enum enum_1)
		{
			uint num;
			for (;;)
			{
				base..ctor();
				num = 0x8A8U;
				if (enum_1 == null)
				{
					goto IL_53;
				}
				num *= 0x6D220E5DU;
				if (0x6DD719A3U != num)
				{
					num = (0x73527EB5U & num);
					this.enum_0 = enum_1;
					num = 0x2B011E37U << (int)num;
					if ((0x3D6C60D4U ^ num) != 0U)
					{
						break;
					}
				}
			}
			goto IL_61;
			IL_53:
			if (0xE8617A0U >= num)
			{
				throw new ArgumentException();
			}
			IL_61:
			num = (0x26D86EFFU ^ num);
			num ^= 0x2DC53B5DU;
			GClass18.Class8 @class = GClass18.Class28.smethod_0(this.enum_0);
			num = 0x50012165U + num;
			this.class8_0 = @class;
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x0009B910 File Offset: 0x00099B10
		private static GClass18.Class8 smethod_0(Enum enum_1)
		{
			TypeCode typeCode = enum_1.GetTypeCode();
			uint num = 0x30AD27F4U;
			for (;;)
			{
				TypeCode typeCode2 = typeCode;
				uint num2 = num - 0x30AD27EFU;
				num -= 0x376F63BFU;
				switch (typeCode2 - num2)
				{
				case 0:
				case 2:
				case 4:
					goto IL_6F;
				case 1:
				case 3:
				case 5:
					num = 0x613D0F09U * num;
					if (num < 0x1E9C7362U)
					{
						continue;
					}
					goto IL_8B;
				case 6:
					goto IL_9F;
				case 7:
					goto IL_B3;
				}
				break;
			}
			num = (0x22EF2399U & num);
			throw new InvalidOperationException();
			IL_6F:
			num = 0x3F1A5571U * num;
			int int_ = Convert.ToInt32(enum_1);
			num ^= 0x4EF912A0U;
			return new GClass18.Class10(int_);
			IL_8B:
			num *= 0x731E3A9DU;
			return new GClass18.Class10((int)Convert.ToUInt32(enum_1));
			IL_9F:
			num += 0x627D63EFU;
			return new GClass18.Class11(Convert.ToInt64(enum_1));
			IL_B3:
			return new GClass18.Class11((long)Convert.ToUInt64(enum_1));
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0000D1C1 File Offset: 0x0000B3C1
		public override GClass18.Class8 vmethod_5()
		{
			return this.class8_0.vmethod_5();
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x0000D1CE File Offset: 0x0000B3CE
		public override Type vmethod_6()
		{
			return this.enum_0.GetType();
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0000D1DB File Offset: 0x0000B3DB
		public override TypeCode vmethod_7()
		{
			return this.class8_0.vmethod_7();
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0000D1E8 File Offset: 0x0000B3E8
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class28(this.enum_0);
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0000D1F5 File Offset: 0x0000B3F5
		public override object vmethod_1()
		{
			return this.enum_0;
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x0000D1FD File Offset: 0x0000B3FD
		public override void vmethod_2(object object_0)
		{
			if (object_0 == null)
			{
				throw new ArgumentException();
			}
			this.enum_0 = (Enum)object_0;
			this.class8_0 = GClass18.Class28.smethod_0(this.enum_0);
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x0000D225 File Offset: 0x0000B425
		public override byte vmethod_12()
		{
			return this.class8_0.vmethod_12();
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x0000D232 File Offset: 0x0000B432
		public override sbyte vmethod_8()
		{
			return this.class8_0.vmethod_8();
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x0000D23F File Offset: 0x0000B43F
		public override short vmethod_9()
		{
			return this.class8_0.vmethod_9();
		}

		// Token: 0x06001544 RID: 5444 RVA: 0x0000D24C File Offset: 0x0000B44C
		public override ushort A7B71418()
		{
			return this.class8_0.A7B71418();
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x0000D259 File Offset: 0x0000B459
		public override int vmethod_10()
		{
			return this.class8_0.vmethod_10();
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x0000D266 File Offset: 0x0000B466
		public override uint vmethod_13()
		{
			return this.class8_0.vmethod_13();
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x0000D273 File Offset: 0x0000B473
		public override long AFC5EABA()
		{
			return this.class8_0.AFC5EABA();
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x0000D280 File Offset: 0x0000B480
		public override ulong vmethod_14()
		{
			return this.class8_0.vmethod_14();
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x0000D28D File Offset: 0x0000B48D
		public override float C0EC1D52()
		{
			return this.class8_0.C0EC1D52();
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x0000D29A File Offset: 0x0000B49A
		public override double F979B236()
		{
			return this.class8_0.F979B236();
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x0009B9DC File Offset: 0x00099BDC
		public override IntPtr C2F10BC1()
		{
			uint num = 0xB8F2223U;
			do
			{
				if (IntPtr.Size != (int)(num + 0xF470DDE1U))
				{
					num = 0x22A52542U << (int)num;
					if ((num ^ 0x540028CCU) != 0U)
					{
						goto Block_2;
					}
				}
			}
			while (0x713D16A1U < num);
			long num2 = (long)this.vmethod_10();
			num *= 0x61B17D93U;
			long value = num2;
			num ^= 0x12ABB119U;
			goto IL_68;
			Block_2:
			num = 0x66C76A5U << (int)num;
			value = this.AFC5EABA();
			IL_68:
			return new IntPtr(value);
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x0009BA58 File Offset: 0x00099C58
		public override UIntPtr vmethod_15()
		{
			uint num = 0x5CA77666U;
			for (;;)
			{
				int size = IntPtr.Size;
				num = 0x7AEC7720U % num;
				uint num2 = num + 0xE1BAFF4AU;
				num -= 0xD3E26E2U;
				if (size != num2)
				{
					break;
				}
				num = (0x3A6172B7U | num);
				if (0x7F9952FEU > num)
				{
					goto IL_46;
				}
			}
			num ^= 0x46224851U;
			ulong value = this.vmethod_14();
			goto IL_65;
			IL_46:
			num -= 0x185D2375U;
			ulong num3 = (ulong)this.vmethod_13();
			num >>= 9;
			value = num3;
			num ^= 0x573514E5U;
			IL_65:
			return new UIntPtr(value);
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x0000D2A7 File Offset: 0x0000B4A7
		public override object BF2B5883(Type type_0, bool bool_0)
		{
			return this.class8_0.BF2B5883(type_0, bool_0);
		}

		// Token: 0x04000AF9 RID: 2809
		private Enum enum_0;

		// Token: 0x04000AFA RID: 2810
		private GClass18.Class8 class8_0;
	}

	// Token: 0x02000208 RID: 520
	private sealed class Class24 : GClass18.Class19
	{
		// Token: 0x0600154E RID: 5454 RVA: 0x0000D2B6 File Offset: 0x0000B4B6
		public Class24(IntPtr intptr_1, Type type_1)
		{
			this.intptr_0 = intptr_1;
			this.type_0 = type_1;
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x0000D2CC File Offset: 0x0000B4CC
		public override Type vmethod_6()
		{
			return typeof(Pointer);
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0000C5CA File Offset: 0x0000A7CA
		public override TypeCode vmethod_7()
		{
			return TypeCode.Empty;
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0000D2D8 File Offset: 0x0000B4D8
		public override GClass18.Class8 vmethod_0()
		{
			return new GClass18.Class24(this.intptr_0, this.type_0);
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x0000D2EB File Offset: 0x0000B4EB
		public override object vmethod_1()
		{
			if (!this.type_0.IsValueType)
			{
				throw new InvalidOperationException();
			}
			return Marshal.PtrToStructure(this.intptr_0, this.type_0);
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0009BAD0 File Offset: 0x00099CD0
		public override void vmethod_2(object object_0)
		{
			IL_00:
			while (object_0 != null)
			{
				uint num;
				for (;;)
				{
					bool isValueType = this.type_0.IsValueType;
					num = 0xFD184592U;
					if (isValueType)
					{
						num /= 0x342B4553U;
						if ((0x407F06D9U ^ num) == 0U)
						{
							continue;
						}
					}
					else
					{
						for (;;)
						{
							TypeCode typeCode = Type.GetTypeCode(object_0.GetType());
							num = 0x3C8B63FDU % num;
							TypeCode typeCode2 = typeCode;
							num |= 0x6909443EU;
							uint num2 = (uint)typeCode2;
							num = 0x68B856CFU - num;
							uint num3 = num2 - (num ^ 0xEB2CEED4U);
							num |= 0x5ED97453U;
							switch (num3)
							{
							case 0:
								if (0x3D8B3B21U != num)
								{
									goto Block_1;
								}
								continue;
							case 1:
								goto IL_222;
							case 2:
								goto IL_25B;
							case 3:
								goto IL_83;
							case 4:
								goto IL_28A;
							case 5:
								goto IL_2C5;
							case 6:
								goto IL_188;
							case 7:
								goto IL_CE;
							case 8:
								goto IL_309;
							case 9:
								goto IL_143;
							case 0xA:
								goto IL_1A1;
							}
							goto Block_2;
						}
						IL_83:
						num = (0x56C22FCBU ^ num);
						if (num <= 0x42F8156EU)
						{
							goto IL_00;
						}
						num = 0x4FBF0E36U << (int)num;
						IntPtr ptr = this.intptr_0;
						num |= 0x62C11C4U;
						Marshal.WriteInt16(ptr, Convert.ToInt16(object_0));
						if (num * 0x5F6D4B05U != 0U)
						{
							return;
						}
						continue;
						IL_CE:
						num = 0x8350562U << (int)num;
						if (0x24337F5AU >= num)
						{
							goto IL_00;
						}
						IntPtr ptr2 = this.intptr_0;
						num /= 0x3EEE7A1AU;
						Marshal.WriteInt64(ptr2, Convert.ToInt64(object_0));
						if (0x552932A1U != num)
						{
							return;
						}
						goto IL_10D;
						IL_143:
						num = (0x3F633E6DU & num);
						if (num / 0x6EB63F03U == 0U)
						{
							goto Block_8;
						}
						continue;
					}
					IL_10D:
					num *= 0x4E8F4F5BU;
					IntPtr ptr3 = this.intptr_0;
					num = 0x3EE36564U >> (int)num;
					Marshal.StructureToPtr(object_0, ptr3, num - 0x3EE36U != 0U);
					if (num <= 0x736A0F64U)
					{
						return;
					}
				}
				IL_188:
				num |= 0x472B0940U;
				if (num % 0x1FC365B2U != 0U)
				{
					num *= 0x4B87359FU;
					IntPtr ptr4 = this.intptr_0;
					num = 0x28263A57U >> (int)num;
					int val = (int)Convert.ToUInt32(object_0);
					num >>= 0x1C;
					Marshal.WriteInt32(ptr4, val);
					return;
				}
				continue;
				IL_1A1:
				num -= 0x37F30F86U;
				IntPtr ptr5 = this.intptr_0;
				num *= 0x15DD09EAU;
				num = 0x76A20512U << (int)num;
				double value = Convert.ToDouble(object_0);
				num %= 0xD134959U;
				long val2 = BitConverter.ToInt64(BitConverter.GetBytes(value), (int)(num - 0x9537EB8U));
				num = (0x4D140073U & num);
				Marshal.WriteInt64(ptr5, val2);
				if (num / 0x4FD16DC3U == 0U)
				{
					return;
				}
				continue;
				Block_1:
				IntPtr ptr6 = this.intptr_0;
				num *= 0x6C607B18U;
				Marshal.WriteInt16(ptr6, Convert.ToChar(object_0));
				return;
				Block_2:
				throw new ArgumentException();
				Block_8:
				num = 0x2DF02CD7U << (int)num;
				IntPtr ptr7 = this.intptr_0;
				num = (0x5DFE0324U | num);
				int val3 = BitConverter.ToInt32(BitConverter.GetBytes(Convert.ToSingle(object_0)), (int)(num ^ 0x5FFE5BAEU));
				num <<= 0xC;
				Marshal.WriteInt32(ptr7, val3);
				return;
				IL_222:
				num *= 0x3D151C9AU;
				IntPtr ptr8 = this.intptr_0;
				num &= 0x55B86F36U;
				num >>= 4;
				byte b = (byte)Convert.ToSByte(object_0);
				num = 0x21D41AEEU << (int)num;
				Marshal.WriteByte(ptr8, b);
				return;
				IL_25B:
				num >>= 0;
				num = 0x47E31328U + num;
				Marshal.WriteByte(this.intptr_0, Convert.ToByte(object_0));
				if (num % 0x14612F1U != 0U)
				{
					return;
				}
				break;
				IL_28A:
				num *= 0x6FDE11CAU;
				num <<= 5;
				IntPtr ptr9 = this.intptr_0;
				num = (0x1E217A92U & num);
				short num4 = (short)Convert.ToUInt16(object_0);
				num = 0x36881277U / num;
				short val4 = num4;
				num &= 0x256F6F6BU;
				Marshal.WriteInt16(ptr9, val4);
				return;
				IL_2C5:
				Marshal.WriteInt32(this.intptr_0, Convert.ToInt32(object_0));
				return;
				IL_309:
				IntPtr ptr10 = this.intptr_0;
				num = 0x36672E7AU * num;
				long val5 = (long)Convert.ToUInt64(object_0);
				num ^= 0x3694311U;
				Marshal.WriteInt64(ptr10, val5);
				if (0x657430E2U % num != 0U)
				{
					return;
				}
				IL_334:
				throw new ArgumentException();
			}
			goto IL_334;
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x0000D311 File Offset: 0x0000B511
		public override sbyte vmethod_8()
		{
			return (sbyte)Marshal.ReadByte(this.intptr_0);
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0000D31F File Offset: 0x0000B51F
		public override short vmethod_9()
		{
			return Marshal.ReadInt16(this.intptr_0);
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x0000D32C File Offset: 0x0000B52C
		public override int vmethod_10()
		{
			return Marshal.ReadInt32(this.intptr_0);
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0000D339 File Offset: 0x0000B539
		public override long AFC5EABA()
		{
			return Marshal.ReadInt64(this.intptr_0);
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x0000D346 File Offset: 0x0000B546
		public override char vmethod_11()
		{
			return (char)Marshal.ReadInt16(this.intptr_0);
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0000D354 File Offset: 0x0000B554
		public override byte vmethod_12()
		{
			return Marshal.ReadByte(this.intptr_0);
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0000D346 File Offset: 0x0000B546
		public override ushort A7B71418()
		{
			return (ushort)Marshal.ReadInt16(this.intptr_0);
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0000D32C File Offset: 0x0000B52C
		public override uint vmethod_13()
		{
			return (uint)Marshal.ReadInt32(this.intptr_0);
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0000D339 File Offset: 0x0000B539
		public override ulong vmethod_14()
		{
			return (ulong)Marshal.ReadInt64(this.intptr_0);
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0000D361 File Offset: 0x0000B561
		public override float C0EC1D52()
		{
			return BitConverter.ToSingle(BitConverter.GetBytes(Marshal.ReadInt32(this.intptr_0)), 0);
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0000D379 File Offset: 0x0000B579
		public override double F979B236()
		{
			return BitConverter.ToDouble(BitConverter.GetBytes(Marshal.ReadInt64(this.intptr_0)), 0);
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x0009BE58 File Offset: 0x0009A058
		public override IntPtr C2F10BC1()
		{
			int size = IntPtr.Size;
			int num = 4;
			uint num2 = 0x5813284EU;
			long value;
			if (size != num && (num2 ^ 0x327B3734U) != 0U)
			{
				num2 = 0x54937E4BU << (int)num2;
				IntPtr ptr = this.intptr_0;
				num2 = 0x664769B3U % num2;
				value = Marshal.ReadInt64(ptr);
			}
			else
			{
				num2 -= 0x490B1F01U;
				IntPtr ptr2 = this.intptr_0;
				num2 = 0x47D263B7U / num2;
				long num3 = (long)Marshal.ReadInt32(ptr2);
				num2 <<= 0xF;
				value = num3;
				num2 ^= 0x664569B3U;
			}
			num2 = (0x64EE11A9U & num2);
			return new IntPtr(value);
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x0009BED8 File Offset: 0x0009A0D8
		public override UIntPtr vmethod_15()
		{
			uint num2;
			for (;;)
			{
				int size = IntPtr.Size;
				int num = 4;
				num2 = 0x12B542A2U;
				if (size != num)
				{
					break;
				}
				num2 *= 0x559C6593U;
				if ((num2 & 0x17833E09U) != 0U)
				{
					goto Block_1;
				}
			}
			num2 = 0x17B7217EU - num2;
			ulong value = (ulong)Marshal.ReadInt64(this.intptr_0);
			goto IL_54;
			Block_1:
			ulong num3 = (ulong)Marshal.ReadInt32(this.intptr_0);
			num2 %= 0x628E252BU;
			value = num3;
			num2 += 0xC178D701U;
			IL_54:
			num2 >>= 0xA;
			return new UIntPtr(value);
		}

		// Token: 0x04000AFB RID: 2811
		private IntPtr intptr_0;

		// Token: 0x04000AFC RID: 2812
		private Type type_0;
	}

	// Token: 0x02000209 RID: 521
	private sealed class Class37
	{
		// Token: 0x06001561 RID: 5473 RVA: 0x0009BF48 File Offset: 0x0009A148
		public Class37(byte byte_1, int int_2, int int_3)
		{
			uint num;
			do
			{
				this.byte_0 = byte_1;
				num = 0x2FFE8000U;
				do
				{
					num = 0x62901AFCU >> (int)num;
					this.int_0 = int_2;
					num %= 0x30C10046U;
				}
				while (0x1B59444FU / num == 0U);
				this.int_1 = int_3;
			}
			while (num % 0x77A259C4U == 0U);
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x0000D391 File Offset: 0x0000B591
		public byte method_0()
		{
			return this.byte_0;
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x0000D399 File Offset: 0x0000B599
		public int method_1()
		{
			return this.int_0;
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x0000D3A1 File Offset: 0x0000B5A1
		public int method_2()
		{
			return this.int_1;
		}

		// Token: 0x04000AFD RID: 2813
		private byte byte_0;

		// Token: 0x04000AFE RID: 2814
		private int int_0;

		// Token: 0x04000AFF RID: 2815
		private int int_1;
	}

	// Token: 0x0200020A RID: 522
	private sealed class Class38
	{
		// Token: 0x06001565 RID: 5477 RVA: 0x0009BFA8 File Offset: 0x0009A1A8
		public Class38(int int_2, int int_3)
		{
			this.list_0 = new List<GClass18.Class37>();
			uint num = 0U;
			do
			{
				base..ctor();
				num -= 0x3C4C2BD2U;
				num = 0x168A317BU >> (int)num;
				num += 0xCA52D2EU;
				this.int_0 = int_2;
				num = 0x198038C9U + num;
			}
			while (0x1E1E2F3DU == num);
			do
			{
				num >>= 6;
				this.int_1 = int_3;
			}
			while (num + 0x2C2902F4U == 0U);
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0000D3A9 File Offset: 0x0000B5A9
		public int method_0()
		{
			return this.int_0;
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0000D3B1 File Offset: 0x0000B5B1
		public int method_1()
		{
			return this.int_1;
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0009C024 File Offset: 0x0009A224
		public int method_2(GClass18.Class38 class38_0)
		{
			uint num;
			int num2;
			int num3;
			do
			{
				num = 0x240F5CDDU;
				if (class38_0 == null)
				{
					goto IL_AB;
				}
				num = 0x73335079U % num;
				if (0x401B0335U < num)
				{
					goto IL_AB;
				}
				num = 0xEB51884U / num;
				int value = class38_0.method_0();
				num = (0x90A539BU ^ num);
				num2 = this.int_0.CompareTo(value);
				num %= 0x21D41009U;
				if (num2 != 0)
				{
					goto IL_A1;
				}
				num /= 0x6DAE5455U;
				num = (0x5E1D3CB6U & num);
				num3 = class38_0.method_1();
				num = (0x3D625545U | num);
			}
			while (0x74172677U < num);
			num <<= 0xC;
			int value2 = this.int_1;
			num = 0x7027768DU * num;
			int num4 = num3.CompareTo(value2);
			num = (0x6FA348A7U | num);
			num2 = num4;
			num ^= 0xF6F90B3EU;
			IL_A1:
			num = 0x75D3163FU / num;
			return num2;
			IL_AB:
			return (int)(num + 0xDBF0A324U);
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x0000D3B9 File Offset: 0x0000B5B9
		public void method_3(byte byte_0, int int_2, int int_3)
		{
			this.list_0.Add(new GClass18.Class37(byte_0, int_2, int_3));
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x0000D3CE File Offset: 0x0000B5CE
		public List<GClass18.Class37> method_4()
		{
			return this.list_0;
		}

		// Token: 0x04000B00 RID: 2816
		private int int_0;

		// Token: 0x04000B01 RID: 2817
		private int int_1;

		// Token: 0x04000B02 RID: 2818
		private List<GClass18.Class37> list_0;
	}

	// Token: 0x0200020B RID: 523
	// (Invoke) Token: 0x0600156C RID: 5484
	internal delegate void Delegate2();
}
