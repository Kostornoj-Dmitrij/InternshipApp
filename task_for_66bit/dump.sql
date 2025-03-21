PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsLock" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK___EFMigrationsLock" PRIMARY KEY,
    "Timestamp" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory VALUES('20250319232546_InitialCreate','9.0.0');
INSERT INTO __EFMigrationsHistory VALUES('20250321015343_UpdatePhoneNumberNullable','9.0.0');
CREATE TABLE IF NOT EXISTS "Directions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Directions" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    "UpdatedAt" TEXT NOT NULL
);
INSERT INTO Directions VALUES(9,'Frontend','2025-03-21 13:45:15.6409526','2025-03-21 13:45:15.6409526');
INSERT INTO Directions VALUES(10,'Backend','2025-03-21 13:50:02.8640087','2025-03-21 13:50:02.8640088');
CREATE TABLE IF NOT EXISTS "Projects" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Projects" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    "UpdatedAt" TEXT NOT NULL
);
INSERT INTO Projects VALUES(9,'Frontend project','2025-03-21 13:45:32.3522942','2025-03-21 13:45:32.3522943');
INSERT INTO Projects VALUES(10,'Backend project','2025-03-21 13:50:07.6568896','2025-03-21 13:50:07.6568897');
CREATE TABLE IF NOT EXISTS "Interns" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Interns" PRIMARY KEY AUTOINCREMENT,
    "CreatedAt" TEXT NOT NULL,
    "DateOfBirth" TEXT NOT NULL,
    "DirectionId" INTEGER NOT NULL,
    "Email" TEXT NOT NULL,
    "FirstName" TEXT NOT NULL,
    "Gender" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "PhoneNumber" TEXT NULL,
    "ProjectId" INTEGER NOT NULL,
    "UpdatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_Interns_Directions_DirectionId" FOREIGN KEY ("DirectionId") REFERENCES "Directions" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Interns_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("Id") ON DELETE CASCADE
);
INSERT INTO Interns VALUES(13,'2025-03-21 13:44:40.9235494','2004-09-24 00:00:00',10,'Mail@yandex.ru','Иван','Male','Иванов','+79562748263',10,'2025-03-21 13:44:40.9235495');
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('Directions',10);
INSERT INTO sqlite_sequence VALUES('Projects',10);
INSERT INTO sqlite_sequence VALUES('Interns',13);
CREATE INDEX "IX_Interns_DirectionId" ON "Interns" ("DirectionId");
CREATE UNIQUE INDEX "IX_Interns_Email" ON "Interns" ("Email");
CREATE UNIQUE INDEX "IX_Interns_PhoneNumber" ON "Interns" ("PhoneNumber");
CREATE INDEX "IX_Interns_ProjectId" ON "Interns" ("ProjectId");
COMMIT;
