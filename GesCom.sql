CREATE DATABASE `Gestion_Commerciale`;

-- Table : users
CREATE TABLE `users` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(50) NOT NULL,
  `password` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ux_users_username` (`username`)
);

-- Table : Clients
CREATE TABLE `Clients` (
  `code_cli` INT NOT NULL AUTO_INCREMENT,
  `nom_cli`  VARCHAR(50) NOT NULL,
  `numRueFact_cli` INT NULL,
  `rueFact_cli` VARCHAR(50) NULL,
  `villeFact_cli` VARCHAR(50) NULL,
  `codePostFact_cli` INT NULL,
  `numRueLivr_cli` INT(50) NULL,
  `rueLivr_cli` VARCHAR(50) NULL,
  `villeLivr_cli` VARCHAR(50) NULL,
  `codePostLivr_cli` INT NULL,
  `numTel_cli` INT NULL,
  `numFax_cli` INT NULL,
  `mail_cli` VARCHAR(50) NULL,
  PRIMARY KEY (`code_cli`),
  KEY `ix_clients_mail` (`mail_cli`)
);

-- Table : Catégorie
CREATE TABLE `Categorie` (
  `code_categ` INT NOT NULL AUTO_INCREMENT,
  `nom_categ` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`code_categ`),
  UNIQUE KEY `ux_categorie_nom` (`nom_categ`)
);

-- Table : Statut
CREATE TABLE `Statut` (
  `code_sta` INT  NOT NULL AUTO_INCREMENT,
  `nom_sta` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`code_sta`),
  UNIQUE KEY `ux_statut_nom` (`nom_sta`)
);

-- Table : Produits
CREATE TABLE `Produits` (
  `code_prod` INT NOT NULL AUTO_INCREMENT,
  `libelle_prod` VARCHAR(50) NOT NULL,
  `prixHT_prod` DECIMAL(10,2) NOT NULL, 
  `code_categ` INT NOT NULL, -- Référence -> Categorie.code_categ
  PRIMARY KEY (`code_prod`),
  KEY `ix_produits_categ` (`code_categ`), 
  CONSTRAINT `fk_produits_categorie`
    FOREIGN KEY (`code_categ`) REFERENCES `Categorie` (`code_categ`)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
);

-- Table : Devis
CREATE TABLE `Devis` (
  `code_dev` INT NOT NULL AUTO_INCREMENT,
  `date_dev` DATE NOT NULL,
  `tauxTVA_dev` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `tauxRemiseGlobal_dev` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `MontantHTHorsRemise_dev` DECIMAL(10,2) NOT NULL DEFAULT 0.00,
  `code_cli` INT NOT NULL, -- Référence -> Clients.code_cli
  `code_sta` INT  NOT NULL, -- Référence -> Statut.code_sta
  PRIMARY KEY (`code_dev`),
  KEY `ix_devis_client` (`code_cli`), 
  KEY `ix_devis_statut` (`code_sta`),
  CONSTRAINT `fk_devis_clients`
    FOREIGN KEY (`code_cli`) REFERENCES `Clients` (`code_cli`)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  CONSTRAINT `fk_devis_statut`
    FOREIGN KEY (`code_sta`) REFERENCES `Statut` (`code_sta`)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  CONSTRAINT `ck_devis_taux`
    CHECK (`tauxTVA_dev` >= 0 AND `tauxRemiseGlobal_dev` >= 0)
);

-- Table : Contenir
CREATE TABLE `Contenir` (
  `code_dev`  INT NOT NULL, -- Référence -> Devis.code_dev
  `code_prod` INT NOT NULL, -- Référence -> Produits.code_prod
  `quantiteProduit` INT NOT NULL,
  `remiseProduit` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`code_dev`, `code_prod`),
  KEY `ix_contenir_prod` (`code_prod`),
  CONSTRAINT `fk_contenir_devis`
    FOREIGN KEY (`code_dev`) REFERENCES `Devis` (`code_dev`)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  CONSTRAINT `fk_contenir_produits`
    FOREIGN KEY (`code_prod`) REFERENCES `Produits` (`code_prod`)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  CONSTRAINT `ck_contenir_quantite`
    CHECK (`quantiteProduit` > 0),
  CONSTRAINT `ck_contenir_remise`
    CHECK (`remiseProduit` >= 0)
);





INSERT INTO `Categorie` (`nom_categ`) VALUES
  ('Informatique'),
  ('Mobilier');

INSERT INTO `Statut` (`nom_sta`) VALUES
  ('Brouillon'),
  ('Validé');

INSERT INTO `Clients`
  (`nom_cli`, `numRueFact_cli`, `rueFact_cli`, `villeFact_cli`, `codePostFact_cli`,
   `numRueLivr_cli`, `rueLivr_cli`, `villeLivr_cli`, `codePostLivr_cli`,
   `numTel_cli`, `numFax_cli`, `mail_cli`)
VALUES
  ('Dupont SA', 12, 'Rue de la Paix', 'Paris', 75002, 12, 'Rue de la Paix', 'Paris', 75002, NULL, NULL, 'contact@dupont-sa.fr'),
  ('Martin & Fils', 8, 'Avenue des Tilleuls', 'Lyon', 69003, 10, 'Avenue des Tilleuls', 'Lyon', 69003, NULL, NULL, 'info@martin-fils.fr');

INSERT INTO `Produits` (`libelle_prod`, `prixHT_prod`, `code_categ`) VALUES
  ('Ordinateur Portable 15"', 799.00, (SELECT `code_categ` FROM `Categorie` WHERE `nom_categ`='Informatique')),
  ('Chaise de Bureau Ergonomique', 119.00, (SELECT `code_categ` FROM `Categorie` WHERE `nom_categ`='Mobilier'));

INSERT INTO `Devis`
  (`date_dev`, `tauxTVA_dev`, `tauxRemiseGlobal_dev`, `MontantHTHorsRemise_dev`, `code_cli`, `code_sta`)
VALUES
  (CURRENT_DATE, 20.00, 5.00, 799.00,
   (SELECT `code_cli` FROM `Clients` WHERE `nom_cli`='Dupont SA'),
   (SELECT `code_sta` FROM `Statut` WHERE `nom_sta`='Brouillon'));

INSERT INTO `Contenir` (`code_dev`, `code_prod`, `quantiteProduit`, `remiseProduit`) VALUES
  ((SELECT `code_dev` FROM `Devis` ORDER BY `code_dev` DESC LIMIT 1),
   (SELECT `code_prod` FROM `Produits` WHERE `libelle_prod`='Ordinateur Portable 15"'),
   1, 0.00);
