# FunDoo Notes – Backend API 

---

## 🛠 Tech Stack

- **Framework:** ASP.NET Core Web API
- **Language:** C#
- **ORM:** Entity Framework Core
- **Database:** SQL Server Express
- **Authentication:** JWT (JSON Web Tokens)
- **Email Service:** SMTP (OTP-based verification)
- **Architecture:** Layered Architecture

---


---

## 🔐 Authentication Features

- User Registration
- User Login
- JWT Token Generation
- Email OTP Verification (SMTP)
- Secure Password Hashing using BCrypt

---

## 📝 Notes Features

- Create Note
- Update Note
- Delete Note
- Get All Notes (User-specific)
- Pin / Unpin Notes
- Archive / Unarchive Notes
- Change Note Color

---

## 🏷 Labels Features

- Create Label
- Update Label
- Delete Label
- Get All Labels for a User
- Assign Labels to Notes
- Remove Labels from Notes

---

## 👥 Collaborators Features

- Add collaborator to a note using email
- Remove collaborator from a note
- Get collaborators for a note
- Ownership validation for note access

---

## 🕒 Notes History 

- Automatically tracks changes on note updates
- Stores old title and old content
- Saves modification timestamp
- Linked to individual notes

---

## 🗃 Database Relationships

- **User → Notes** (One-to-Many)
- **Notes ↔ Labels** (Many-to-Many)
- **Notes → Collaborators** (One-to-Many)
- **Notes → NoteHistory** (One-to-Many)

---

## 🔄 API Security

All protected endpoints require JWT authentication.


### In FunDooWebApi (the startup project) -> appsettings.json has all the secret keys

appsettings.json 

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "FunDooDBConnectionString": "Server=localhost\\SQLEXPRESS;Database=FunDooDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "THIS_IS_A_SUPER_SECRET_KEY_123456",
    "Issuer": "FunDooAPI",
    "Audience": "FunDooUser"
  },
    "Smtp": {
      "Host": "smtp.gmail.com",
      "Port": 587,
      "EnableSsl": true,
      "Email": "the mail@gmail.com",
      "AppPassword": "16 letter app pass key"
    }
  }

```



## 🧪 API Testing

- Swagger UI enabled
- Test APIs using Swagger or Postman



