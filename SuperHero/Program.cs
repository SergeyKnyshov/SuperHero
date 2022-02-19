using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SuperHero
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = System.IO.File.ReadAllText("superheroes.json");
            Config remake = JsonConvert.DeserializeObject<Config>(json);
            Directory.Create(remake);
            File.HeroCreate(remake);
        }

    }

    class Config
    {
        public string squadName{ get; set; }
        public string homeTown{ get; set; }
        public int formed { get; set; }
        public string secretBase { get; set; }
        public bool active { get; set; }
        public readonly List<Member> members = new List<Member>();
    }

    
    class Member
    {
        public string name { get; set; }
        public int age { get; set; }
        public string secretIdentity { get; set; }
        public readonly List<string> powers = new List<string>();
    }

    class Directory
    {
        public static void Create(Config remake)
        {
            string path = ".";
            string subpath = $@"{remake.squadName}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }
    }

    class File
    {
        public static void HeroCreate(Config remake)
        {
            foreach (var member in remake.members)
            {
                var silch = new StringBuilder();
                int i = 0;
                foreach (var power in member.powers)
                {
                    i++;
                    silch.AppendLine(i+","+power);
                }
                System.IO.File.WriteAllText($"{remake.squadName}/{member.name}.csv",silch.ToString());
            }
            
        }
        
        
        
    }

   
}