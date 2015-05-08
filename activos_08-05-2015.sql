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
  `codigo` char(8) NOT NULL COMMENT 'codigo activo',
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(220) NOT NULL COMMENT 'Descripcion Detallada',
  `marca` varchar(20) NOT NULL DEFAULT '',
  `modelo` varchar(10) NOT NULL DEFAULT '',
  `numSerie` varchar(30) NOT NULL COMMENT 'Numero de Serie',
  `referencia` varchar(20) NOT NULL,
  `propiedad` enum('PROPIO','ARRENDADO','LEASING') NOT NULL,
  `fechaCompra` date NOT NULL COMMENT 'Fecha Adquisicion',
  `nFactura` varchar(20) NOT NULL DEFAULT '',
  `areaLoc` varchar(4) NOT NULL,
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
  `fechamaxDep` date NOT NULL,
  `mantenimiento` enum('SI','NO') NOT NULL DEFAULT 'NO',
  `poliza` enum('SI','NO') NOT NULL DEFAULT 'NO',
  PRIMARY KEY (`codigo`),
  KEY `idx_responsable` (`responsable`),
  KEY `FK_subgrupo_act` (`subgrupo`),
  KEY `FK_grupo_act` (`grupo`),
  KEY `FK_area_activos` (`areaLoc`),
  CONSTRAINT `FK_area_activos` FOREIGN KEY (`areaLoc`) REFERENCES `afarea` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_grupo_act` FOREIGN KEY (`grupo`) REFERENCES `afgrupo` (`sigla`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_subgrupo_act` FOREIGN KEY (`subgrupo`) REFERENCES `afsubgrupo` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `afarea` */

DROP TABLE IF EXISTS `afarea`;

CREATE TABLE `afarea` (
  `codigo` varchar(4) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `responsable` varchar(15) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `idx_area_resp` (`responsable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `afdepreciacion` */

DROP TABLE IF EXISTS `afdepreciacion`;

CREATE TABLE `afdepreciacion` (
  `idDepreciacion` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `documento` varchar(15) NOT NULL,
  `codigo` char(8) NOT NULL,
  `periodo` varchar(7) NOT NULL,
  `valLibros` double(20,2) NOT NULL COMMENT 'ValorDepreciado',
  `depreciacion` double(20,2) NOT NULL COMMENT 'valor Depreciacion',
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `depAcumulada` double(20,2) NOT NULL,
  PRIMARY KEY (`idDepreciacion`),
  KEY `idx_periodo` (`periodo`),
  KEY `FK_act_dep` (`codigo`),
  CONSTRAINT `FK_act_dep` FOREIGN KEY (`codigo`) REFERENCES `afactivos` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

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

/*Table structure for table `afmantenimiento` */

DROP TABLE IF EXISTS `afmantenimiento`;

CREATE TABLE `afmantenimiento` (
  `idMto` smallint(6) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `codActivo` char(8) NOT NULL,
  `nContrato` varchar(15) NOT NULL,
  `fInicio` date NOT NULL,
  `fVence` date NOT NULL,
  `nVisitas` tinyint(3) NOT NULL,
  `proveedor` varchar(15) NOT NULL,
  `valor` double(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`idMto`),
  KEY `FK_act_mant` (`codActivo`),
  KEY `idx_Contrato` (`nContrato`),
  CONSTRAINT `FK_act_mant` FOREIGN KEY (`codActivo`) REFERENCES `afactivos` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Table structure for table `afmovimientos` */

DROP TABLE IF EXISTS `afmovimientos`;

CREATE TABLE `afmovimientos` (
  `idMovimiento` smallint(6) unsigned NOT NULL AUTO_INCREMENT,
  `documento` varchar(15) NOT NULL,
  `tipodoc` char(2) NOT NULL,
  `periodo` char(7) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `tipoMov` varchar(20) NOT NULL,
  `descripcion` varchar(60) NOT NULL,
  `codActivo` char(8) NOT NULL DEFAULT '0',
  `valTotal` double(20,2) NOT NULL,
  `estado` char(2) NOT NULL,
  `ccosto` varchar(15) NOT NULL DEFAULT '0',
  `nitc` varchar(15) NOT NULL DEFAULT '',
  PRIMARY KEY (`idMovimiento`),
  KEY `idx_tipo` (`tipodoc`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Table structure for table `afparametros` */

DROP TABLE IF EXISTS `afparametros`;

CREATE TABLE `afparametros` (
  `codigo` tinyint(2) unsigned NOT NULL AUTO_INCREMENT,
  `ctaCaja` varchar(12) NOT NULL DEFAULT '',
  `ctaIVA` varchar(12) NOT NULL DEFAULT '',
  `ctaBanco` char(9) NOT NULL DEFAULT '',
  `ctaProveedor` char(9) NOT NULL DEFAULT '',
  `ctadepreMon` varchar(12) NOT NULL DEFAULT '',
  `ventas` varchar(3) NOT NULL,
  `compras` varchar(3) NOT NULL,
  `depreciacion` varchar(3) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `afpolizas` */

DROP TABLE IF EXISTS `afpolizas`;

CREATE TABLE `afpolizas` (
  `idPoliza` smallint(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `codActivo` char(8) NOT NULL,
  `nPoliza` varchar(15) NOT NULL,
  `empresa` varchar(15) NOT NULL,
  `fechaInicio` date NOT NULL,
  `fechaVence` date NOT NULL,
  `responsable` varchar(45) NOT NULL DEFAULT '',
  `telefono` varchar(12) NOT NULL DEFAULT '0',
  `deducible` double(20,2) NOT NULL,
  `valor` double(20,2) NOT NULL,
  PRIMARY KEY (`idPoliza`),
  KEY `FK_act_pol` (`codActivo`),
  KEY `idx_nPoliza` (`nPoliza`),
  CONSTRAINT `FK_act_pol` FOREIGN KEY (`codActivo`) REFERENCES `afactivos` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

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
  `codActivo` char(8) NOT NULL,
  `areaAnt` varchar(4) DEFAULT NULL,
  `responAnt` varchar(20) DEFAULT NULL,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `nuevaArea` varchar(4) DEFAULT NULL,
  `NuevoResp` varchar(20) DEFAULT NULL,
  `observacion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idTraslado`),
  KEY `FK_area_tras` (`nuevaArea`),
  KEY `FK_act_tras` (`codActivo`),
  CONSTRAINT `FK_act_tras` FOREIGN KEY (`codActivo`) REFERENCES `afactivos` (`codigo`),
  CONSTRAINT `FK_area_tras` FOREIGN KEY (`nuevaArea`) REFERENCES `afarea` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
