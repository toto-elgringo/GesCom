-- Création de la base
CREATE DATABASE Gestion_Commerciale;
GO
USE Gestion_Commerciale;
GO

-- Table : Users
CREATE TABLE [Users] (
    [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [username] VARCHAR(50) NOT NULL UNIQUE,
    [password] VARCHAR(255) NOT NULL
);
GO

-- Table : Clients
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

-- Table : Categorie
CREATE TABLE [Categorie] (
    [code_categ] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [nom_categ] VARCHAR(50) NOT NULL UNIQUE
);
GO

-- Table : Statut
CREATE TABLE [Statut] (
    [code_sta] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [nom_sta] VARCHAR(50) NOT NULL UNIQUE
);
GO

-- Table : Produits
CREATE TABLE [Produits] (
    [code_prod] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [libelle_prod] VARCHAR(50) NOT NULL,
    [prixHT_prod] DECIMAL(10,2) NOT NULL CONSTRAINT df_prixHT_prod DEFAULT 0.00,
    [code_categ] INT NOT NULL,
    CONSTRAINT fk_produits_categorie FOREIGN KEY ([code_categ])
        REFERENCES [Categorie]([code_categ])
);
GO

-- Table : Devis
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

-- Table : Contenir
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

-- Insertion données initiales

-- Users
INSERT INTO [Users] ([username], [password]) VALUES
('Utilisateur1', '$2y$10$jP2Y9o.rGCuy4Qr4/1Ax/u6t67ixs2hyCttH24HaszTkLnKX4RTCK'),
('Utilisateur2', '$2y$10$o5Se2kDG8YwnNPkg241p.eDo9fbOOv4bG.BCySsuyVVhuXyledHc2');

-- Catégories
INSERT INTO [Categorie] ([nom_categ]) VALUES
('Réseau'),
('Consommables'),
('PC'),
('Pièces detachées');
GO

-- Statuts
INSERT INTO [Statut] ([nom_sta]) VALUES
('En attente'),
('Refusé'),
('Accepté');
GO

-- Clients
INSERT INTO [Clients]
([nom_cli], [numRueFact_cli], [rueFact_cli], [villeFact_cli], [codePostFact_cli],
 [numRueLivr_cli], [rueLivr_cli], [villeLivr_cli], [codePostLivr_cli],
 [numTel_cli], [numFax_cli], [mail_cli])
VALUES
('TechnoWorld', 25, 'Boulevard des Nations', 'Marseille', 13008, 25, 'Boulevard des Nations', 'Marseille', 13008, '0611223344', '0411223345', 'contact@technoworld.fr'),
('Alpha Informatique', 42, 'Rue du Commerce', 'Bordeaux', 33000, 42, 'Rue du Commerce', 'Bordeaux', 33000, '0677889900', '0556778899', 'support@alphainfo.fr'),
('Design Office', 5, 'Rue Voltaire', 'Toulouse', 31000, 7, 'Rue Voltaire', 'Toulouse', 31000, '0622334455', '0533445566', 'info@design-office.fr'),
('Bâtitech', 18, 'Avenue Victor Hugo', 'Nice', 06000, 18, 'Avenue Victor Hugo', 'Nice', 06000, '0699887766', '0499887766', 'contact@batitech.fr');
GO


-- Produits
INSERT INTO [Produits] ([libelle_prod], [prixHT_prod], [code_categ])
VALUES
('Routeur Cisco 2800', 450.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Réseau')),
('Switch HP 24 ports', 220.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Réseau')),
('Imprimante LaserJet Pro', 189.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Consommables')),
('Clé USB 64 Go', 19.90, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Consommables')),
('Unité Centrale Intel i5', 550.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='PC')),
('Écran 27" Full HD', 199.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='PC')),
('Carte Mère ASUS B450', 129.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Pièces detachées')),
('Disque SSD 1 To', 89.00, (SELECT [code_categ] FROM [Categorie] WHERE [nom_categ]='Pièces detachées'));
GO


-- Devis
INSERT INTO [Devis] ([date_dev], [tauxTVA_dev], [tauxRemiseGlobal_dev], [MontantHTHorsRemise_dev], [code_cli], [code_sta])
VALUES
-- Devis pour TechnoWorld
('2025-10-01', 20.00, 0.00, 889.00,
 (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='TechnoWorld'),
 (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='En attente')),

-- Devis pour Alpha Informatique
('2025-09-20', 20.00, 5.00, 1578.00,
 (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Alpha Informatique'),
 (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='Accepté')),

-- Devis pour Design Office
('2025-08-15', 20.00, 10.00, 2350.00,
 (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Design Office'),
 (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='Refusé')),

-- Devis pour Bâtitech
('2025-07-01', 20.00, 0.00, 1298.00,
 (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Bâtitech'),
 (SELECT [code_sta] FROM [Statut] WHERE [nom_sta]='En attente'));
GO


-- Contenir : liaisons Devis / Produits
INSERT INTO [Contenir] ([code_dev], [code_prod], [quantiteProduit], [remiseProduit])
VALUES
-- Devis TechnoWorld : 1 routeur + 1 switch
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='TechnoWorld')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Routeur Cisco 2800'), 1, 0.00),
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='TechnoWorld')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Switch HP 24 ports'), 2, 0.00),

-- Devis Alpha Informatique : 2 UC + 2 écrans
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Alpha Informatique')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Unité Centrale Intel i5'), 2, 5.00),
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Alpha Informatique')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Écran 27" Full HD'), 2, 5.00),

-- Devis Design Office : 10 chaises + 2 imprimantes
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Design Office')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Chaise de Bureau Ergonomique'), 10, 10.00),
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Design Office')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Imprimante LaserJet Pro'), 2, 0.00),

-- Devis Bâtitech : 3 SSD + 3 cartes mères
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Bâtitech')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Disque SSD 1 To'), 3, 0.00),
((SELECT [code_dev] FROM [Devis] WHERE [code_cli] = (SELECT [code_cli] FROM [Clients] WHERE [nom_cli]='Bâtitech')),
 (SELECT [code_prod] FROM [Produits] WHERE [libelle_prod]='Carte Mère ASUS B450'), 3, 5.00);
GO


