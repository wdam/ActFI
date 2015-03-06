/*
SQLyog Ultimate v9.63 
MySQL - 5.6.16 : Database - saesys2013
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`saesys2013` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `saesys2013`;

/*Table structure for table `afactivos` */

DROP TABLE IF EXISTS `afactivos`;

CREATE TABLE `afactivos` (
  `codigo` varchar(10) NOT NULL COMMENT 'codigo activo',
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(200) NOT NULL COMMENT 'Descripcion Detallada',
  `marca` varchar(20) DEFAULT NULL,
  `modelo` varchar(10) DEFAULT NULL,
  `numSerie` varchar(30) NOT NULL COMMENT 'Numero de Serie',
  `referecia` varchar(20) NOT NULL,
  `propiedad` enum('PROPIO','ARRENDADO','LEASING') NOT NULL,
  `fechaCompra` varchar(10) NOT NULL DEFAULT '00/00/0000' COMMENT 'Fecha Adquisicion',
  `AreaLoc` varchar(4) NOT NULL,
  `responsable` varchar(20) NOT NULL,
  `proveedor` varchar(20) NOT NULL,
  `ccosto` varchar(10) NOT NULL DEFAULT '0',
  `estado` varchar(20) NOT NULL,
  `valComercial` double(20,2) NOT NULL COMMENT 'Valor Comercial',
  `valSalvamento` double(20,2) NOT NULL COMMENT 'Valor Salvamento',
  `valLibros` double(20,2) NOT NULL COMMENT 'Valor Libros',
  `valMejoras` double(20,2) NOT NULL COMMENT 'Valor Mejoras',
  `valHistorico` double(20,2) NOT NULL COMMENT 'Valor Historico',
  `depajustada` double(20,2) NOT NULL COMMENT 'Depreciacion ajustada',
  `depAcumulada` double(20,2) NOT NULL COMMENT 'Depreciacion Acumulada',
  `grupo` char(4) NOT NULL,
  `subgrupo` char(5) NOT NULL,
  `metodoDep` char(3) NOT NULL,
  `vidaUtil` smallint(4) unsigned NOT NULL COMMENT 'Vida Util',
  `ctaActivo` char(9) NOT NULL COMMENT 'Cuenta Activo',
  `ctadepreciacion` char(9) NOT NULL COMMENT 'Cuenta Depreciacion',
  `ctagastos` char(9) NOT NULL COMMENT 'Cuenta Gastos',
  `ctaPerdida` char(9) NOT NULL,
  `ctaGanancia` char(9) NOT NULL,
  `ctaMantenimiento` char(9) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `FK_area_activos` (`AreaLoc`),
  KEY `idx_responsable` (`responsable`),
  KEY `FK_subgrupo_act` (`subgrupo`),
  KEY `FK_grupo_act` (`grupo`),
  CONSTRAINT `FK_area_activos` FOREIGN KEY (`AreaLoc`) REFERENCES `afarea` (`codigo`),
  CONSTRAINT `FK_grupo_act` FOREIGN KEY (`grupo`) REFERENCES `afgrupo` (`sigla`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_subgrupo_act` FOREIGN KEY (`subgrupo`) REFERENCES `afsubgrupo` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `afarea` */

DROP TABLE IF EXISTS `afarea`;

CREATE TABLE `afarea` (
  `codigo` varchar(4) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(200) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `afdepreciacion` */

DROP TABLE IF EXISTS `afdepreciacion`;

CREATE TABLE `afdepreciacion` (
  `idDepreciacion` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `documento` varchar(15) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `periodo` varchar(2) NOT NULL,
  `valorDep` double(20,2) NOT NULL COMMENT 'ValorDepreciado',
  `depreciacion` double(20,2) NOT NULL COMMENT 'valor Depreciacion',
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idDepreciacion`),
  KEY `idx_periodo` (`periodo`),
  KEY `FK_activo_depre` (`codigo`),
  CONSTRAINT `FK_activo_depre` FOREIGN KEY (`codigo`) REFERENCES `afactivos` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

/*Table structure for table `afgrupo` */

DROP TABLE IF EXISTS `afgrupo`;

CREATE TABLE `afgrupo` (
  `sigla` char(4) NOT NULL,
  `descripcion` varchar(120) NOT NULL,
  `metodoDep` char(3) NOT NULL,
  `valSalvamento` tinyint(3) unsigned NOT NULL,
  `vidaUtil` smallint(4) unsigned NOT NULL,
  `ctaActivo` char(9) NOT NULL,
  `ctaDepreciacion` char(9) NOT NULL,
  `ctaGastos` char(9) NOT NULL,
  `ctaPerdida` char(9) NOT NULL,
  `ctaGanancia` char(9) NOT NULL,
  `ctaRevalorizar` char(9) NOT NULL,
  `ctaMantenimiento` char(9) NOT NULL,
  `ctaCorreccion` char(9) NOT NULL,
  `estado` enum('ACTIVO','INACTIVO') NOT NULL,
  `consecutivo` smallint(5) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`sigla`),
  UNIQUE KEY `idx_SIgla_AFG` (`sigla`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `afparametros` */

DROP TABLE IF EXISTS `afparametros`;

CREATE TABLE `afparametros` (
  `codigo` varchar(2) NOT NULL,
  `ctaActivo` varchar(12) DEFAULT NULL,
  `ctadepreciacion` varchar(12) DEFAULT NULL,
  `ctagastos` varchar(12) DEFAULT NULL,
  `ctamonetaria` varchar(12) DEFAULT NULL,
  `ctadepreMon` varchar(12) DEFAULT NULL,
  `ventas` varchar(3) NOT NULL,
  `compras` varchar(3) NOT NULL,
  `depreciacion` varchar(3) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `afsubgrupo` */

DROP TABLE IF EXISTS `afsubgrupo`;

CREATE TABLE `afsubgrupo` (
  `codigo` char(5) NOT NULL,
  `descripcion` varchar(120) NOT NULL,
  `estado` enum('ACTIVO','INACTIVO') NOT NULL,
  `grupo` char(4) NOT NULL,
  `consecutivo` smallint(5) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `FK_grupo_sub` (`grupo`),
  CONSTRAINT `FK_grupo_sub` FOREIGN KEY (`grupo`) REFERENCES `afgrupo` (`sigla`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `aftraslados` */

DROP TABLE IF EXISTS `aftraslados`;

CREATE TABLE `aftraslados` (
  `idTraslado` smallint(6) unsigned NOT NULL AUTO_INCREMENT,
  `codActivo` varchar(10) NOT NULL,
  `areaAnt` varchar(4) DEFAULT NULL,
  `responAnt` varchar(20) DEFAULT NULL,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `nuevaArea` varchar(4) DEFAULT NULL,
  `NuevoResp` varchar(20) DEFAULT NULL,
  `observacion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idTraslado`),
  KEY `FK_area_tras` (`nuevaArea`),
  KEY `FK_act_Traslado` (`codActivo`),
  CONSTRAINT `FK_act_Traslado` FOREIGN KEY (`codActivo`) REFERENCES `afactivos` (`codigo`),
  CONSTRAINT `FK_area_tras` FOREIGN KEY (`nuevaArea`) REFERENCES `afarea` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
