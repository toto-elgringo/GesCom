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
