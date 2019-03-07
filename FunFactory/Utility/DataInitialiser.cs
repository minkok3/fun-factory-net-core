using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApp.Data;
using WebApp.Domain;

namespace WebApp.Utility
{
    public static class DataInitialiser
    {
        public static void SeedData(FunFactoryDbContext context)
        {
            context.Database.Migrate();
            if (context.Products.Any()) return;

            var cpu = new Component
            {
                Name = "Intel Core i7-6700K 4GHz Socket 1151 8MB L3 Cache Retail Boxed Processor",
                Description = "Intel Skylake<br/>Intel Core i7-6700K Processor<br/>Intel Socket LGA 1151<br/>4GHz Core Frequency<br/>Heatsink and fan not included",
                Price = 290,
                Sku = "INTEL-CPU-001",
                StockQty = 250
            };
            var mb = new Component
            {
                Name = "EVGA Z170 Stinger Socket 1151 HDMI DisplayPort 8 Channel HD Audio mITX Motherboard",
                Description = "Intel Z170 Express Chipset<br/>Intel Socket LGA 1151<br/>8-channel high definition audio<br/>mITX Form Factor",
                Price = 190,
                Sku = "EVGA-MB-001",
                StockQty = 130
            };
            var ram = new Component
            {
                Name = "Corsair 8GB DDR3 1866MHz Vengeance Memory",
                Description = "8GB 2400MHz<br/>Latency: 14-16-16-31<br/>1.2V<br/>Low Profile & Heat Spreader<br/>Designed for high-performance overclocking<br/>Limited Lifetime Manufacturer Warranty",
                Price = 35,
                Sku = "COS-RAM-001",
                StockQty = 500
            };
            var ssd =
                new Component
                {
                    Name = "Samsung 950 PRO 512GB M.2 SSD",
                    Description = "Capacity 512GB<br/>Form Factor M.2(2280)<br/>Interface PCIe 3.0 x4 (up to 32Gb/s)<br/>NAND Flash Memory Samsung V-NAND",
                    Price = 250,
                    Sku = "SAM-SSD-001",
                    StockQty = 100
                };
            var gfx =
                new Component
                {
                    Name = "EVGA GTX 970 Superclocked GAMING ACX 2.0 4GB GDDR5 Dual DVI HDMI DisplayPort PCI-E Graphics Card",
                    Description = "VR READY<br/>Free Tom Clancy's The Division Download<br/>NVIDIA GeForce GTX 970 GPU<br/>MSI Twin Frozr V Edition<br/>4GB GDDR5 Memory",
                    Price = 250,
                    Sku = "EVGA-GFX-001",
                    StockQty = 70
                };
            var psu =
                new Component
                {
                    Name = "EVGA Supernova 750W Fully Modular 80+ Gold Power Supply",
                    Description = "Black Coloured PSU with a 135mm Silent Cooling Fan<br/>Equipped with a Single 12v Rail Delivering upto 61 Amps<br/>Equipped with 4 x 8pin PCI-E Connectors for Graphics Cards",
                    Price = 90,
                    Sku = "EVGA-PSU-001",
                    StockQty = 250
                };
            var casing =
                new Component
                {
                    Name = "Fractal Design Define Mini Case",
                    Description = "Mini version of the bestselling Define R3<br/>Compatible with MicroATX and Mini ITX Motherboards<br/>Fitted with dense, noise absorbing material<br/>2x 120mm fans included, up to 5 fans can be installed",
                    Price = 70,
                    Sku = "FD-CAS-001",
                    StockQty = 150
                };

            context.Products.Add(cpu);
            context.Products.Add(mb);
            context.Products.Add(ram);
            context.Products.Add(gfx);
            context.Products.Add(ssd);
            context.Products.Add(psu);
            context.Products.Add(casing);
            context.SaveChanges();

            //kit products
            var kit1 =

                new Component
                {
                    Name = "Core Upgrade Kit #1",
                    Description = @"Save £150.. and get your PC up to next generation",
                    Price = 900,
                    Sku = "KIT-001",
                    StockQty = 70,
                };
            context.Products.Add(kit1);
            context.SaveChanges();

            kit1.KitComponents = new List<KitComponent>
            {
                new KitComponent
                {
                    Component = cpu,
                    Qty = 1
                },
                new KitComponent
                {
                    Component = mb,
                    Qty = 1
                },
                new KitComponent
                {
                    Component = ram,
                    Qty = 2
                },
                new KitComponent
                {
                    Component = ssd,
                    Qty = 1
                },
                new KitComponent
                {
                    Component = gfx,
                    Qty = 1
                },
            };
            context.Products.Attach(kit1);
            context.SaveChanges();

            var kit2 =
                new Component
                {
                    Name = "Gaming Kit #1",
                    Description = @"Save £210.. Everything you need for your nex gaming pc.",
                    Price = 1000,
                    Sku = "KIT-002",
                    StockQty = 70,
                    KitComponents = new List<KitComponent>
                    {
                        new KitComponent
                        {
                            Component = kit1,
                            Qty = 1
                        },
                        new KitComponent
                        {
                            Component = psu,
                            Qty = 1
                        },
                        new KitComponent
                        {
                            Component = casing,
                            Qty = 1
                        },
                    }
                };

            context.Products.Add(kit2);
            context.SaveChanges();
        }
    }
}
