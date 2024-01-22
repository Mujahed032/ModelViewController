using Humsafar_Mubarak.Data.Enum;
using Humsafar_Mubarak.Models;

namespace Humsafar_Mubarak.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.CandidateProfiles.Any())
                {
                    var personDetails1 = new PersonDetails
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Relation = RelationToCandidate.Self,
                        Contact = new Contact
                        {
                            MobileNumbers = 9876543210 ,
                            EmailAddress = "johndoe@example.com",
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Country = "USA",
                                    AddressLine1 = "123 Main St",
                                    City = "New York",
                                    State = "NY",
                                    ZipPostalCode = "10001",
                                    HouseType = HouseType.Own
                                }
                            }
                        },
                        Education = new Education
                        {
                            HighestQualification = EducationLevel.Graduate,
                            NameOfInstitution = "ABC University"
                        },
                        Employed = true,
                        Employment = new Employment
                        {
                            CompanyOrBusinessName = "XYZ Company",
                            Designation = "Manager",
                            EmploymentType = EmploymentType.PrivateBusiness
                        }
                    };

                    var personDetails2 = new PersonDetails
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Relation = RelationToCandidate.Self,
                        Contact = new Contact
                        {
                            MobileNumbers = 9876543210 ,
                            EmailAddress = "janedoe@example.com",
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Country = "USA",
                                    AddressLine1 = "456 Main St",
                                    City = "Los Angeles",
                                    State = "CA",
                                    ZipPostalCode = "90001",
                                    HouseType = HouseType.Rent
                                }
                            }
                        },
                        Education = new Education
                        {
                            HighestQualification = EducationLevel.PostGraduate,
                            NameOfInstitution = "XYZ University"
                        },
                        Employed = true,
                        Employment = new Employment
                        {
                            CompanyOrBusinessName = "ABC Enterprises",
                            Designation = "Director",
                            EmploymentType = EmploymentType.SalariedEmployee
                        }
                    };

                    var salaryDetails = new SalaryDetails
                    {
                        Currency = "USD",
                        SalaryAmount = 80000,
                        SalaryFrequency = SalaryFrequency.Monthly
                    };

                    context.CandidateProfiles.AddRange(new List<CandidateProfile>
                    {
                        new CandidateProfile
                        {
                            DateOfBirth = new DateTime(1990, 1, 1),
                            Age = 32,
                            Gender = Gender.Male,
                            Person = personDetails1,
                            MaritalStatus = MaritalStatus.Married,
                            PhotoTag = "Sample Tag 1",
                            Image = "sample1.jpg",
                            Description = "Sample Description 1",
                            
                            Salary = salaryDetails,
                            BodyType = "Sample Body Type 1",
                            Complexion = "Sample Complexion 1",
                            Weight = "70 kg",
                            Height = "180 cm",
                            Diet = "Sample Diet 1",
                            Personality = "Sample Personality 1",
                            Religion = Religion.Islam
                        },
                        new CandidateProfile
                        {
                            DateOfBirth = new DateTime(1988, 5, 15),
                            Age = 34,
                            Gender = Gender.Female,
                            Person = personDetails2,
                            MaritalStatus = MaritalStatus.Married,
                            PhotoTag = "Sample Tag 2",
                            Image = "sample2.jpg",
                            Description = "Sample Description 2",
                           
                            Salary = salaryDetails,
                            BodyType = "Sample Body Type 2",
                            Complexion = "Sample Complexion 2",
                            Weight = "60 kg",
                            Height = "165 cm",
                            Diet = "Sample Diet 2",
                            Personality = "Sample Personality 2",
                            Religion = Religion.Hinduism
                        },
                        // Add more CandidateProfile data here as needed
                    });

                    context.SaveChanges();
                }

                // Add User and other model data here similarly
            }
        }
    }
}
