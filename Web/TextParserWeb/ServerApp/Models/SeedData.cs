using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
namespace ServerApp
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (context.Documents.Count() == 0)
            {
                context.Documents.AddRange(
                new Document
                {
                    Filename = "filesorgente01.txt",
                    OriginPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\src",
                    ImportDate = new DateTime(2020, 1, 1, 12, 0, 0),
                    Content = @"intestazione
                        ->ident01 riga02 asdasdsafsaasdsadsadasdaso
                        ->ident02  riga03 qweqweqweweqweo
                        qweqwewqeqweqweqweqwo
                        qwewqeqweqweqweo
                        qweqweqweqweqweo
                        ->ident03
                        riga07 zxczxcxzczxcxzcx czx cxz c xzcxz cxzcxzcxzccxzxc zxzc xzcxzcxzcxc zxzcxzcxzc xzcxzcxzcxzcxczo
                        EOF",
                    Fragments = new List<Fragment> { 
                            new Fragment { Identifier = "ident01", DestPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\dest\\ident01", RowIndex = 2, Text = @"riga02 asdasdsafsaasdsadsadasdaso" }, 
                            new Fragment { Identifier = "ident02", DestPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\dest\\ident02", RowIndex = 3, Text = @"riga03 qweqweqweweqweo
                        qweqwewqeqweqweqweqwo
                        qwewqeqweqweqweo
                        qweqweqweqweqweo" },
                            new Fragment { Identifier = "ident03", DestPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\dest\\ident03", RowIndex = 7, Text = @"riga07 zxczxcxzczxcxzcx czx cxz c xzcxz cxzcxzcxzccxzxc zxzc xzcxzcxzcxc zxzcxzcxzc xzcxzcxzcxzcxczo
                        EOF" }
                    }
                },
                new Document
                {
                    Filename = "filesorgente02",
                    OriginPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\src",
                    ImportDate = new DateTime(2020, 1, 1, 12, 1, 0),
                    Content = @"intestazione
                        ->ident04 riga02 asdasdsafsaasdsadsadasdaso
                        ->ident05  riga03 qweqweqweweqweo
                        qweqwewqeqweqweqweqwo
                        qwewqeqweqweqweo
                        qweqweqweqweqweo
                        ->ident06
                        riga07 zxczxcxzczxcxzcx czx cxz c xzcxz cxzcxzcxzccxzxc zxzc xzcxzcxzcxc zxzcxzcxzc xzcxzcxzcxzcxczo
                        EOF",
                    Fragments = new List<Fragment> {
                            new Fragment { Identifier = "ident04", DestPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\dest\\ident04", RowIndex = 2, Text = @"riga02 asdasdsafsaasdsadsadasdaso" },
                            new Fragment { Identifier = "ident05", DestPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\dest\\ident05", RowIndex = 3, Text = @"riga03 qweqweqweweqweo
                        qweqwewqeqweqweqweqwo
                        qwewqeqweqweqweo
                        qweqweqweqweqweo" },
                            new Fragment { Identifier = "ident06", DestPath = "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test\\dest\\ident06", RowIndex = 7, Text = @"riga07 zxczxcxzczxcxzcx czx cxz c xzcxz cxzcxzcxzccxzxc zxzc xzcxzcxzcxc zxzcxzcxzc xzcxzcxzcxzcxczo
                        EOF" }
                    }
                });
                context.SaveChanges();
            }
        }
    }
}