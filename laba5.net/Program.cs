using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5.net
{
    //Многоадресный и одноадресный делегат;
    delegate void Multicast();
    delegate void Unicast();

    class Program
    {
        private string Organization_1 { get; set; } = "Georgin";
        private string InsuranceCompany_1 { get; set; } = "Universalna" ;
        private string OilGasCompany_1 { get; set; } = "Gasprom";
        private string Plant_1 { get; set; } = "Biofarm";
       
        public Program(string New_Plant, string New_Organization, string New_InsuranceCompany, string New_OilGasCompany)
        {
            Plant_1 = New_Plant;
            Organization_1 = New_Organization;
            InsuranceCompany_1 = New_InsuranceCompany;
            OilGasCompany_1 = New_OilGasCompany;
           
        }
        public Program()
        { }
        static void Main(string[] args)
        {
            Program program = new Program();
            Unicast inputInfo = program.Input;
            inputInfo();
        }
        public void Input()
        {
            Information inform = new Information(Plant_1, Organization_1, InsuranceCompany_1, OilGasCompany_1);
            Information inform1 = new Information(Plant_1, Organization_1, InsuranceCompany_1, OilGasCompany_1);
            Write(inform,inform1);
        }
        static void Write(IPlant plant, ICompany company)
        {           
            Multicast writeInfo = plant.Write_Plant; 
            writeInfo += company.Write_Company;
            writeInfo();
        }
    }
    class Information : IPlant, ICompany
    {
        private string Plant { get; set; }
        private string Organization { get; set; }
        private string InsuranceCompany { get; set; }
        private string OilGasCompany { get; set; }
       

        public Information(string plant, string organization, string insuranceCompany, string oilGasCompany)
        {
            Plant = plant;
            Organization = organization;
            InsuranceCompany = insuranceCompany;
            OilGasCompany = oilGasCompany;
        }
        public Information()
        { }
       
        void IPlant.Write_Plant()
        {
            Console.WriteLine($"\nДанные о организации:\nЗавод: " + Plant);
            Console.WriteLine($"Организация: " + Organization);
           
        }
        void ICompany.Write_Company()
        {
            Console.WriteLine($"Страховая компания: " + InsuranceCompany);
            Console.WriteLine($"Нефтегазовая компания: " + OilGasCompany + "\n");
            Console.Write("Если вы хотите изменить данные нажмите 1, если нет - нажмите любое другое число.\n");

            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                ChangeInfo write = new ChangeInfo();
                Write_1(write);
            }
            else
            {
                Console.WriteLine("Вы отказались от изменений\n");
                Console.ReadLine();
            }
        }
        static void Write_1(IChangeInfo write)
        {
            Unicast writeInfo = write.Change_Info;
            writeInfo();
        }
    }

    interface IPlant
    {
        void Write_Plant();
    }
    interface ICompany
    {
        void Write_Company();
    }
    class ChangeInfo : IChangeInfo
    {
        private string New_Plant { get; set; }
        private string New_Organization { get; set; }
        private string New_InsuranceCompany { get; set; }
        private string New_OilGasCompany { get; set; }

        public ChangeInfo()
        { }

        void IChangeInfo.Change_Info()
        { 
       
            Console.Write("\nВведите новое название завода: ");
            New_Plant = Console.ReadLine();
            Console.Write("Введите новое название организации: ");
            New_Organization = Console.ReadLine();
            Console.Write("Введите новое название cтраховой компании: ");
            New_InsuranceCompany = Console.ReadLine();
            Console.Write("Введите новое название нефтегазовой компании: ");
            New_OilGasCompany = Console.ReadLine();
            Program program = new Program(New_Plant, New_Organization, New_InsuranceCompany, New_OilGasCompany);
            Unicast inputInfo = program.Input;
            inputInfo();
        }
    }

    interface IChangeInfo
    {
        void Change_Info();
    }
}
