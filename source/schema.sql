-- MySQL Script generated by MySQL Workbench
-- Sun Jun 16 03:53:21 2019
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema lofy
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `lofy` ;

-- -----------------------------------------------------
-- Schema lofy
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `lofy` DEFAULT CHARACTER SET utf8 ;
USE `lofy` ;

-- -----------------------------------------------------
-- Table `lofy`.`supplierIn_location`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`supplierIn_location` ;

CREATE TABLE IF NOT EXISTS `lofy`.`supplierIn_location` (
  `location_id` INT NOT NULL,
  `company_id` INT NOT NULL,
  PRIMARY KEY (`location_id`, `company_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`companyFor_person`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`companyFor_person` ;

CREATE TABLE IF NOT EXISTS `lofy`.`companyFor_person` (
  `id` INT NOT NULL,
  `person_id` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`, `person_id`),
  CONSTRAINT `fk_companyFor_person_supplierIn_location1`
    FOREIGN KEY (`id`)
    REFERENCES `lofy`.`supplierIn_location` (`company_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`contactFor_person`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`contactFor_person` ;

CREATE TABLE IF NOT EXISTS `lofy`.`contactFor_person` (
  `person_id` INT NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `phone` VARCHAR(45) NULL,
  PRIMARY KEY (`person_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`person`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`person` ;

CREATE TABLE IF NOT EXISTS `lofy`.`person` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_person_companyFor_person`
    FOREIGN KEY (`id`)
    REFERENCES `lofy`.`companyFor_person` (`person_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_person_contactFor_person1`
    FOREIGN KEY (`id`)
    REFERENCES `lofy`.`contactFor_person` (`person_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`recipientIn_location`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`recipientIn_location` ;

CREATE TABLE IF NOT EXISTS `lofy`.`recipientIn_location` (
  `location_id` INT NOT NULL,
  `company_id` INT NOT NULL,
  PRIMARY KEY (`location_id`, `company_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`stockFor_productIn_location`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`stockFor_productIn_location` ;

CREATE TABLE IF NOT EXISTS `lofy`.`stockFor_productIn_location` (
  `product_id` INT NOT NULL,
  `location_id` INT NOT NULL,
  `count` INT NOT NULL,
  `price` DOUBLE NOT NULL,
  PRIMARY KEY (`product_id`, `location_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`location`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`location` ;

CREATE TABLE IF NOT EXISTS `lofy`.`location` (
  `id` INT NOT NULL,
  `latitude` DOUBLE NOT NULL,
  `longitude` DOUBLE NOT NULL,
  `address` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_location_supplierIn_location1`
    FOREIGN KEY (`id`)
    REFERENCES `lofy`.`supplierIn_location` (`location_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_location_recipientIn_location1`
    FOREIGN KEY (`id`)
    REFERENCES `lofy`.`recipientIn_location` (`location_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_location_stockFor_productIn_location1`
    FOREIGN KEY (`id`)
    REFERENCES `lofy`.`stockFor_productIn_location` (`location_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`product`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`product` ;

CREATE TABLE IF NOT EXISTS `lofy`.`product` (
  `id` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `manufacturer` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_product_stockFor_productIn_location1`
    FOREIGN KEY (`id`)
    REFERENCES `lofy`.`stockFor_productIn_location` (`product_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lofy`.`linkIn_System`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`linkIn_System` ;

CREATE TABLE IF NOT EXISTS `lofy`.`linkIn_System` (
)
ENGINE = InnoDB;

USE `lofy` ;

-- -----------------------------------------------------
-- Placeholder table for view `lofy`.`company`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lofy`.`company` (`id` INT, `person_id` INT, `name` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lofy`.`link`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lofy`.`link` (`id` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lofy`.`stock`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lofy`.`stock` (`product_id` INT, `location_id` INT, `count` INT, `price` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lofy`.`contact`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lofy`.`contact` (`person_id` INT, `email` INT, `phone` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lofy`.`recipient`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lofy`.`recipient` (`location_id` INT, `company_id` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lofy`.`supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lofy`.`supplier` (`location_id` INT, `company_id` INT);

-- -----------------------------------------------------
-- View `lofy`.`company`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`company`;
DROP VIEW IF EXISTS `lofy`.`company` ;
USE `lofy`;
CREATE  OR REPLACE VIEW `company` AS
select * from companyFor_person;

-- -----------------------------------------------------
-- View `lofy`.`link`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`link`;
DROP VIEW IF EXISTS `lofy`.`link` ;
USE `lofy`;
CREATE  OR REPLACE VIEW `link` AS
select * from linkIn_System;

-- -----------------------------------------------------
-- View `lofy`.`stock`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`stock`;
DROP VIEW IF EXISTS `lofy`.`stock` ;
USE `lofy`;
CREATE  OR REPLACE VIEW `stock` AS
select * from stockFor_productIn_location;

-- -----------------------------------------------------
-- View `lofy`.`contact`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`contact`;
DROP VIEW IF EXISTS `lofy`.`contact` ;
USE `lofy`;
CREATE  OR REPLACE VIEW `contact` AS
select * from contactFor_person;

-- -----------------------------------------------------
-- View `lofy`.`recipient`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`recipient`;
DROP VIEW IF EXISTS `lofy`.`recipient` ;
USE `lofy`;
CREATE  OR REPLACE VIEW `recipient` AS
select * from recipientIn_location;

-- -----------------------------------------------------
-- View `lofy`.`supplier`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lofy`.`supplier`;
DROP VIEW IF EXISTS `lofy`.`supplier` ;
USE `lofy`;
CREATE  OR REPLACE VIEW `supplier` AS
select * from supplierIn_location;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
