------------------------------------------------------------
-- CREATION BASE DE DONNEES
------------------------------------------------------------
CREATE DATABASE Gestion_Commerciale;
GO
USE Gestion_Commerciale;
GO

------------------------------------------------------------
-- TABLE : Users
------------------------------------------------------------
CREATE TABLE [Users] (
    [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [username] VARCHAR(50) NOT NULL UNIQUE,
    [password] VARCHAR(255) NOT NULL
);
GO

------------------------------------------------------------
-- TABLE : Clients
------------------------------------------------------------
CREATE TABLE [Clients] (
    [code_cli] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [nom_cli] VARCHAR(50) NOT NULL,
    [numRueFact_cli] INT NOT NULL,
    [rueFact_cli] VARCHAR(50) NOT NULL,
    [villeFact_cli] VARCHAR(50) NOT NULL,
    [codePostFact_cli] INT NOT NULL,
    [numRueLivr_cli] INT NOT NULL,
    [rueLivr_cli] VARCHAR(50) NOT NULL,
    [villeLivr_cli] VARCHAR(50) NOT NULL,
    [codePostLivr_cli] INT NOT NULL,
    [numTel_cli] VARCHAR(20) NOT NULL,
    [numFax_cli] VARCHAR(20) NOT NULL,
    [mail_cli] VARCHAR(50) NULL
);
GO

------------------------------------------------------------
-- TABLE : Categorie
------------------------------------------------------------
CREATE TABLE [Categorie] (
    [code_categ] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [nom_categ] VARCHAR(50) NOT NULL UNIQUE
);
GO

------------------------------------------------------------
-- TABLE : Statut
------------------------------------------------------------
CREATE TABLE [Statut] (
    [code_sta] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [nom_sta] VARCHAR(50) NOT NULL UNIQUE
);
GO

------------------------------------------------------------
-- TABLE : Produits
------------------------------------------------------------
CREATE TABLE [Produits] (
    [code_prod] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [libelle_prod] VARCHAR(100) NOT NULL,
    [prixHT_prod] DECIMAL(10,2) NOT NULL CONSTRAINT df_prixHT_prod DEFAULT 0.00,
    [code_categ] INT NOT NULL,
    CONSTRAINT fk_produits_categorie FOREIGN KEY ([code_categ])
        REFERENCES [Categorie]([code_categ])
);
GO

------------------------------------------------------------
-- TABLE : Devis
------------------------------------------------------------
CREATE TABLE [Devis] (
    [code_dev] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [date_dev] DATE NOT NULL,
    [tauxTVA_dev] DECIMAL(5,2) NOT NULL CONSTRAINT df_tauxTVA DEFAULT 0.00,
    [tauxRemiseGlobal_dev] DECIMAL(5,2) NOT NULL CONSTRAINT df_tauxRemise DEFAULT 0.00,
    [MontantHTHorsRemise_dev] DECIMAL(10,2) NOT NULL CONSTRAINT df_MontantHT DEFAULT 0.00,
    [code_cli] INT NOT NULL,
    [code_sta] INT NOT NULL,
    CONSTRAINT fk_devis_clients FOREIGN KEY ([code_cli])
        REFERENCES [Clients]([code_cli]),
    CONSTRAINT fk_devis_statut FOREIGN KEY ([code_sta])
        REFERENCES [Statut]([code_sta]),
    CONSTRAINT ck_devis_taux CHECK ([tauxTVA_dev] >= 0 AND [tauxRemiseGlobal_dev] >= 0)
);
GO

------------------------------------------------------------
-- TABLE : Contenir
------------------------------------------------------------
CREATE TABLE [Contenir] (
    [code_dev] INT NOT NULL,
    [code_prod] INT NOT NULL,
    [quantiteProduit] INT NOT NULL,
    [remiseProduit] DECIMAL(5,2) NOT NULL CONSTRAINT df_remise DEFAULT 0.00,
    PRIMARY KEY ([code_dev], [code_prod]),
    CONSTRAINT fk_contenir_devis FOREIGN KEY ([code_dev])
        REFERENCES [Devis]([code_dev])
        ON DELETE CASCADE,
    CONSTRAINT fk_contenir_produits FOREIGN KEY ([code_prod])
        REFERENCES [Produits]([code_prod]),
    CONSTRAINT ck_contenir_quantite CHECK ([quantiteProduit] > 0),
    CONSTRAINT ck_contenir_remise CHECK ([remiseProduit] >= 0)
);
GO

------------------------------------------------------------
-- INSERTIONS INITIALES
------------------------------------------------------------

-- Users
INSERT INTO [Users] ([username], [password]) VALUES
('Utilisateur1', '$2y$10$jP2Y9o.rGCuy4Qr4/1Ax/u6t67ixs2hyCttH24HaszTkLnKX4RTCK'),
('Utilisateur2', '$2y$10$o5Se2kDG8YwnNPkg241p.eDo9fbOOv4bG.BCySsuyVVhuXyledHc2');
GO

-- Categories
INSERT INTO [Categorie] ([nom_categ]) VALUES
('Reseau'),
('Consommables'),
('PC'),
('Pieces detachees');
GO

-- Statuts
INSERT INTO [Statut] ([nom_sta]) VALUES
('En attente'),
('Refuse'),
('Accepte');
GO

-- Clients
INSERT INTO [Clients]
([nom_cli], [numRueFact_cli], [rueFact_cli], [villeFact_cli], [codePostFact_cli],
 [numRueLivr_cli], [rueLivr_cli], [villeLivr_cli], [codePostLivr_cli],
 [numTel_cli], [numFax_cli], [mail_cli])
VALUES
('Dupont SA', 12, 'Rue de la Paix', 'Paris', 75002, 12, 'Rue de la Paix', 'Paris', 75002, '0678969034', '0678969034', 'contact@dupont-sa.fr'),
('Martin et Fils', 8, 'Avenue des Tilleuls', 'Lyon', 69003, 10, 'Avenue des Tilleuls', 'Lyon', 69003, '0734557899', '0734557899', 'info@martin-fils.fr'),
('TechnoWorld', 25, 'Boulevard des Sciences', 'Toulouse', 31000, 25, 'Boulevard des Sciences', 'Toulouse', 31000, '0612345678', '0612345678', 'contact@technoworld.fr'),
('Alpha Informatique', 45, 'Rue Voltaire', 'Marseille', 13006, 45, 'Rue Voltaire', 'Marseille', 13006, '0623456789', '0623456789', 'info@alphainfo.fr'),
('Design Office', 3, 'Rue des Artisans', 'Nantes', 44000, 3, 'Rue des Artisans', 'Nantes', 44000, '0634567890', '0634567890', 'contact@designoffice.fr'),
('Batitech', 18, 'Rue du Batiment', 'Lille', 59000, 18, 'Rue du Batiment', 'Lille', 59000, '0645678901', '0645678901', 'contact@batitech.fr');
GO

-- Produits
INSERT INTO [Produits] ([libelle_prod], [prixHT_prod], [code_categ])
VALUES
('Ordinateur Portable 15 pouces', 799.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='PC')),
('Chaise de Bureau Ergonomique', 119.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Pieces detachees')),
('Routeur Cisco 2800', 350.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Reseau')),
('Switch HP 24 ports', 420.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Reseau')),
('Unite Centrale Intel i5', 600.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='PC')),
('Ecran 27 pouces Full HD', 230.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='PC')),
('Imprimante LaserJet Pro', 280.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Consommables')),
('Disque SSD 1 To', 150.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Pieces detachees')),
('Carte Mere ASUS B450', 120.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Pieces detachees'));
GO

-- Devis
INSERT INTO [Devis] ([date_dev], [tauxTVA_dev], [tauxRemiseGlobal_dev], [MontantHTHorsRemise_dev], [code_cli], [code_sta])
VALUES
(CAST(GETDATE() AS DATE), 20.00, 5.00, 799.00, (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Dupont SA'), (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='En attente')),
(CAST(GETDATE() AS DATE), 20.00, 0.00, 1570.00, (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='TechnoWorld'), (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='En attente')),
(CAST(GETDATE() AS DATE), 20.00, 10.00, 1660.00, (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Alpha Informatique'), (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='En attente')),
(CAST(GETDATE() AS DATE), 20.00, 5.00, 1990.00, (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Design Office'), (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='Accepte')),
(CAST(GETDATE() AS DATE), 20.00, 0.00, 810.00, (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Batitech'), (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='Refuse'));
GO

-- Contenir (liaisons Devis / Produits)
INSERT INTO [Contenir] ([code_dev], [code_prod], [quantiteProduit], [remiseProduit])
SELECT D.code_dev, P.code_prod, 1, 0.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Routeur Cisco 2800'
WHERE C.nom_cli = 'TechnoWorld';

INSERT INTO [Contenir]
SELECT D.code_dev, P.code_prod, 2, 0.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Switch HP 24 ports'
WHERE C.nom_cli = 'TechnoWorld';

INSERT INTO [Contenir]
SELECT D.code_dev, P.code_prod, 2, 5.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Unite Centrale Intel i5'
WHERE C.nom_cli = 'Alpha Informatique';

INSERT INTO [Contenir]
SELECT D.code_dev, P.code_prod, 2, 5.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Ecran 27 pouces Full HD'
WHERE C.nom_cli = 'Alpha Informatique';

INSERT INTO [Contenir]
SELECT D.code_dev, P.code_prod, 10, 10.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Chaise de Bureau Ergonomique'
WHERE C.nom_cli = 'Design Office';

INSERT INTO [Contenir]
SELECT D.code_dev, P.code_prod, 2, 0.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Imprimante LaserJet Pro'
WHERE C.nom_cli = 'Design Office';

INSERT INTO [Contenir]
SELECT D.code_dev, P.code_prod, 3, 0.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Disque SSD 1 To'
WHERE C.nom_cli = 'Batitech';

INSERT INTO [Contenir]
SELECT D.code_dev, P.code_prod, 3, 5.00
FROM Devis D
JOIN Clients C ON D.code_cli = C.code_cli
JOIN Produits P ON P.libelle_prod = 'Carte Mere ASUS B450'
WHERE C.nom_cli = 'Batitech';
GO
