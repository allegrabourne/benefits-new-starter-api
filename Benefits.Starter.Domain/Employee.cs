using Benefits.Starter.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Domain
{
    public class Employee
    {
        public Guid Id { get; private set; }

        public string EmployeeNo { get; private set; } = default!;

        public Title Title { get; private set; } = Title.Unspecified;

        public string FirstName { get; private set; } = default!;

        public string Surname { get; private set; } = default!;

        public DateOnly DateOfBirth { get; private set; }

        public Gender Gender { get; private set; } = Gender.Unspecified;

        public string Email { get; private set; } = default!;

        public Address Address { get; private set; } = default!;

        public DateTime CreatedAtUtc { get; private set; }

        private Employee() { }

        public Employee(
            string employeeNo,
            Title title,
            string firstName,
            string surname,
            DateOnly dateOfBirth,
            Gender gender,
            string email,
            Address address)
        {
            Id = Guid.NewGuid();

            EmployeeNo = string.IsNullOrWhiteSpace(employeeNo)
                ? throw new ArgumentException("EmployeeNo is required.", nameof(employeeNo))
                : employeeNo.Trim();

            Title = title;

            FirstName = string.IsNullOrWhiteSpace(firstName)
                ? throw new ArgumentException("FirstName is required.", nameof(firstName))
                : firstName.Trim();

            Surname = string.IsNullOrWhiteSpace(surname)
                ? throw new ArgumentException("Surname is required.", nameof(surname))
                : surname.Trim();

            if (dateOfBirth == default)
                throw new ArgumentException("DOB is required.", nameof(dateOfBirth));

            DateOfBirth = dateOfBirth;

            Gender = gender;

            Email = string.IsNullOrWhiteSpace(email.Trim().ToLowerInvariant())
                ? throw new ArgumentException("Email is required.", nameof(email))
                : email.Trim().ToLowerInvariant();

            Address = address ?? throw new ArgumentNullException(nameof(address));

            CreatedAtUtc = DateTime.UtcNow;
        }
    }
}
