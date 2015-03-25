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
  `referecia` varchar(20) NOT NULL,
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
  `ctaActivo` varchar(12) NOT NULL DEFAULT '',
  `ctadepreciacion` varchar(12) NOT NULL DEFAULT '',
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `ant_a_prov` */

DROP TABLE IF EXISTS `ant_a_prov`;

CREATE TABLE `ant_a_prov` (
  `per_doc` varchar(25) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `per` varchar(7) NOT NULL,
  `fecha` date NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `monto` double NOT NULL,
  `causado` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `user` varchar(30) NOT NULL,
  `fechacrea` datetime NOT NULL,
  `concepto` varchar(100) NOT NULL,
  PRIMARY KEY (`per_doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ant_de_clie` */

DROP TABLE IF EXISTS `ant_de_clie`;

CREATE TABLE `ant_de_clie` (
  `per_doc` varchar(25) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `per` varchar(7) NOT NULL,
  `fecha` date NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `monto` double NOT NULL,
  `causado` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `user` varchar(30) NOT NULL,
  `fechacrea` datetime NOT NULL,
  `concepto` varchar(100) NOT NULL,
  PRIMARY KEY (`per_doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `articulos` */

DROP TABLE IF EXISTS `articulos`;

CREATE TABLE `articulos` (
  `codart` varchar(18) NOT NULL,
  `nomart` varchar(60) NOT NULL,
  `desart` text NOT NULL,
  `nivel` varchar(15) NOT NULL,
  `referencia` varchar(18) NOT NULL,
  `codbar` varchar(20) NOT NULL,
  `cos_uni` double NOT NULL,
  `cos_pro` double NOT NULL,
  `margen` decimal(10,2) NOT NULL,
  `precio` double NOT NULL,
  `iva` decimal(10,2) NOT NULL,
  `exento` varchar(2) NOT NULL,
  `excluido` varchar(2) NOT NULL,
  `cue_inv` varchar(15) NOT NULL,
  `cue_ing` varchar(15) NOT NULL,
  `cue_cos` varchar(15) NOT NULL,
  `cue_iva_v` varchar(15) NOT NULL,
  `cue_iva_c` varchar(15) NOT NULL,
  `cue_dev` varchar(15) NOT NULL,
  `unidad` varchar(10) NOT NULL,
  `empaque` double NOT NULL,
  `can_emp` double NOT NULL,
  `uni_emp` double NOT NULL,
  `cant_min` double NOT NULL,
  `pp` double NOT NULL,
  `estado` varchar(10) NOT NULL,
  `con_comi` varchar(20) NOT NULL,
  `importa` varchar(2) NOT NULL,
  `num_reg` varchar(20) NOT NULL,
  `por_ara` decimal(10,2) NOT NULL,
  `pos_ara` varchar(20) NOT NULL,
  `p1` varchar(15) NOT NULL,
  `p2` varchar(15) NOT NULL,
  `p3` varchar(15) NOT NULL,
  `p4` varchar(15) NOT NULL,
  `p5` varchar(15) NOT NULL,
  `serie` char(2) NOT NULL DEFAULT 'NO',
  PRIMARY KEY (`codart`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `aud_otdoc` */

DROP TABLE IF EXISTS `aud_otdoc`;

CREATE TABLE `aud_otdoc` (
  `tip_puc` varchar(15) NOT NULL DEFAULT 'comercial',
  `c1_caj` varchar(15) NOT NULL,
  `c2_ban` varchar(15) NOT NULL,
  `c3_cxc` varchar(15) NOT NULL,
  `c4_cxp` varchar(15) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `audi_parcom` */

DROP TABLE IF EXISTS `audi_parcom`;

CREATE TABLE `audi_parcom` (
  `tip_puc` varchar(15) NOT NULL DEFAULT 'comercial',
  `c1_caj` varchar(15) NOT NULL,
  `c2_ban` varchar(15) NOT NULL,
  `c3_cxp` varchar(15) NOT NULL,
  `c4_gas` varchar(15) NOT NULL,
  `c5_com` varchar(15) NOT NULL,
  `c6_des` varchar(15) NOT NULL,
  `c7_inv` varchar(15) NOT NULL,
  `c8_ivap` varchar(15) NOT NULL,
  `c9_ivad` varchar(15) NOT NULL,
  `c10_rtf` varchar(15) NOT NULL,
  `c11_fle` varchar(15) NOT NULL,
  `c12_seg` varchar(15) NOT NULL,
  `c13_pc` varchar(15) NOT NULL,
  `c14_pd` varchar(15) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `audi_parfac` */

DROP TABLE IF EXISTS `audi_parfac`;

CREATE TABLE `audi_parfac` (
  `tip_puc` varchar(15) NOT NULL DEFAULT 'comercial',
  `c1_caj` varchar(15) NOT NULL,
  `c2_ban` varchar(15) NOT NULL,
  `c3_cxc` varchar(15) NOT NULL,
  `c4_inv` varchar(15) NOT NULL,
  `c5_ven` varchar(15) NOT NULL,
  `c6_cven` varchar(15) NOT NULL,
  `c7_ivap` varchar(15) NOT NULL,
  `c8_ivad` varchar(15) NOT NULL,
  `c9_des` varchar(15) NOT NULL,
  `c10_rtf` varchar(15) NOT NULL,
  `c11_rtic` varchar(15) NOT NULL,
  `c12_rtiv` varchar(15) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `auditoria` */

DROP TABLE IF EXISTS `auditoria`;

CREATE TABLE `auditoria` (
  `formulario` text NOT NULL,
  `usuario` varchar(30) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `tip_cuenta` varchar(30) NOT NULL,
  `cuenta_err` varchar(15) NOT NULL,
  `doc_alt` varchar(20) NOT NULL COMMENT 'documento alterado',
  `fec_aud` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `bancos` */

DROP TABLE IF EXISTS `bancos`;

CREATE TABLE `bancos` (
  `cod_ban` varchar(10) NOT NULL,
  `codigo` varchar(15) NOT NULL,
  `banco` varchar(200) NOT NULL,
  `num_cta` varchar(30) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `nit` varchar(15) NOT NULL,
  PRIMARY KEY (`cod_ban`),
  UNIQUE KEY `codigo` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `bitacora` */

DROP TABLE IF EXISTS `bitacora`;

CREATE TABLE `bitacora` (
  `idevento` int(50) NOT NULL AUTO_INCREMENT,
  `evento` varchar(50) NOT NULL,
  `usuario` varchar(50) NOT NULL,
  `fecha` varchar(50) NOT NULL,
  `ip` varchar(20) NOT NULL,
  PRIMARY KEY (`idevento`)
) ENGINE=InnoDB AUTO_INCREMENT=126 DEFAULT CHARSET=latin1;

/*Table structure for table `bloq_per` */

DROP TABLE IF EXISTS `bloq_per`;

CREATE TABLE `bloq_per` (
  `periodo` varchar(2) NOT NULL DEFAULT '00',
  `bloqueado` char(2) NOT NULL DEFAULT 'n',
  PRIMARY KEY (`periodo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `bodegas` */

DROP TABLE IF EXISTS `bodegas`;

CREATE TABLE `bodegas` (
  `numbod` int(11) NOT NULL AUTO_INCREMENT,
  `nombod` varchar(70) NOT NULL,
  PRIMARY KEY (`numbod`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Table structure for table `calif_razones` */

DROP TABLE IF EXISTS `calif_razones`;

CREATE TABLE `calif_razones` (
  `id_razon` int(11) NOT NULL,
  `valor` double NOT NULL,
  `prom_razon` double NOT NULL,
  `desv_razon` double NOT NULL,
  `calif_razon` int(11) NOT NULL,
  PRIMARY KEY (`id_razon`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `car_par` */

DROP TABLE IF EXISTS `car_par`;

CREATE TABLE `car_par` (
  `par_fac1` varchar(2) NOT NULL,
  `par_fac2` varchar(2) NOT NULL,
  `par_fac3` varchar(2) NOT NULL,
  `par_fac4` varchar(2) NOT NULL,
  `par_aju` varchar(2) NOT NULL,
  `par_rc` varchar(2) NOT NULL,
  `par_ci` varchar(2) NOT NULL,
  `par_posf` varchar(2) NOT NULL,
  `par_int` varchar(2) NOT NULL,
  `par_cta_caja` varchar(12) NOT NULL,
  `par_cta_ban` varchar(12) NOT NULL,
  `par_cta_ret` varchar(12) NOT NULL,
  `par_cta_des` varchar(12) NOT NULL,
  `par_cta_iva` varchar(12) NOT NULL,
  `par_cta_ven` varchar(12) NOT NULL,
  `par_cta_pos` varchar(12) NOT NULL,
  `par_cta_cco` varchar(12) NOT NULL,
  `par_sal_ini` date NOT NULL,
  `par_blq_cup` varchar(2) NOT NULL,
  `par_dia_ven` varchar(2) NOT NULL,
  `par_blq_mor` varchar(2) NOT NULL,
  `par_blq_exc` varchar(2) NOT NULL,
  `par_rcb_apr` varchar(2) NOT NULL,
  `par_nro_rec` varchar(2) NOT NULL,
  `par_pag_com` varchar(2) NOT NULL,
  `par_com_var` varchar(2) NOT NULL,
  `par_env_cor` varchar(2) NOT NULL,
  `hay_int` varchar(2) NOT NULL DEFAULT 'NO' COMMENT '¿se cobran intereses moratorios?',
  `mon_int` decimal(10,6) NOT NULL DEFAULT '0.000000' COMMENT 'monto del interes moratorio',
  `tip_int` varchar(10) NOT NULL DEFAULT 'diario' COMMENT 'tipo de interes moratorio',
  `cta_mor` varchar(18) NOT NULL COMMENT 'cta intereses moratorios',
  `concomi` varchar(2) NOT NULL DEFAULT 'NO' COMMENT 'Conceptos comisionables por recaudo',
  `editarcc` varchar(2) NOT NULL DEFAULT 'NO' COMMENT 'Editar conceptos comisionables'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ccnivel` */

DROP TABLE IF EXISTS `ccnivel`;

CREATE TABLE `ccnivel` (
  `numnv` int(11) NOT NULL,
  `n1` varchar(10) NOT NULL,
  `lon1` int(11) NOT NULL,
  `n2` varchar(10) NOT NULL,
  `lon2` int(11) NOT NULL,
  `n3` varchar(10) NOT NULL,
  `lon3` int(11) NOT NULL,
  `n4` varchar(10) NOT NULL,
  `lon4` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `centrocostos` */

DROP TABLE IF EXISTS `centrocostos`;

CREATE TABLE `centrocostos` (
  `centro` varchar(15) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `pres` double NOT NULL,
  `nivel` varchar(15) NOT NULL,
  PRIMARY KEY (`centro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `citas` */

DROP TABLE IF EXISTS `citas`;

CREATE TABLE `citas` (
  `num` bigint(20) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `servicio` varchar(200) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `observ` text NOT NULL,
  `nitr` varchar(15) NOT NULL,
  `estado` varchar(15) NOT NULL,
  PRIMARY KEY (`num`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `cobdpen` */

DROP TABLE IF EXISTS `cobdpen`;

CREATE TABLE `cobdpen` (
  `doc` varchar(30) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `descrip` varchar(40) NOT NULL,
  `tipafec` varchar(4) NOT NULL,
  `clasaju` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nomnit` varchar(100) NOT NULL,
  `nitcod` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `vmto` int(11) NOT NULL,
  `concepto` varchar(100) NOT NULL,
  `subtotal` double NOT NULL,
  `descto` double NOT NULL,
  `ret` double NOT NULL,
  `iva` decimal(10,2) NOT NULL,
  `v_viva` double NOT NULL,
  `total` double NOT NULL,
  `ctasubtotal` varchar(15) NOT NULL,
  `ctaret` varchar(15) NOT NULL,
  `ctaiva` varchar(15) NOT NULL,
  `ctatotal` varchar(15) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `otroimp` char(1) NOT NULL,
  `retiva` double NOT NULL,
  `ctaretiva` varchar(15) NOT NULL,
  `retica` double NOT NULL,
  `ctaretica` varchar(15) NOT NULL,
  `pagado` double NOT NULL,
  `rcpos` varchar(10) NOT NULL,
  `fechpos` date NOT NULL,
  `vpos` double NOT NULL,
  `tasa` double NOT NULL,
  `moneda` varchar(2) NOT NULL,
  `monloex` char(1) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `salmov` char(1) NOT NULL,
  `pagare` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `comicar` */

DROP TABLE IF EXISTS `comicar`;

CREATE TABLE `comicar` (
  `nitv` varchar(15) NOT NULL,
  `codcon` int(11) NOT NULL,
  `porcomi` decimal(10,2) NOT NULL,
  `r1` int(11) NOT NULL,
  `r2` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `con_gral_imp` */

DROP TABLE IF EXISTS `con_gral_imp`;

CREATE TABLE `con_gral_imp` (
  `cod_concep` varchar(4) NOT NULL COMMENT 'codigo del concepto gral',
  `decrip_gral` varchar(50) NOT NULL,
  PRIMARY KEY (`cod_concep`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `con_inv` */

DROP TABLE IF EXISTS `con_inv`;

CREATE TABLE `con_inv` (
  `codart` varchar(18) NOT NULL,
  `periodo` varchar(2) CHARACTER SET latin1 NOT NULL,
  `costuni` double NOT NULL DEFAULT '0',
  `costprom` double NOT NULL DEFAULT '0',
  `costmoe` double NOT NULL DEFAULT '0',
  `otro` double NOT NULL DEFAULT '0',
  `margen` decimal(10,2) NOT NULL DEFAULT '0.00',
  `base` double NOT NULL DEFAULT '0',
  `precio1` double NOT NULL DEFAULT '0',
  `precio2` double NOT NULL DEFAULT '0',
  `precio3` double NOT NULL DEFAULT '0',
  `precio4` double NOT NULL DEFAULT '0',
  `precio5` double NOT NULL DEFAULT '0',
  `precio6` double NOT NULL DEFAULT '0',
  `cue_inv` varchar(18) CHARACTER SET latin1 NOT NULL,
  `cue_cos` varchar(18) CHARACTER SET latin1 NOT NULL,
  `cue_ing` varchar(18) CHARACTER SET latin1 NOT NULL,
  `cue_iva_v` varchar(18) CHARACTER SET latin1 NOT NULL,
  `cue_iva_c` varchar(18) CHARACTER SET latin1 NOT NULL,
  `cue_dev` varchar(18) CHARACTER SET latin1 NOT NULL,
  `saldoi` double NOT NULL,
  `vent` double NOT NULL,
  `vsal` double NOT NULL,
  `vaju` double NOT NULL,
  `cant1` double NOT NULL DEFAULT '0',
  `cant2` double NOT NULL DEFAULT '0',
  `cant3` double NOT NULL DEFAULT '0',
  `cant4` double NOT NULL DEFAULT '0',
  `cant5` double NOT NULL DEFAULT '0',
  `cant6` double NOT NULL DEFAULT '0',
  `cant7` double NOT NULL DEFAULT '0',
  `cant8` double NOT NULL DEFAULT '0',
  `cant9` double NOT NULL DEFAULT '0',
  `cant10` double NOT NULL DEFAULT '0',
  `cant11` double NOT NULL DEFAULT '0',
  `cant12` double NOT NULL DEFAULT '0',
  `cant13` double NOT NULL DEFAULT '0',
  `cant14` double NOT NULL DEFAULT '0',
  `cant15` double NOT NULL DEFAULT '0',
  `cant16` double NOT NULL DEFAULT '0',
  `cant17` double NOT NULL DEFAULT '0',
  `cant18` double NOT NULL DEFAULT '0',
  `cant19` double NOT NULL DEFAULT '0',
  `cant20` double NOT NULL DEFAULT '0',
  `cant21` double NOT NULL DEFAULT '0',
  `cant22` double NOT NULL DEFAULT '0',
  `cant23` double NOT NULL DEFAULT '0',
  `cant24` double NOT NULL DEFAULT '0',
  `cant25` double NOT NULL DEFAULT '0',
  `cant26` double NOT NULL DEFAULT '0',
  `cant27` double NOT NULL DEFAULT '0',
  `cant28` double NOT NULL DEFAULT '0',
  `cant29` double NOT NULL DEFAULT '0',
  `cant30` double NOT NULL DEFAULT '0',
  KEY `codart` (`codart`),
  CONSTRAINT `con_inv_ibfk_1` FOREIGN KEY (`codart`) REFERENCES `articulos` (`codart`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `conciliacion` */

DROP TABLE IF EXISTS `conciliacion`;

CREATE TABLE `conciliacion` (
  `num` bigint(20) NOT NULL,
  `per` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `ctabanco` varchar(15) NOT NULL,
  `doccon` varchar(15) NOT NULL,
  `docotros` varchar(15) NOT NULL,
  `doccuadre` varchar(15) NOT NULL,
  `fini` date NOT NULL,
  `ffin` date NOT NULL,
  `salaj` double NOT NULL,
  `salbanco` double NOT NULL,
  `sallibro` double NOT NULL,
  `elaborado` varchar(20) NOT NULL,
  PRIMARY KEY (`num`),
  KEY `doccon` (`doccon`,`docotros`,`doccuadre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `concomi` */

DROP TABLE IF EXISTS `concomi`;

CREATE TABLE `concomi` (
  `codcon` int(11) NOT NULL AUTO_INCREMENT,
  `concepto` text NOT NULL,
  `porcomi` decimal(10,2) NOT NULL,
  PRIMARY KEY (`codcon`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `contrato_inm` */

DROP TABLE IF EXISTS `contrato_inm`;

CREATE TABLE `contrato_inm` (
  `cod_contra` varchar(30) NOT NULL,
  `cod_inm` varchar(30) NOT NULL,
  `nit_a` varchar(15) NOT NULL,
  `nomb_arr` varchar(200) NOT NULL,
  `nit_d` varchar(15) NOT NULL,
  `fechaini` date NOT NULL DEFAULT '0000-00-00',
  `fechafin` date NOT NULL DEFAULT '0000-00-00',
  `valor` double NOT NULL,
  `cta_valor` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `rtf` decimal(10,2) NOT NULL,
  `cta_rft` varchar(15) NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `mes_total` double NOT NULL,
  `mes_fact` double NOT NULL,
  `mes_act` double NOT NULL,
  `periodo` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `vmto` int(4) NOT NULL,
  `deposito` double NOT NULL,
  `fechaF` date NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `cta_cli` varchar(15) NOT NULL,
  `cta_cms` varchar(15) NOT NULL,
  `dias` int(11) NOT NULL,
  `mov_deposito` double NOT NULL,
  `doc_dep` varchar(30) NOT NULL,
  `nitc2` varchar(15) NOT NULL,
  `rtc` decimal(10,2) NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  `cont_dp` varchar(2) NOT NULL DEFAULT 'NO',
  PRIMARY KEY (`cod_contra`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `ctas_x_pagar` */

DROP TABLE IF EXISTS `ctas_x_pagar`;

CREATE TABLE `ctas_x_pagar` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_ext` varchar(20) NOT NULL,
  `descrip` text NOT NULL,
  `tipafec` varchar(4) NOT NULL,
  `clasaju` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nomnit` varchar(100) NOT NULL,
  `nitcod` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `vmto` int(11) NOT NULL,
  `concepto` varchar(100) NOT NULL,
  `subtotal` double NOT NULL,
  `descto` double NOT NULL,
  `ret` double NOT NULL,
  `iva` decimal(10,2) NOT NULL,
  `v_viva` double NOT NULL,
  `total` double NOT NULL,
  `ctasubtotal` varchar(15) NOT NULL,
  `ctaret` varchar(15) NOT NULL,
  `ctaiva` varchar(15) NOT NULL,
  `ctatotal` varchar(15) NOT NULL,
  `ccosto` text NOT NULL,
  `otroimp` char(1) NOT NULL,
  `retiva` double NOT NULL,
  `ctaretiva` varchar(15) NOT NULL,
  `retica` double NOT NULL,
  `ctaretica` varchar(15) NOT NULL,
  `pagado` double NOT NULL,
  `rcpos` text NOT NULL,
  `fechpos` date NOT NULL,
  `vpos` double NOT NULL,
  `tasa` double NOT NULL,
  `moneda` varchar(2) NOT NULL,
  `monloex` char(1) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `salmov` char(1) NOT NULL,
  `pagare` varchar(30) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `cuenta_variable` */

DROP TABLE IF EXISTS `cuenta_variable`;

CREATE TABLE `cuenta_variable` (
  `codigo_cu` varchar(10) NOT NULL,
  `id_var` varchar(50) NOT NULL,
  PRIMARY KEY (`codigo_cu`,`id_var`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov00` */

DROP TABLE IF EXISTS `deta_mov00`;

CREATE TABLE `deta_mov00` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov01` */

DROP TABLE IF EXISTS `deta_mov01`;

CREATE TABLE `deta_mov01` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov02` */

DROP TABLE IF EXISTS `deta_mov02`;

CREATE TABLE `deta_mov02` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov03` */

DROP TABLE IF EXISTS `deta_mov03`;

CREATE TABLE `deta_mov03` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov04` */

DROP TABLE IF EXISTS `deta_mov04`;

CREATE TABLE `deta_mov04` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov05` */

DROP TABLE IF EXISTS `deta_mov05`;

CREATE TABLE `deta_mov05` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov06` */

DROP TABLE IF EXISTS `deta_mov06`;

CREATE TABLE `deta_mov06` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov07` */

DROP TABLE IF EXISTS `deta_mov07`;

CREATE TABLE `deta_mov07` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov08` */

DROP TABLE IF EXISTS `deta_mov08`;

CREATE TABLE `deta_mov08` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov09` */

DROP TABLE IF EXISTS `deta_mov09`;

CREATE TABLE `deta_mov09` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov10` */

DROP TABLE IF EXISTS `deta_mov10`;

CREATE TABLE `deta_mov10` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov11` */

DROP TABLE IF EXISTS `deta_mov11`;

CREATE TABLE `deta_mov11` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_mov12` */

DROP TABLE IF EXISTS `deta_mov12`;

CREATE TABLE `deta_mov12` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `bod_ori` int(11) NOT NULL,
  `bod_des` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `pventa` double NOT NULL DEFAULT '0',
  KEY `doc` (`doc`),
  KEY `codart` (`codart`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `deta_ord` */

DROP TABLE IF EXISTS `deta_ord`;

CREATE TABLE `deta_ord` (
  `doc` varchar(30) NOT NULL COMMENT 'orden de compra',
  `cta` varchar(18) NOT NULL COMMENT 'cta contable',
  `concep` text NOT NULL COMMENT 'concepto del movimiento',
  `db` double NOT NULL COMMENT 'valor debito',
  `cr` double NOT NULL COMMENT 'valor credito',
  `porc` double NOT NULL COMMENT 'porcentaje',
  `tipo` varchar(2) NOT NULL COMMENT 'tipo de movimiento',
  `pc` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp01` */

DROP TABLE IF EXISTS `detacomp01`;

CREATE TABLE `detacomp01` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp02` */

DROP TABLE IF EXISTS `detacomp02`;

CREATE TABLE `detacomp02` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp03` */

DROP TABLE IF EXISTS `detacomp03`;

CREATE TABLE `detacomp03` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp04` */

DROP TABLE IF EXISTS `detacomp04`;

CREATE TABLE `detacomp04` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp05` */

DROP TABLE IF EXISTS `detacomp05`;

CREATE TABLE `detacomp05` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp06` */

DROP TABLE IF EXISTS `detacomp06`;

CREATE TABLE `detacomp06` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp07` */

DROP TABLE IF EXISTS `detacomp07`;

CREATE TABLE `detacomp07` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp08` */

DROP TABLE IF EXISTS `detacomp08`;

CREATE TABLE `detacomp08` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp09` */

DROP TABLE IF EXISTS `detacomp09`;

CREATE TABLE `detacomp09` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp10` */

DROP TABLE IF EXISTS `detacomp10`;

CREATE TABLE `detacomp10` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp11` */

DROP TABLE IF EXISTS `detacomp11`;

CREATE TABLE `detacomp11` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detacomp12` */

DROP TABLE IF EXISTS `detacomp12`;

CREATE TABLE `detacomp12` (
  `doc` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `num_bod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `concep` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `detafac01` */

DROP TABLE IF EXISTS `detafac01`;

CREATE TABLE `detafac01` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac02` */

DROP TABLE IF EXISTS `detafac02`;

CREATE TABLE `detafac02` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac03` */

DROP TABLE IF EXISTS `detafac03`;

CREATE TABLE `detafac03` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac04` */

DROP TABLE IF EXISTS `detafac04`;

CREATE TABLE `detafac04` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac05` */

DROP TABLE IF EXISTS `detafac05`;

CREATE TABLE `detafac05` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac06` */

DROP TABLE IF EXISTS `detafac06`;

CREATE TABLE `detafac06` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac07` */

DROP TABLE IF EXISTS `detafac07`;

CREATE TABLE `detafac07` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac08` */

DROP TABLE IF EXISTS `detafac08`;

CREATE TABLE `detafac08` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac09` */

DROP TABLE IF EXISTS `detafac09`;

CREATE TABLE `detafac09` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac10` */

DROP TABLE IF EXISTS `detafac10`;

CREATE TABLE `detafac10` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac11` */

DROP TABLE IF EXISTS `detafac11`;

CREATE TABLE `detafac11` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `detafac12` */

DROP TABLE IF EXISTS `detafac12`;

CREATE TABLE `detafac12` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo_it` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `nomart` text NOT NULL,
  `numbod` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `iva_d` decimal(10,2) NOT NULL,
  `por_des` decimal(10,2) NOT NULL DEFAULT '0.00',
  `cta_inv` varchar(15) NOT NULL,
  `cta_cos` varchar(15) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `costo` double NOT NULL,
  `concep` varchar(10) NOT NULL,
  `nit` varchar(15) NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos00` */

DROP TABLE IF EXISTS `documentos00`;

CREATE TABLE `documentos00` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos01` */

DROP TABLE IF EXISTS `documentos01`;

CREATE TABLE `documentos01` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos02` */

DROP TABLE IF EXISTS `documentos02`;

CREATE TABLE `documentos02` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos03` */

DROP TABLE IF EXISTS `documentos03`;

CREATE TABLE `documentos03` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos04` */

DROP TABLE IF EXISTS `documentos04`;

CREATE TABLE `documentos04` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos05` */

DROP TABLE IF EXISTS `documentos05`;

CREATE TABLE `documentos05` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos06` */

DROP TABLE IF EXISTS `documentos06`;

CREATE TABLE `documentos06` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos07` */

DROP TABLE IF EXISTS `documentos07`;

CREATE TABLE `documentos07` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos08` */

DROP TABLE IF EXISTS `documentos08`;

CREATE TABLE `documentos08` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos09` */

DROP TABLE IF EXISTS `documentos09`;

CREATE TABLE `documentos09` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos10` */

DROP TABLE IF EXISTS `documentos10`;

CREATE TABLE `documentos10` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos11` */

DROP TABLE IF EXISTS `documentos11`;

CREATE TABLE `documentos11` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `documentos12` */

DROP TABLE IF EXISTS `documentos12`;

CREATE TABLE `documentos12` (
  `item` int(4) NOT NULL,
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `periodo` varchar(10) NOT NULL,
  `dia` varchar(2) NOT NULL DEFAULT '',
  `centro` varchar(15) NOT NULL,
  `descri` varchar(50) NOT NULL,
  `debito` double NOT NULL DEFAULT '0',
  `credito` double NOT NULL DEFAULT '0',
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `base` double NOT NULL DEFAULT '0',
  `diasv` int(4) NOT NULL DEFAULT '0',
  `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000',
  `nit` varchar(20) NOT NULL DEFAULT '0',
  `cheque` varchar(20) NOT NULL,
  `modulo` varchar(15) NOT NULL DEFAULT 'contabilidad',
  KEY `nit` (`nit`),
  KEY `codigo` (`codigo`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `error` */

DROP TABLE IF EXISTS `error`;

CREATE TABLE `error` (
  `num` int(11) NOT NULL AUTO_INCREMENT,
  `form` varchar(60) NOT NULL,
  `msj` text NOT NULL,
  `fecha` date NOT NULL,
  `proc` varchar(150) NOT NULL,
  KEY `num` (`num`)
) ENGINE=MyISAM AUTO_INCREMENT=3650 DEFAULT CHARSET=latin1;

/*Table structure for table `fac_acta_entrega` */

DROP TABLE IF EXISTS `fac_acta_entrega`;

CREATE TABLE `fac_acta_entrega` (
  `numero` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `cantped` double NOT NULL,
  `cantdes` double NOT NULL,
  `precio` double NOT NULL,
  `descto` double NOT NULL,
  `iva` decimal(10,2) NOT NULL,
  `vtotal` double NOT NULL,
  `concomi` int(11) NOT NULL,
  `factur` char(1) NOT NULL,
  `preciva` double NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `empaque` varchar(15) NOT NULL,
  `uniemp` double NOT NULL,
  `costo` double NOT NULL,
  `lispre` int(11) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `observ` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facpagos01` */

DROP TABLE IF EXISTS `facpagos01`;

CREATE TABLE `facpagos01` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos02` */

DROP TABLE IF EXISTS `facpagos02`;

CREATE TABLE `facpagos02` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos03` */

DROP TABLE IF EXISTS `facpagos03`;

CREATE TABLE `facpagos03` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos04` */

DROP TABLE IF EXISTS `facpagos04`;

CREATE TABLE `facpagos04` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos05` */

DROP TABLE IF EXISTS `facpagos05`;

CREATE TABLE `facpagos05` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos06` */

DROP TABLE IF EXISTS `facpagos06`;

CREATE TABLE `facpagos06` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos07` */

DROP TABLE IF EXISTS `facpagos07`;

CREATE TABLE `facpagos07` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos08` */

DROP TABLE IF EXISTS `facpagos08`;

CREATE TABLE `facpagos08` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos09` */

DROP TABLE IF EXISTS `facpagos09`;

CREATE TABLE `facpagos09` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos10` */

DROP TABLE IF EXISTS `facpagos10`;

CREATE TABLE `facpagos10` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos11` */

DROP TABLE IF EXISTS `facpagos11`;

CREATE TABLE `facpagos11` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facpagos12` */

DROP TABLE IF EXISTS `facpagos12`;

CREATE TABLE `facpagos12` (
  `doc` varchar(15) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `tt` varchar(2) NOT NULL,
  `banco` varchar(30) NOT NULL,
  `numero` varchar(30) NOT NULL,
  `valor` double NOT NULL,
  KEY `doc` (`doc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `fact_acta_entrega` */

DROP TABLE IF EXISTS `fact_acta_entrega`;

CREATE TABLE `fact_acta_entrega` (
  `numero` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `descrip` text NOT NULL,
  `cantped` double NOT NULL,
  `cantdes` double NOT NULL,
  `precio` double NOT NULL,
  `descto` double NOT NULL,
  `iva` decimal(10,2) NOT NULL,
  `vtotal` double NOT NULL,
  `concomi` int(11) NOT NULL,
  `factur` char(1) NOT NULL,
  `preciva` double NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `empaque` varchar(15) NOT NULL,
  `uniemp` double NOT NULL,
  `costo` double NOT NULL,
  `lispre` int(11) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `observ` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp01` */

DROP TABLE IF EXISTS `fact_comp01`;

CREATE TABLE `fact_comp01` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp02` */

DROP TABLE IF EXISTS `fact_comp02`;

CREATE TABLE `fact_comp02` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp03` */

DROP TABLE IF EXISTS `fact_comp03`;

CREATE TABLE `fact_comp03` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp04` */

DROP TABLE IF EXISTS `fact_comp04`;

CREATE TABLE `fact_comp04` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp05` */

DROP TABLE IF EXISTS `fact_comp05`;

CREATE TABLE `fact_comp05` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp06` */

DROP TABLE IF EXISTS `fact_comp06`;

CREATE TABLE `fact_comp06` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp07` */

DROP TABLE IF EXISTS `fact_comp07`;

CREATE TABLE `fact_comp07` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp08` */

DROP TABLE IF EXISTS `fact_comp08`;

CREATE TABLE `fact_comp08` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp09` */

DROP TABLE IF EXISTS `fact_comp09`;

CREATE TABLE `fact_comp09` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp10` */

DROP TABLE IF EXISTS `fact_comp10`;

CREATE TABLE `fact_comp10` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp11` */

DROP TABLE IF EXISTS `fact_comp11`;

CREATE TABLE `fact_comp11` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fact_comp12` */

DROP TABLE IF EXISTS `fact_comp12`;

CREATE TABLE `fact_comp12` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(20) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `anulado` varchar(150) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `fle` double NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `seg` double NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `ctoc` varchar(15) NOT NULL,
  `fpago` varchar(15) NOT NULL,
  `num_ch` varchar(15) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `tip_tarj` varchar(2) NOT NULL,
  `num_tarj` varchar(50) NOT NULL,
  `desc_otra` varchar(50) NOT NULL,
  `o_con` varchar(2) NOT NULL,
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `b1` double NOT NULL DEFAULT '0',
  `b2` double NOT NULL DEFAULT '0',
  `b3` double NOT NULL DEFAULT '0',
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm01` */

DROP TABLE IF EXISTS `facturainm01`;

CREATE TABLE `facturainm01` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm02` */

DROP TABLE IF EXISTS `facturainm02`;

CREATE TABLE `facturainm02` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm03` */

DROP TABLE IF EXISTS `facturainm03`;

CREATE TABLE `facturainm03` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm04` */

DROP TABLE IF EXISTS `facturainm04`;

CREATE TABLE `facturainm04` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm05` */

DROP TABLE IF EXISTS `facturainm05`;

CREATE TABLE `facturainm05` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm06` */

DROP TABLE IF EXISTS `facturainm06`;

CREATE TABLE `facturainm06` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm07` */

DROP TABLE IF EXISTS `facturainm07`;

CREATE TABLE `facturainm07` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm08` */

DROP TABLE IF EXISTS `facturainm08`;

CREATE TABLE `facturainm08` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm09` */

DROP TABLE IF EXISTS `facturainm09`;

CREATE TABLE `facturainm09` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm10` */

DROP TABLE IF EXISTS `facturainm10`;

CREATE TABLE `facturainm10` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm11` */

DROP TABLE IF EXISTS `facturainm11`;

CREATE TABLE `facturainm11` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturainm12` */

DROP TABLE IF EXISTS `facturainm12`;

CREATE TABLE `facturainm12` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `fecha` date NOT NULL,
  `codcontrato` varchar(30) NOT NULL,
  `codinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `noma` varchar(200) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `nomp` varchar(200) NOT NULL,
  `dias` int(11) NOT NULL,
  `valor` double NOT NULL,
  `totalp` double NOT NULL,
  `otrosp` double NOT NULL,
  `totala` double NOT NULL,
  `otrosa` double NOT NULL,
  `por_comi` decimal(10,2) NOT NULL,
  `vcomi` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `descripcion` text NOT NULL,
  `estado` varchar(2) NOT NULL,
  `doc_anul` varchar(15) NOT NULL,
  `vmto` int(11) NOT NULL,
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `facturas01` */

DROP TABLE IF EXISTS `facturas01`;

CREATE TABLE `facturas01` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas02` */

DROP TABLE IF EXISTS `facturas02`;

CREATE TABLE `facturas02` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas03` */

DROP TABLE IF EXISTS `facturas03`;

CREATE TABLE `facturas03` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas04` */

DROP TABLE IF EXISTS `facturas04`;

CREATE TABLE `facturas04` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas05` */

DROP TABLE IF EXISTS `facturas05`;

CREATE TABLE `facturas05` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas06` */

DROP TABLE IF EXISTS `facturas06`;

CREATE TABLE `facturas06` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas07` */

DROP TABLE IF EXISTS `facturas07`;

CREATE TABLE `facturas07` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas08` */

DROP TABLE IF EXISTS `facturas08`;

CREATE TABLE `facturas08` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas09` */

DROP TABLE IF EXISTS `facturas09`;

CREATE TABLE `facturas09` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas10` */

DROP TABLE IF EXISTS `facturas10`;

CREATE TABLE `facturas10` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas11` */

DROP TABLE IF EXISTS `facturas11`;

CREATE TABLE `facturas11` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas12` */

DROP TABLE IF EXISTS `facturas12`;

CREATE TABLE `facturas12` (
  `doc` varchar(15) NOT NULL,
  `num` bigint(10) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `doc_de` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `descrip` text NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `afecta` varchar(2) NOT NULL,
  `subtotal` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `por_ret_f` decimal(10,2) NOT NULL,
  `ret_f` double NOT NULL,
  `cta_ret_f` varchar(15) NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `por_ret_iva` decimal(10,2) NOT NULL,
  `ret_iva` double NOT NULL,
  `cta_ret_iva` varchar(15) NOT NULL,
  `por_ret_ica` decimal(10,2) NOT NULL,
  `ret_ica` double NOT NULL,
  `cta_ret_ica` varchar(15) NOT NULL,
  `total` double NOT NULL,
  `cta_total` varchar(15) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `observ` text NOT NULL,
  `vmto` int(11) NOT NULL,
  `entregar` text NOT NULL,
  `dir_ent` varchar(50) NOT NULL,
  `ciu_ent` varchar(30) NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `fecha_o` varchar(15) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `o_con` varchar(2) NOT NULL DEFAULT 'no',
  `t1` char(1) NOT NULL,
  `d1` varchar(100) NOT NULL,
  `v1` double NOT NULL,
  `cta1` varchar(15) NOT NULL,
  `t2` char(1) NOT NULL,
  `d2` varchar(100) NOT NULL,
  `v2` double NOT NULL,
  `cta2` varchar(15) NOT NULL,
  `t3` char(1) NOT NULL,
  `d3` varchar(100) NOT NULL,
  `v3` double NOT NULL,
  `cta3` varchar(15) NOT NULL,
  `doc1` varchar(25) NOT NULL DEFAULT ' ',
  `doc2` varchar(25) NOT NULL DEFAULT ' ',
  `doc3` varchar(25) NOT NULL DEFAULT ' ',
  `valor_aj` double NOT NULL COMMENT 'valor ajuste',
  `por_rtc` decimal(10,2) NOT NULL,
  `rtc` double NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `fapipen` */

DROP TABLE IF EXISTS `fapipen`;

CREATE TABLE `fapipen` (
  `numero` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo` char(1) NOT NULL,
  `codart` varchar(18) NOT NULL,
  `descrip` text NOT NULL,
  `cantped` double NOT NULL,
  `cantdes` double NOT NULL,
  `precio` double NOT NULL,
  `descto` double NOT NULL,
  `iva` decimal(10,2) NOT NULL,
  `vtotal` double NOT NULL,
  `concomi` int(11) NOT NULL,
  `factur` char(1) NOT NULL,
  `preciva` double NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `empaque` varchar(15) NOT NULL,
  `uniemp` double NOT NULL,
  `costo` double NOT NULL,
  `lispre` int(11) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `observ` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `gastos` */

DROP TABLE IF EXISTS `gastos`;

CREATE TABLE `gastos` (
  `cod_gas` varchar(15) NOT NULL,
  `nom_gas` varchar(150) NOT NULL,
  `desc_gas` text NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  PRIMARY KEY (`cod_gas`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `grupo_flia` */

DROP TABLE IF EXISTS `grupo_flia`;

CREATE TABLE `grupo_flia` (
  `codgrupo` varchar(15) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `pordes` double NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `edad` date NOT NULL,
  PRIMARY KEY (`codgrupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `grupos` */

DROP TABLE IF EXISTS `grupos`;

CREATE TABLE `grupos` (
  `id_gru` varchar(50) NOT NULL,
  `nombre_gru` varchar(50) NOT NULL,
  PRIMARY KEY (`id_gru`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `impuestos` */

DROP TABLE IF EXISTS `impuestos`;

CREATE TABLE `impuestos` (
  `id_imp` int(11) NOT NULL,
  `cod_concep` varchar(4) NOT NULL,
  `codigo` varchar(4) NOT NULL,
  `descrip` text NOT NULL,
  `porce` decimal(10,2) NOT NULL,
  `cuenta` varchar(10) NOT NULL,
  `tip_asi` char(1) NOT NULL,
  PRIMARY KEY (`id_imp`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inm_dpden` */

DROP TABLE IF EXISTS `inm_dpden`;

CREATE TABLE `inm_dpden` (
  `codigo_inm` varchar(30) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `espacio` decimal(10,2) NOT NULL,
  `umedida` varchar(5) NOT NULL,
  KEY `codigo_inm` (`codigo_inm`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inm_galeria` */

DROP TABLE IF EXISTS `inm_galeria`;

CREATE TABLE `inm_galeria` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codinm` varchar(30) NOT NULL,
  `imagen` longblob NOT NULL,
  `descr` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inm_llaves` */

DROP TABLE IF EXISTS `inm_llaves`;

CREATE TABLE `inm_llaves` (
  `codigo_inm` varchar(30) NOT NULL,
  `sitio` varchar(100) NOT NULL,
  `cant` bigint(20) NOT NULL,
  `marca` varchar(60) NOT NULL,
  KEY `codigo_inm` (`codigo_inm`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inm_novdad` */

DROP TABLE IF EXISTS `inm_novdad`;

CREATE TABLE `inm_novdad` (
  `ndoc` varchar(15) NOT NULL,
  `codigoinm` varchar(30) NOT NULL,
  `nita` varchar(15) NOT NULL,
  `novedad` text NOT NULL,
  `fecha` date NOT NULL,
  `estado` varchar(20) NOT NULL,
  `proced` text NOT NULL,
  `fecha_pro` date NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `perdoc` varchar(10) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `valor` double NOT NULL,
  PRIMARY KEY (`ndoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inm_servicios` */

DROP TABLE IF EXISTS `inm_servicios`;

CREATE TABLE `inm_servicios` (
  `codigo_inm` varchar(30) NOT NULL,
  `descrip` varchar(60) NOT NULL,
  `codigo` varchar(60) NOT NULL,
  `numero` varchar(60) NOT NULL,
  `titular` varchar(100) NOT NULL,
  `observacion` text NOT NULL,
  `perdoc` varchar(10) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `deposito` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inm_servpagos` */

DROP TABLE IF EXISTS `inm_servpagos`;

CREATE TABLE `inm_servpagos` (
  `codigo_inm` varchar(30) NOT NULL,
  `mes` varchar(60) NOT NULL,
  `servicio` varchar(60) NOT NULL,
  `fecha` date NOT NULL,
  `valor` double NOT NULL,
  `forma` varchar(100) NOT NULL,
  `perdoc` varchar(10) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `deposito` double NOT NULL,
  KEY `codigo_inm` (`codigo_inm`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inm_tipo` */

DROP TABLE IF EXISTS `inm_tipo`;

CREATE TABLE `inm_tipo` (
  `item` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(60) NOT NULL,
  PRIMARY KEY (`item`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `inmuebles` */

DROP TABLE IF EXISTS `inmuebles`;

CREATE TABLE `inmuebles` (
  `codigo` varchar(30) NOT NULL,
  `nitp` varchar(15) NOT NULL,
  `avaluo` double NOT NULL,
  `estado` varchar(20) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `vcanon` double NOT NULL,
  `descrip` text NOT NULL,
  `tipoim` varchar(60) NOT NULL,
  `operacion` varchar(10) NOT NULL,
  `dpto` varchar(10) NOT NULL,
  `barrio` varchar(100) NOT NULL,
  `estrato` varchar(2) NOT NULL,
  `conserv` varchar(20) NOT NULL,
  `tipoestado` varchar(8) NOT NULL,
  `destino` varchar(10) NOT NULL,
  `llaves` bigint(20) NOT NULL,
  `previvi` double NOT NULL,
  `prelocal` double NOT NULL,
  `ncatast` varchar(100) NOT NULL,
  `avcatast` double NOT NULL,
  `notaria` varchar(100) NOT NULL,
  `n_escritura` varchar(60) NOT NULL,
  `f_escritura` varchar(100) NOT NULL,
  `matricula` varchar(100) NOT NULL,
  `inscripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `lista_cliente` */

DROP TABLE IF EXISTS `lista_cliente`;

CREATE TABLE `lista_cliente` (
  `numlist` int(11) NOT NULL,
  `nitc` varchar(20) NOT NULL,
  UNIQUE KEY `nitc` (`nitc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `listasprec` */

DROP TABLE IF EXISTS `listasprec`;

CREATE TABLE `listasprec` (
  `numlist` int(11) NOT NULL AUTO_INCREMENT,
  `nomlist` varchar(70) NOT NULL,
  PRIMARY KEY (`numlist`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `metas_x_area` */

DROP TABLE IF EXISTS `metas_x_area`;

CREATE TABLE `metas_x_area` (
  `codigo` varchar(20) NOT NULL,
  `area` varchar(60) NOT NULL,
  `tope` double NOT NULL,
  `tipcom` varchar(15) NOT NULL,
  `valcom` double NOT NULL,
  `fini` date NOT NULL,
  `ffin` date NOT NULL,
  `rango` varchar(20) NOT NULL,
  `felab` date NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `movimientos00` */

DROP TABLE IF EXISTS `movimientos00`;

CREATE TABLE `movimientos00` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos01` */

DROP TABLE IF EXISTS `movimientos01`;

CREATE TABLE `movimientos01` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos02` */

DROP TABLE IF EXISTS `movimientos02`;

CREATE TABLE `movimientos02` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos03` */

DROP TABLE IF EXISTS `movimientos03`;

CREATE TABLE `movimientos03` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos04` */

DROP TABLE IF EXISTS `movimientos04`;

CREATE TABLE `movimientos04` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos05` */

DROP TABLE IF EXISTS `movimientos05`;

CREATE TABLE `movimientos05` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos06` */

DROP TABLE IF EXISTS `movimientos06`;

CREATE TABLE `movimientos06` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos07` */

DROP TABLE IF EXISTS `movimientos07`;

CREATE TABLE `movimientos07` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos08` */

DROP TABLE IF EXISTS `movimientos08`;

CREATE TABLE `movimientos08` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos09` */

DROP TABLE IF EXISTS `movimientos09`;

CREATE TABLE `movimientos09` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos10` */

DROP TABLE IF EXISTS `movimientos10`;

CREATE TABLE `movimientos10` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos11` */

DROP TABLE IF EXISTS `movimientos11`;

CREATE TABLE `movimientos11` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `movimientos12` */

DROP TABLE IF EXISTS `movimientos12`;

CREATE TABLE `movimientos12` (
  `doc` varchar(15) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `per` varchar(7) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `hora` time NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `tipo_mov` char(1) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  `desc_mov` varchar(100) NOT NULL,
  `cc` varchar(15) NOT NULL,
  `concepto` text NOT NULL,
  `o_compra` varchar(15) NOT NULL,
  `n_pedido` varchar(15) NOT NULL,
  `observ` text NOT NULL,
  `total` double NOT NULL,
  `estado` varchar(2) NOT NULL,
  PRIMARY KEY (`doc`),
  KEY `nitc` (`nitc`),
  KEY `tipodoc` (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `obsdocumentos01` */

DROP TABLE IF EXISTS `obsdocumentos01`;

CREATE TABLE `obsdocumentos01` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos02` */

DROP TABLE IF EXISTS `obsdocumentos02`;

CREATE TABLE `obsdocumentos02` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos03` */

DROP TABLE IF EXISTS `obsdocumentos03`;

CREATE TABLE `obsdocumentos03` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos04` */

DROP TABLE IF EXISTS `obsdocumentos04`;

CREATE TABLE `obsdocumentos04` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos05` */

DROP TABLE IF EXISTS `obsdocumentos05`;

CREATE TABLE `obsdocumentos05` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos06` */

DROP TABLE IF EXISTS `obsdocumentos06`;

CREATE TABLE `obsdocumentos06` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos07` */

DROP TABLE IF EXISTS `obsdocumentos07`;

CREATE TABLE `obsdocumentos07` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos08` */

DROP TABLE IF EXISTS `obsdocumentos08`;

CREATE TABLE `obsdocumentos08` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos09` */

DROP TABLE IF EXISTS `obsdocumentos09`;

CREATE TABLE `obsdocumentos09` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos10` */

DROP TABLE IF EXISTS `obsdocumentos10`;

CREATE TABLE `obsdocumentos10` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos11` */

DROP TABLE IF EXISTS `obsdocumentos11`;

CREATE TABLE `obsdocumentos11` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `obsdocumentos12` */

DROP TABLE IF EXISTS `obsdocumentos12`;

CREATE TABLE `obsdocumentos12` (
  `doc` bigint(20) NOT NULL,
  `tipodoc` varchar(2) NOT NULL,
  `comentario` text NOT NULL,
  PRIMARY KEY (`doc`,`tipodoc`),
  KEY `doc` (`doc`,`tipodoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ord_pagos` */

DROP TABLE IF EXISTS `ord_pagos`;

CREATE TABLE `ord_pagos` (
  `doc` varchar(30) NOT NULL COMMENT 'documento',
  `per` varchar(7) NOT NULL COMMENT 'periodo',
  `num` bigint(20) NOT NULL COMMENT 'numero de documento',
  `fecha` date NOT NULL COMMENT 'fecha de elaboracion',
  `con_num` varchar(20) NOT NULL COMMENT 'numero de contrato',
  `con_ben` varchar(15) NOT NULL COMMENT 'nit tercero',
  `nomnit` varchar(200) NOT NULL COMMENT 'nombre del tercero',
  `con_objeto` text NOT NULL COMMENT 'objeto del contrato',
  `con_valor` double NOT NULL COMMENT 'valor del contrato',
  `con_plazo` varchar(5) NOT NULL COMMENT 'plazo del contrato',
  `sop_cont` varchar(30) NOT NULL COMMENT 'soporte / documento de egreso',
  `cta_rubro` text NOT NULL COMMENT 'cta de rubro',
  `v_bruto` double NOT NULL COMMENT 'valor bruto',
  `v_neto` double NOT NULL COMMENT 'valor neto a pagar',
  `v_iva` double NOT NULL COMMENT 'valor del iva del contrato',
  `estado` varchar(2) NOT NULL COMMENT 'Estado de la orden',
  `user` varchar(20) NOT NULL COMMENT 'ultimo usuario que modifico',
  `ult_up` datetime NOT NULL COMMENT 'fecha de la ultima modificacion',
  `doccxp` varchar(15) NOT NULL COMMENT 'doc cuentas por pagar',
  `resolucion` varchar(40) NOT NULL COMMENT 'resolucion',
  PRIMARY KEY (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc01` */

DROP TABLE IF EXISTS `ot_cpc01`;

CREATE TABLE `ot_cpc01` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc02` */

DROP TABLE IF EXISTS `ot_cpc02`;

CREATE TABLE `ot_cpc02` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc03` */

DROP TABLE IF EXISTS `ot_cpc03`;

CREATE TABLE `ot_cpc03` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc04` */

DROP TABLE IF EXISTS `ot_cpc04`;

CREATE TABLE `ot_cpc04` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc05` */

DROP TABLE IF EXISTS `ot_cpc05`;

CREATE TABLE `ot_cpc05` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc06` */

DROP TABLE IF EXISTS `ot_cpc06`;

CREATE TABLE `ot_cpc06` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc07` */

DROP TABLE IF EXISTS `ot_cpc07`;

CREATE TABLE `ot_cpc07` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc08` */

DROP TABLE IF EXISTS `ot_cpc08`;

CREATE TABLE `ot_cpc08` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc09` */

DROP TABLE IF EXISTS `ot_cpc09`;

CREATE TABLE `ot_cpc09` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc10` */

DROP TABLE IF EXISTS `ot_cpc10`;

CREATE TABLE `ot_cpc10` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc11` */

DROP TABLE IF EXISTS `ot_cpc11`;

CREATE TABLE `ot_cpc11` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpc12` */

DROP TABLE IF EXISTS `ot_cpc12`;

CREATE TABLE `ot_cpc12` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' ',
  `nitv` varchar(15) NOT NULL,
  `codcon` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp01` */

DROP TABLE IF EXISTS `ot_cpp01`;

CREATE TABLE `ot_cpp01` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp02` */

DROP TABLE IF EXISTS `ot_cpp02`;

CREATE TABLE `ot_cpp02` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp03` */

DROP TABLE IF EXISTS `ot_cpp03`;

CREATE TABLE `ot_cpp03` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp04` */

DROP TABLE IF EXISTS `ot_cpp04`;

CREATE TABLE `ot_cpp04` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp05` */

DROP TABLE IF EXISTS `ot_cpp05`;

CREATE TABLE `ot_cpp05` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp06` */

DROP TABLE IF EXISTS `ot_cpp06`;

CREATE TABLE `ot_cpp06` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp07` */

DROP TABLE IF EXISTS `ot_cpp07`;

CREATE TABLE `ot_cpp07` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp08` */

DROP TABLE IF EXISTS `ot_cpp08`;

CREATE TABLE `ot_cpp08` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp09` */

DROP TABLE IF EXISTS `ot_cpp09`;

CREATE TABLE `ot_cpp09` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp10` */

DROP TABLE IF EXISTS `ot_cpp10`;

CREATE TABLE `ot_cpp10` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp11` */

DROP TABLE IF EXISTS `ot_cpp11`;

CREATE TABLE `ot_cpp11` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_cpp12` */

DROP TABLE IF EXISTS `ot_cpp12`;

CREATE TABLE `ot_cpp12` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `total` double NOT NULL,
  `tipo_pago` varchar(10) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `abonado` double NOT NULL,
  `doc_anti` varchar(25) NOT NULL DEFAULT ' '
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc01` */

DROP TABLE IF EXISTS `ot_doc01`;

CREATE TABLE `ot_doc01` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc02` */

DROP TABLE IF EXISTS `ot_doc02`;

CREATE TABLE `ot_doc02` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc03` */

DROP TABLE IF EXISTS `ot_doc03`;

CREATE TABLE `ot_doc03` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc04` */

DROP TABLE IF EXISTS `ot_doc04`;

CREATE TABLE `ot_doc04` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc05` */

DROP TABLE IF EXISTS `ot_doc05`;

CREATE TABLE `ot_doc05` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc06` */

DROP TABLE IF EXISTS `ot_doc06`;

CREATE TABLE `ot_doc06` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc07` */

DROP TABLE IF EXISTS `ot_doc07`;

CREATE TABLE `ot_doc07` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc08` */

DROP TABLE IF EXISTS `ot_doc08`;

CREATE TABLE `ot_doc08` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc09` */

DROP TABLE IF EXISTS `ot_doc09`;

CREATE TABLE `ot_doc09` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc10` */

DROP TABLE IF EXISTS `ot_doc10`;

CREATE TABLE `ot_doc10` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc11` */

DROP TABLE IF EXISTS `ot_doc11`;

CREATE TABLE `ot_doc11` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ot_doc12` */

DROP TABLE IF EXISTS `ot_doc12`;

CREATE TABLE `ot_doc12` (
  `item` bigint(20) NOT NULL,
  `doc` varchar(15) NOT NULL,
  `grupo` varchar(2) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `num` bigint(20) NOT NULL,
  `doc_afec` varchar(15) NOT NULL,
  `dia` varchar(2) NOT NULL,
  `periodo` varchar(8) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `concepto` text NOT NULL,
  `nitc` varchar(20) NOT NULL,
  `tn` varchar(4) NOT NULL,
  `codigo` varchar(18) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `debito` double NOT NULL,
  `credito` double NOT NULL,
  `base` double NOT NULL,
  `total` double NOT NULL,
  `efectivo` char(1) NOT NULL,
  `cheque` varchar(20) NOT NULL,
  `banco` varchar(50) NOT NULL,
  `sucursal` varchar(50) NOT NULL,
  `ccosto` varchar(15) NOT NULL,
  `fecha` date NOT NULL,
  `elaborado` varchar(50) NOT NULL,
  `autorizado` varchar(50) NOT NULL,
  `revisado` varchar(50) NOT NULL,
  `contabilizado` varchar(50) NOT NULL,
  `doc_aj` varchar(30) NOT NULL,
  `cod_contra` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp01` */

DROP TABLE IF EXISTS `otcon_comp01`;

CREATE TABLE `otcon_comp01` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp02` */

DROP TABLE IF EXISTS `otcon_comp02`;

CREATE TABLE `otcon_comp02` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp03` */

DROP TABLE IF EXISTS `otcon_comp03`;

CREATE TABLE `otcon_comp03` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp04` */

DROP TABLE IF EXISTS `otcon_comp04`;

CREATE TABLE `otcon_comp04` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp05` */

DROP TABLE IF EXISTS `otcon_comp05`;

CREATE TABLE `otcon_comp05` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp06` */

DROP TABLE IF EXISTS `otcon_comp06`;

CREATE TABLE `otcon_comp06` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp07` */

DROP TABLE IF EXISTS `otcon_comp07`;

CREATE TABLE `otcon_comp07` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp08` */

DROP TABLE IF EXISTS `otcon_comp08`;

CREATE TABLE `otcon_comp08` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp09` */

DROP TABLE IF EXISTS `otcon_comp09`;

CREATE TABLE `otcon_comp09` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp10` */

DROP TABLE IF EXISTS `otcon_comp10`;

CREATE TABLE `otcon_comp10` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp11` */

DROP TABLE IF EXISTS `otcon_comp11`;

CREATE TABLE `otcon_comp11` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_comp12` */

DROP TABLE IF EXISTS `otcon_comp12`;

CREATE TABLE `otcon_comp12` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_contrato` */

DROP TABLE IF EXISTS `otcon_contrato`;

CREATE TABLE `otcon_contrato` (
  `codcon` varchar(30) NOT NULL,
  `item` varchar(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descr` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `base` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `tcli` varchar(15) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `contb` char(1) NOT NULL DEFAULT 'N',
  `dia` char(2) NOT NULL DEFAULT 'NO'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac01` */

DROP TABLE IF EXISTS `otcon_fac01`;

CREATE TABLE `otcon_fac01` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac02` */

DROP TABLE IF EXISTS `otcon_fac02`;

CREATE TABLE `otcon_fac02` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac03` */

DROP TABLE IF EXISTS `otcon_fac03`;

CREATE TABLE `otcon_fac03` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac04` */

DROP TABLE IF EXISTS `otcon_fac04`;

CREATE TABLE `otcon_fac04` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac05` */

DROP TABLE IF EXISTS `otcon_fac05`;

CREATE TABLE `otcon_fac05` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac06` */

DROP TABLE IF EXISTS `otcon_fac06`;

CREATE TABLE `otcon_fac06` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac07` */

DROP TABLE IF EXISTS `otcon_fac07`;

CREATE TABLE `otcon_fac07` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac08` */

DROP TABLE IF EXISTS `otcon_fac08`;

CREATE TABLE `otcon_fac08` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac09` */

DROP TABLE IF EXISTS `otcon_fac09`;

CREATE TABLE `otcon_fac09` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac10` */

DROP TABLE IF EXISTS `otcon_fac10`;

CREATE TABLE `otcon_fac10` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac11` */

DROP TABLE IF EXISTS `otcon_fac11`;

CREATE TABLE `otcon_fac11` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otcon_fac12` */

DROP TABLE IF EXISTS `otcon_fac12`;

CREATE TABLE `otcon_fac12` (
  `doc` varchar(15) NOT NULL,
  `item` int(11) NOT NULL,
  `tipo` char(1) NOT NULL,
  `descrip` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `cta` varchar(15) NOT NULL,
  `base` double NOT NULL DEFAULT '0',
  `doc_ant` varchar(25) NOT NULL DEFAULT ' ',
  KEY `doc` (`doc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `otdoc_pres` */

DROP TABLE IF EXISTS `otdoc_pres`;

CREATE TABLE `otdoc_pres` (
  `num` double NOT NULL AUTO_INCREMENT,
  `rb` varchar(500) NOT NULL,
  `rb_cod1` varchar(50) NOT NULL,
  `rb_cod2` varchar(50) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `fecha` date NOT NULL,
  `doc_ci` varchar(15) NOT NULL,
  `num_ci` bigint(20) NOT NULL,
  `doc_rc` varchar(15) NOT NULL,
  `num_rc` bigint(20) NOT NULL,
  `concepto` varchar(100) NOT NULL,
  `valor` double NOT NULL,
  `tipoing` char(1) NOT NULL DEFAULT '1' COMMENT '1: ing causac 2:ing normal',
  PRIMARY KEY (`num`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `par_analisis` */

DROP TABLE IF EXISTS `par_analisis`;

CREATE TABLE `par_analisis` (
  `num` int(11) NOT NULL,
  `detalle` varchar(30) NOT NULL,
  `cuenta1` varchar(15) NOT NULL,
  `cuenta2` varchar(15) NOT NULL,
  `cuenta3` varchar(15) NOT NULL,
  `cuenta4` varchar(15) NOT NULL,
  `cuenta5` varchar(15) NOT NULL,
  `cuenta6` varchar(15) NOT NULL,
  `cuenta7` varchar(15) NOT NULL,
  `cuenta8` varchar(15) NOT NULL,
  `cuenta9` varchar(15) NOT NULL,
  `cuenta10` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `par_comp` */

DROP TABLE IF EXISTS `par_comp`;

CREATE TABLE `par_comp` (
  `doc_fp` varchar(4) NOT NULL,
  `doc_aj` varchar(4) NOT NULL,
  `doc_cpp` varchar(4) NOT NULL,
  `doc_gas` varchar(4) NOT NULL,
  `doc_ppf` varchar(4) NOT NULL,
  `int_con` varchar(2) NOT NULL,
  `cta_caja` varchar(15) NOT NULL,
  `cta_banco` varchar(15) NOT NULL,
  `cta_cpp` varchar(15) NOT NULL,
  `cta_gas` varchar(15) NOT NULL,
  `cta_com` varchar(15) NOT NULL,
  `cta_desc` varchar(15) NOT NULL,
  `cta_inv` varchar(15) NOT NULL,
  `cta_iva_g` varchar(15) NOT NULL,
  `por_iva_g` decimal(10,2) NOT NULL,
  `cta_iva_d` varchar(15) NOT NULL,
  `por_iva_d` decimal(10,2) NOT NULL,
  `cta_rtf` varchar(15) NOT NULL,
  `cta_fle` varchar(15) NOT NULL,
  `cta_seg` varchar(15) NOT NULL,
  `cta_ppf_c` varchar(15) NOT NULL,
  `cta_ppf_d` varchar(15) NOT NULL,
  `sol_num_com` varchar(2) NOT NULL,
  `can_fact` varchar(2) NOT NULL,
  `fs_aum_inv` varchar(2) NOT NULL,
  `imp_ap` varchar(2) NOT NULL,
  `format_fp` varchar(10) NOT NULL,
  `logo_fp` longblob,
  `format_cpp` varchar(10) NOT NULL,
  `logo_cpp` longblob,
  `format_ppf` varchar(10) NOT NULL,
  `logo_ppf` longblob,
  `comentario` text NOT NULL,
  `dec` varchar(1) NOT NULL DEFAULT 'S',
  `deci` varchar(1) NOT NULL DEFAULT 'S'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `parafacgral` */

DROP TABLE IF EXISTS `parafacgral`;

CREATE TABLE `parafacgral` (
  `tipof1` varchar(4) NOT NULL,
  `tipof2` varchar(4) NOT NULL,
  `tipof3` varchar(4) NOT NULL,
  `tipof4` varchar(4) NOT NULL,
  `tipoaj` varchar(4) NOT NULL,
  `a_f1` bigint(20) NOT NULL,
  `a_f2` bigint(20) NOT NULL,
  `a_f3` bigint(20) NOT NULL,
  `a_f4` bigint(20) NOT NULL,
  `hr1` varchar(2) NOT NULL,
  `hr2` varchar(2) NOT NULL,
  `hr3` varchar(2) NOT NULL,
  `hr4` varchar(2) NOT NULL,
  `reso1` varchar(30) NOT NULL,
  `reso2` varchar(30) NOT NULL,
  `reso3` varchar(30) NOT NULL,
  `reso4` varchar(30) NOT NULL,
  `fecexp1` date NOT NULL,
  `fecexp2` date NOT NULL,
  `fecexp3` date NOT NULL,
  `fecexp4` date NOT NULL,
  `feclim1` date NOT NULL,
  `feclim2` date NOT NULL,
  `feclim3` date NOT NULL,
  `feclim4` date NOT NULL,
  `ini1` bigint(20) NOT NULL,
  `ini2` bigint(20) NOT NULL,
  `ini3` bigint(20) NOT NULL,
  `ini4` bigint(20) NOT NULL,
  `fin1` bigint(20) NOT NULL,
  `fin2` bigint(20) NOT NULL,
  `fin3` bigint(20) NOT NULL,
  `fin4` bigint(20) NOT NULL,
  `formcosto` varchar(20) NOT NULL,
  `ivainclu` varchar(2) NOT NULL,
  `comventa` varchar(2) NOT NULL,
  `intecontab` varchar(2) NOT NULL,
  `caja` varchar(15) DEFAULT NULL,
  `bancos` varchar(15) DEFAULT NULL,
  `ctapc` varchar(15) DEFAULT NULL,
  `inventario` varchar(15) DEFAULT NULL,
  `ventas` varchar(15) DEFAULT NULL,
  `costoventa` varchar(15) DEFAULT NULL,
  `ivapp` varchar(15) DEFAULT NULL,
  `ivadesc` varchar(15) DEFAULT NULL,
  `porivapp` decimal(10,2) DEFAULT NULL,
  `porivadesc` decimal(10,2) DEFAULT NULL,
  `descuento` varchar(15) DEFAULT NULL,
  `retfuente` varchar(15) DEFAULT NULL,
  `reteica` varchar(15) DEFAULT NULL,
  `reteiva` varchar(15) DEFAULT NULL,
  `pre1` varchar(10) NOT NULL,
  `pre2` varchar(10) NOT NULL,
  `pre3` varchar(10) NOT NULL,
  `pre4` varchar(10) NOT NULL,
  `lista_art` varchar(10) NOT NULL DEFAULT 'SI',
  `lista_pre` varchar(3) NOT NULL DEFAULT 'SI',
  `Guar_Ap` varchar(2) NOT NULL DEFAULT 'N',
  `rtc` char(1) NOT NULL DEFAULT 'N',
  `por_rtc` decimal(5,2) NOT NULL,
  `cta_rtc` varchar(15) NOT NULL,
  `cta_pt` varchar(15) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `parafacts` */

DROP TABLE IF EXISTS `parafacts`;

CREATE TABLE `parafacts` (
  `factura` varchar(10) NOT NULL,
  `doc` char(1) NOT NULL,
  `tipodoc` varchar(4) NOT NULL,
  `numfact` varchar(15) NOT NULL,
  `afecinv` char(1) NOT NULL,
  `fecha` varchar(15) NOT NULL,
  `nitcpre` char(1) NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `nitvpre` char(1) NOT NULL,
  `nitv` varchar(15) NOT NULL,
  `codinv` char(1) NOT NULL,
  `centrocost` char(1) NOT NULL,
  `facdifuniemp` char(1) NOT NULL,
  `precautcant` char(1) NOT NULL,
  `bodpred` char(1) NOT NULL,
  `idbod` varchar(15) NOT NULL,
  `margmin` char(1) NOT NULL,
  `margen` varchar(15) NOT NULL,
  `concomipre` char(1) NOT NULL,
  `concomi` varchar(10) NOT NULL,
  `fpagopre` char(1) NOT NULL,
  `cualfp` varchar(15) NOT NULL,
  `formatfac` varchar(10) NOT NULL,
  `logofac` longblob,
  `formatped` varchar(10) NOT NULL,
  `logoped` longblob,
  `formatcot` varchar(10) NOT NULL,
  `logocot` longblob,
  `tipocompa` varchar(30) NOT NULL,
  `comentario` text NOT NULL,
  `imp_dec` char(1) NOT NULL DEFAULT 'S',
  `bus_cli` varchar(3) NOT NULL DEFAULT 'N',
  `GuarNumFac` varchar(2) NOT NULL DEFAULT 'N',
  `comentario_ini` text NOT NULL,
  PRIMARY KEY (`factura`),
  KEY `nitc` (`nitc`),
  KEY `nitv` (`nitv`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `parcontab` */

DROP TABLE IF EXISTS `parcontab`;

CREATE TABLE `parcontab` (
  `longitud` int(10) unsigned NOT NULL,
  `niveles` int(10) unsigned NOT NULL,
  `nivel1` int(11) unsigned NOT NULL DEFAULT '0',
  `nivel2` int(11) unsigned NOT NULL DEFAULT '0',
  `nivel3` int(10) unsigned NOT NULL,
  `nivel4` int(10) unsigned NOT NULL,
  `nivel5` int(11) unsigned NOT NULL DEFAULT '0',
  `ccosto` varchar(2) NOT NULL,
  `ctaDiferencia` varchar(10) DEFAULT NULL,
  `ctaPerdida` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`longitud`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `parcontrato` */

DROP TABLE IF EXISTS `parcontrato`;

CREATE TABLE `parcontrato` (
  `comentario` text NOT NULL,
  `ctavent` varchar(15) NOT NULL,
  `ctaiva` varchar(15) NOT NULL,
  `ctartf` varchar(15) NOT NULL,
  `parf` varchar(2) NOT NULL DEFAULT 'NO',
  `docf` varchar(3) NOT NULL,
  `tipof1` varchar(4) NOT NULL,
  `a_f1` bigint(20) NOT NULL,
  `hr1` varchar(2) NOT NULL,
  `reso1` varchar(30) NOT NULL,
  `fecexp1` date NOT NULL DEFAULT '0000-00-00',
  `feclim1` date NOT NULL DEFAULT '0000-00-00',
  `ini1` bigint(20) NOT NULL,
  `fin1` bigint(20) NOT NULL,
  `pre1` varchar(10) NOT NULL,
  `ctacli` varchar(15) NOT NULL,
  `ctacms` varchar(15) NOT NULL,
  `mora` decimal(10,6) NOT NULL,
  `logo` longblob,
  `ctaad` varchar(15) NOT NULL,
  `ctaac` varchar(15) NOT NULL,
  `editar` varchar(2) NOT NULL DEFAULT 'SI'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `parinven` */

DROP TABLE IF EXISTS `parinven`;

CREATE TABLE `parinven` (
  `longitud` int(11) NOT NULL,
  `nivel1` int(11) NOT NULL,
  `desc1` varchar(20) NOT NULL,
  `nivel2` int(11) NOT NULL,
  `desc2` varchar(20) NOT NULL,
  `nivel3` int(11) NOT NULL,
  `desc3` varchar(20) NOT NULL,
  `nivel4` int(11) NOT NULL,
  `desc4` varchar(20) NOT NULL,
  `nivel5` int(11) NOT NULL,
  `desc5` varchar(20) NOT NULL,
  `nivel6` int(11) NOT NULL,
  `desc6` varchar(20) NOT NULL,
  `formula` varchar(30) NOT NULL,
  `porcen` int(11) NOT NULL,
  `traslados` varchar(4) NOT NULL,
  `ajustes` varchar(4) NOT NULL,
  `entradas` varchar(4) NOT NULL,
  `salidas` varchar(4) NOT NULL,
  `codbar` varchar(2) NOT NULL,
  `contable` varchar(2) NOT NULL,
  `cuenta1` varchar(15) NOT NULL,
  `cuenta2` varchar(15) NOT NULL,
  `cuenta3` varchar(15) NOT NULL,
  `cuenta4` varchar(15) NOT NULL,
  `cuenta5` varchar(15) NOT NULL,
  `cuenta6` varchar(15) NOT NULL,
  `vsalida` varchar(2) NOT NULL DEFAULT 'CS',
  `cdebito` varchar(15) NOT NULL,
  `ccredito` varchar(15) NOT NULL,
  `guar_Ap` varchar(2) NOT NULL DEFAULT 'NO'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `parordenes` */

DROP TABLE IF EXISTS `parordenes`;

CREATE TABLE `parordenes` (
  `num` int(11) NOT NULL,
  `titulo1` varchar(60) NOT NULL,
  `msj1` varchar(60) NOT NULL,
  `firma1` varchar(100) NOT NULL,
  `pie1` varchar(60) NOT NULL,
  `titulo2` varchar(60) NOT NULL,
  `msj2` varchar(60) NOT NULL,
  `firma2` varchar(100) NOT NULL,
  `pie2` varchar(60) NOT NULL,
  `titulo3` varchar(60) NOT NULL,
  `msj3` varchar(60) NOT NULL,
  `firma3` varchar(100) NOT NULL,
  `pie3` varchar(60) NOT NULL,
  `titulo4` varchar(60) NOT NULL,
  `msj4` varchar(60) NOT NULL,
  `firma4` varchar(100) NOT NULL,
  `pie4` varchar(60) NOT NULL,
  `titulo5` varchar(60) NOT NULL,
  `msj5` varchar(60) NOT NULL,
  `firma5` varchar(100) NOT NULL,
  `pie5` varchar(60) NOT NULL,
  `forden` char(1) NOT NULL,
  `fce` char(1) NOT NULL,
  `nord` char(1) NOT NULL DEFAULT 'M',
  `foce` char(1) NOT NULL DEFAULT '1' COMMENT 'OtrosCE'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `parotdoc` */

DROP TABLE IF EXISTS `parotdoc`;

CREATE TABLE `parotdoc` (
  `ce` varchar(4) NOT NULL,
  `ci` varchar(4) NOT NULL,
  `rc` varchar(4) NOT NULL,
  `nd` varchar(4) NOT NULL,
  `nc` varchar(4) NOT NULL,
  `cd` varchar(4) NOT NULL,
  `aj` varchar(4) NOT NULL,
  `logo` varchar(2) NOT NULL DEFAULT 'NO'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `parrecaudo` */

DROP TABLE IF EXISTS `parrecaudo`;

CREATE TABLE `parrecaudo` (
  `ci` varchar(4) NOT NULL,
  `rc` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `parreso` */

DROP TABLE IF EXISTS `parreso`;

CREATE TABLE `parreso` (
  `titulo` text NOT NULL,
  `municipio` varchar(200) NOT NULL,
  `firma` varchar(200) NOT NULL,
  `pie` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `pedi_comp` */

DROP TABLE IF EXISTS `pedi_comp`;

CREATE TABLE `pedi_comp` (
  `numero` varchar(15) NOT NULL,
  `item` bigint(20) NOT NULL,
  `tipo` varchar(4) NOT NULL,
  `cod_art` varchar(18) NOT NULL,
  `nom_art` text NOT NULL,
  `cantped` double NOT NULL,
  `cantrec` double NOT NULL,
  `costo` double NOT NULL,
  `por_desc` decimal(10,2) NOT NULL,
  `descuento` double NOT NULL,
  `por_iva` decimal(10,2) NOT NULL,
  `iva` double NOT NULL,
  `por_rtf` decimal(10,2) NOT NULL,
  `rtf` double NOT NULL,
  `valor` double NOT NULL,
  `vtotal` double NOT NULL,
  `fle` double NOT NULL,
  `nitc` varchar(15) NOT NULL,
  `usuario` varchar(20) NOT NULL,
  `fechaped` date NOT NULL,
  `fecharec` date NOT NULL,
  `observ` text NOT NULL,
  `cumplido` varchar(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `razones` */

DROP TABLE IF EXISTS `razones`;

CREATE TABLE `razones` (
  `id_razon` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_razon` varchar(50) NOT NULL,
  `formula_razon` varchar(100) NOT NULL,
  `criterio` int(11) NOT NULL,
  `minimo` text NOT NULL,
  `maximo` text NOT NULL,
  `concepto1` text NOT NULL,
  `concepto2` text NOT NULL,
  PRIMARY KEY (`id_razon`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Table structure for table `razones_grupo` */

DROP TABLE IF EXISTS `razones_grupo`;

CREATE TABLE `razones_grupo` (
  `id_razon` int(11) NOT NULL,
  `id_gru` varchar(50) NOT NULL,
  PRIMARY KEY (`id_razon`,`id_gru`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `retecree` */

DROP TABLE IF EXISTS `retecree`;

CREATE TABLE `retecree` (
  `codigo` varchar(100) NOT NULL,
  `actividad` text NOT NULL,
  `tarifa` double NOT NULL,
  `cuenta` varchar(15) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `selpuc` */

DROP TABLE IF EXISTS `selpuc`;

CREATE TABLE `selpuc` (
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `descripcion` varchar(100) NOT NULL,
  `naturaleza` varchar(1) NOT NULL DEFAULT 'D',
  `nivel` varchar(12) NOT NULL DEFAULT 'Auxiliar',
  `tipo` varchar(10) NOT NULL DEFAULT 'Activo',
  `saldo` double NOT NULL DEFAULT '0',
  `saldo00` double NOT NULL DEFAULT '0',
  `debito00` double NOT NULL DEFAULT '0',
  `credito00` double NOT NULL DEFAULT '0',
  `debito01` double NOT NULL DEFAULT '0',
  `credito01` double NOT NULL DEFAULT '0',
  `saldo01` double NOT NULL DEFAULT '0',
  `debito02` double NOT NULL DEFAULT '0',
  `credito02` double NOT NULL DEFAULT '0',
  `saldo02` double NOT NULL DEFAULT '0',
  `debito03` double NOT NULL DEFAULT '0',
  `credito03` double NOT NULL DEFAULT '0',
  `saldo03` double NOT NULL DEFAULT '0',
  `debito04` double NOT NULL DEFAULT '0',
  `credito04` double NOT NULL DEFAULT '0',
  `saldo04` double NOT NULL DEFAULT '0',
  `debito05` double NOT NULL DEFAULT '0',
  `credito05` double NOT NULL DEFAULT '0',
  `saldo05` double NOT NULL DEFAULT '0',
  `debito06` double NOT NULL DEFAULT '0',
  `credito06` double NOT NULL DEFAULT '0',
  `saldo06` double NOT NULL DEFAULT '0',
  `debito07` double NOT NULL DEFAULT '0',
  `credito07` double NOT NULL DEFAULT '0',
  `saldo07` double NOT NULL DEFAULT '0',
  `debito08` double NOT NULL DEFAULT '0',
  `credito08` double NOT NULL DEFAULT '0',
  `saldo08` double NOT NULL DEFAULT '0',
  `debito09` double NOT NULL DEFAULT '0',
  `credito09` double NOT NULL DEFAULT '0',
  `saldo09` double NOT NULL DEFAULT '0',
  `debito10` double NOT NULL DEFAULT '0',
  `credito10` double NOT NULL DEFAULT '0',
  `saldo10` double NOT NULL DEFAULT '0',
  `debito11` double NOT NULL DEFAULT '0',
  `credito11` double NOT NULL DEFAULT '0',
  `saldo11` double NOT NULL DEFAULT '0',
  `debito12` double NOT NULL DEFAULT '0',
  `credito12` double NOT NULL DEFAULT '0',
  `saldo12` double NOT NULL DEFAULT '0',
  `tipo_saldo` varchar(2) NOT NULL DEFAULT 'NO',
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `selraz` */

DROP TABLE IF EXISTS `selraz`;

CREATE TABLE `selraz` (
  `id_razon` varchar(10) NOT NULL,
  `nombre_razon` varchar(100) NOT NULL,
  `saldo00` double NOT NULL DEFAULT '0',
  `saldo01` double NOT NULL DEFAULT '0',
  `saldo02` double NOT NULL DEFAULT '0',
  `saldo03` double NOT NULL DEFAULT '0',
  `saldo04` double NOT NULL DEFAULT '0',
  `saldo05` double NOT NULL DEFAULT '0',
  `saldo06` double NOT NULL DEFAULT '0',
  `saldo07` double NOT NULL DEFAULT '0',
  `saldo08` double NOT NULL DEFAULT '0',
  `saldo09` double NOT NULL DEFAULT '0',
  `saldo10` double NOT NULL DEFAULT '0',
  `saldo11` double NOT NULL DEFAULT '0',
  `saldo12` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_razon`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `selvar` */

DROP TABLE IF EXISTS `selvar`;

CREATE TABLE `selvar` (
  `id_var` varchar(100) NOT NULL,
  `nombre_var` varchar(100) NOT NULL,
  `saldo00` double NOT NULL DEFAULT '0',
  `saldo01` double NOT NULL DEFAULT '0',
  `saldo02` double NOT NULL DEFAULT '0',
  `saldo03` double NOT NULL DEFAULT '0',
  `saldo04` double NOT NULL DEFAULT '0',
  `saldo05` double NOT NULL DEFAULT '0',
  `saldo06` double NOT NULL DEFAULT '0',
  `saldo07` double NOT NULL DEFAULT '0',
  `saldo08` double NOT NULL DEFAULT '0',
  `saldo09` double NOT NULL DEFAULT '0',
  `saldo10` double NOT NULL DEFAULT '0',
  `saldo11` double NOT NULL DEFAULT '0',
  `saldo12` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_var`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `seriales` */

DROP TABLE IF EXISTS `seriales`;

CREATE TABLE `seriales` (
  `num` int(11) NOT NULL AUTO_INCREMENT,
  `codart` varchar(15) NOT NULL,
  `serie` varchar(60) NOT NULL,
  `doc_en` varchar(20) NOT NULL,
  `aj_en` varchar(20) NOT NULL,
  `est_en` varchar(2) NOT NULL,
  `doc_sa` varchar(20) NOT NULL,
  `aj_sa` varchar(20) NOT NULL,
  `est_sa` varchar(2) NOT NULL,
  `n` int(11) NOT NULL,
  PRIMARY KEY (`num`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `servicios` */

DROP TABLE IF EXISTS `servicios`;

CREATE TABLE `servicios` (
  `codser` varchar(15) NOT NULL,
  `nombre` varchar(80) NOT NULL,
  `descrip` text NOT NULL,
  `pventa` double NOT NULL,
  `pventa2` double NOT NULL DEFAULT '0',
  `pventa3` double NOT NULL DEFAULT '0',
  `pventa4` double NOT NULL DEFAULT '0',
  `pventa5` double NOT NULL DEFAULT '0',
  `pventa6` double NOT NULL DEFAULT '0',
  `iva` decimal(10,2) NOT NULL,
  `cta_ing` varchar(15) NOT NULL,
  `cta_iva` varchar(15) NOT NULL,
  PRIMARY KEY (`codser`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `terceros` */

DROP TABLE IF EXISTS `terceros`;

CREATE TABLE `terceros` (
  `nit` varchar(20) NOT NULL DEFAULT '',
  `dv` varchar(2) NOT NULL,
  `nombre` varchar(100) NOT NULL DEFAULT '',
  `apellidos` varchar(50) DEFAULT '.',
  `tipo` varchar(20) NOT NULL DEFAULT 'CLIENTES',
  `persona` varchar(20) NOT NULL DEFAULT 'natural',
  `dir` varchar(100) NOT NULL DEFAULT '(ninguna)',
  `pais` varchar(10) NOT NULL,
  `dept` varchar(10) NOT NULL,
  `mun` varchar(10) NOT NULL,
  `telefono` varchar(20) DEFAULT '(ninguno)',
  `celular` varchar(20) DEFAULT '(ninguno)',
  `fax` varchar(20) DEFAULT '(ninguno)',
  `correo` varchar(150) DEFAULT '(ninguno)',
  `web` varchar(150) DEFAULT '(ninguno)',
  `dia` varchar(2) NOT NULL,
  `mes` varchar(15) NOT NULL,
  `contacto` varchar(100) NOT NULL,
  `telconta` varchar(15) NOT NULL,
  `cupo` double NOT NULL,
  `vmto` bigint(20) NOT NULL,
  `iva` varchar(2) NOT NULL,
  `retef` varchar(2) NOT NULL,
  `reteiva` varchar(2) NOT NULL,
  `reteica` varchar(2) NOT NULL,
  `nomina` varchar(5) NOT NULL,
  `retecree` varchar(2) NOT NULL DEFAULT 'NO',
  `act1` varchar(6) NOT NULL DEFAULT '0',
  `act2` varchar(6) NOT NULL DEFAULT '0',
  `act3` varchar(6) NOT NULL DEFAULT '0',
  `act4` varchar(6) NOT NULL DEFAULT '0',
  `cta_banco1` varchar(15) NOT NULL DEFAULT ' ',
  `cbanco` varchar(60) NOT NULL DEFAULT ' ',
  PRIMARY KEY (`nit`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `tercerosinm` */

DROP TABLE IF EXISTS `tercerosinm`;

CREATE TABLE `tercerosinm` (
  `num` int(11) NOT NULL AUTO_INCREMENT,
  `nit` varchar(20) NOT NULL,
  `clase` varchar(20) NOT NULL,
  PRIMARY KEY (`num`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `tipdoc` */

DROP TABLE IF EXISTS `tipdoc`;

CREATE TABLE `tipdoc` (
  `tipodoc` varchar(2) NOT NULL,
  `grupo` varchar(30) NOT NULL,
  `descripcion` varchar(30) NOT NULL,
  `iniciofc` bigint(20) NOT NULL DEFAULT '0',
  `actualfc` bigint(20) NOT NULL DEFAULT '0',
  `inicio01` bigint(20) NOT NULL,
  `actual01` bigint(20) NOT NULL,
  `inicio02` bigint(20) NOT NULL DEFAULT '0',
  `actual02` bigint(20) NOT NULL DEFAULT '0',
  `inicio03` bigint(20) NOT NULL DEFAULT '0',
  `actual03` bigint(20) NOT NULL DEFAULT '0',
  `inicio04` bigint(20) NOT NULL DEFAULT '0',
  `actual04` bigint(20) NOT NULL DEFAULT '0',
  `inicio05` bigint(20) NOT NULL DEFAULT '0',
  `actual05` bigint(20) NOT NULL DEFAULT '0',
  `inicio06` bigint(20) NOT NULL DEFAULT '0',
  `actual06` bigint(20) NOT NULL DEFAULT '0',
  `inicio07` bigint(20) NOT NULL DEFAULT '0',
  `actual07` bigint(20) NOT NULL DEFAULT '0',
  `inicio08` bigint(20) NOT NULL DEFAULT '0',
  `actual08` bigint(20) NOT NULL DEFAULT '0',
  `inicio09` bigint(20) NOT NULL DEFAULT '0',
  `actual09` bigint(20) NOT NULL DEFAULT '0',
  `inicio10` bigint(20) NOT NULL DEFAULT '0',
  `actual10` bigint(20) NOT NULL DEFAULT '0',
  `inicio11` bigint(20) NOT NULL DEFAULT '0',
  `actual11` bigint(20) NOT NULL DEFAULT '0',
  `inicio12` bigint(20) NOT NULL DEFAULT '0',
  `actual12` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`tipodoc`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `tributarios` */

DROP TABLE IF EXISTS `tributarios`;

CREATE TABLE `tributarios` (
  `num` int(11) NOT NULL,
  `detalle` varchar(30) NOT NULL,
  `cuenta1` varchar(15) NOT NULL,
  `cuenta2` varchar(15) NOT NULL,
  `cuenta3` varchar(15) NOT NULL,
  `cuenta4` varchar(15) NOT NULL,
  `cuenta5` varchar(15) NOT NULL,
  `cuenta6` varchar(15) NOT NULL,
  `cuenta7` varchar(15) NOT NULL,
  `cuenta8` varchar(15) NOT NULL,
  `cuenta9` varchar(15) NOT NULL,
  `cuenta10` varchar(15) NOT NULL,
  `cuenta11` varchar(15) NOT NULL,
  `cuenta12` varchar(15) NOT NULL,
  `cuenta13` varchar(15) NOT NULL,
  `cuenta14` varchar(15) NOT NULL,
  `cuenta15` varchar(15) NOT NULL,
  PRIMARY KEY (`num`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `usuarios` */

DROP TABLE IF EXISTS `usuarios`;

CREATE TABLE `usuarios` (
  `username` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `variables` */

DROP TABLE IF EXISTS `variables`;

CREATE TABLE `variables` (
  `id_var` varchar(50) NOT NULL,
  `nombre_var` varchar(50) NOT NULL,
  PRIMARY KEY (`id_var`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `vend_cc` */

DROP TABLE IF EXISTS `vend_cc`;

CREATE TABLE `vend_cc` (
  `nitv` varchar(15) NOT NULL,
  `codcon` int(11) NOT NULL,
  `porcomi` decimal(10,2) NOT NULL,
  `dia_cob` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `vendedores` */

DROP TABLE IF EXISTS `vendedores`;

CREATE TABLE `vendedores` (
  `nitv` varchar(15) NOT NULL,
  `nombre` varchar(70) NOT NULL,
  `dir` varchar(50) NOT NULL,
  `telefono` varchar(15) NOT NULL,
  `estado` varchar(10) NOT NULL,
  `zona` varchar(20) NOT NULL,
  `palm` varchar(2) NOT NULL,
  `codpalm` varchar(20) NOT NULL,
  PRIMARY KEY (`nitv`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `vista_canti` */

DROP TABLE IF EXISTS `vista_canti`;

/*!50001 DROP VIEW IF EXISTS `vista_canti` */;
/*!50001 DROP TABLE IF EXISTS `vista_canti` */;

/*!50001 CREATE TABLE  `vista_canti`(
 `codart` varchar(18) ,
 `nomart` varchar(60) ,
 `desart` text ,
 `nivel` varchar(15) ,
 `referencia` varchar(18) ,
 `codbar` varchar(20) ,
 `cos_uni` double ,
 `cos_pro` double ,
 `margen` decimal(10,2) ,
 `precio` double ,
 `iva` decimal(10,2) ,
 `exento` varchar(2) ,
 `excluido` varchar(2) ,
 `cue_inv` varchar(15) ,
 `cue_ing` varchar(15) ,
 `cue_cos` varchar(15) ,
 `cue_iva_v` varchar(15) ,
 `cue_iva_c` varchar(15) ,
 `cue_dev` varchar(15) ,
 `unidad` varchar(10) ,
 `empaque` double ,
 `can_emp` double ,
 `uni_emp` double ,
 `cant_min` double ,
 `pp` double ,
 `estado` varchar(10) ,
 `con_comi` varchar(20) ,
 `importa` varchar(2) ,
 `num_reg` varchar(20) ,
 `por_ara` decimal(10,2) ,
 `pos_ara` varchar(20) ,
 `p1` varchar(15) ,
 `p2` varchar(15) ,
 `p3` varchar(15) ,
 `p4` varchar(15) ,
 `p5` varchar(15) ,
 `ctotal` varbinary(53) ,
 `mes` varchar(2) 
)*/;

/*Table structure for table `vista_deta_cpp` */

DROP TABLE IF EXISTS `vista_deta_cpp`;

/*!50001 DROP VIEW IF EXISTS `vista_deta_cpp` */;
/*!50001 DROP TABLE IF EXISTS `vista_deta_cpp` */;

/*!50001 CREATE TABLE  `vista_deta_cpp`(
 `doc` varchar(15) ,
 `item` bigint(20) ,
 `tipo_it` char(1) ,
 `cod_art` varchar(18) ,
 `nom_art` text ,
 `num_bod` int(11) ,
 `cantidad` double ,
 `valor` double ,
 `vtotal` double ,
 `por_iva_g` decimal(10,2) ,
 `cta_inv` varchar(15) ,
 `cta_cos` varchar(15) ,
 `cta_gas` varchar(15) ,
 `cta_iva` varchar(15) ,
 `concep` varchar(15) 
)*/;

/*Table structure for table `vista_ot_cpp` */

DROP TABLE IF EXISTS `vista_ot_cpp`;

/*!50001 DROP VIEW IF EXISTS `vista_ot_cpp` */;
/*!50001 DROP TABLE IF EXISTS `vista_ot_cpp` */;

/*!50001 CREATE TABLE  `vista_ot_cpp`(
 `item` bigint(20) ,
 `doc` varchar(15) ,
 `grupo` varchar(2) ,
 `tipo` varchar(4) ,
 `num` bigint(20) ,
 `doc_afec` varchar(15) ,
 `dia` varchar(2) ,
 `periodo` varchar(8) ,
 `ciudad` varchar(30) ,
 `concepto` text ,
 `nitc` varchar(20) ,
 `tn` varchar(4) ,
 `codigo` varchar(18) ,
 `descrip` varchar(100) ,
 `debito` double ,
 `credito` double ,
 `base` double ,
 `total` double ,
 `tipo_pago` varchar(10) ,
 `cheque` varchar(20) ,
 `banco` varchar(50) ,
 `sucursal` varchar(50) ,
 `ccosto` varchar(15) ,
 `fecha` date ,
 `elaborado` varchar(50) ,
 `autorizado` varchar(50) ,
 `revisado` varchar(50) ,
 `contabilizado` varchar(50) ,
 `doc_aj` varchar(30) ,
 `estado` varchar(2) ,
 `abonado` double 
)*/;

/*View structure for view vista_canti */

/*!50001 DROP TABLE IF EXISTS `vista_canti` */;
/*!50001 DROP VIEW IF EXISTS `vista_canti` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_canti` AS select `articulos`.`codart` AS `codart`,`articulos`.`nomart` AS `nomart`,`articulos`.`desart` AS `desart`,`articulos`.`nivel` AS `nivel`,`articulos`.`referencia` AS `referencia`,`articulos`.`codbar` AS `codbar`,`articulos`.`cos_uni` AS `cos_uni`,`articulos`.`cos_pro` AS `cos_pro`,`articulos`.`margen` AS `margen`,`articulos`.`precio` AS `precio`,`articulos`.`iva` AS `iva`,`articulos`.`exento` AS `exento`,`articulos`.`excluido` AS `excluido`,`articulos`.`cue_inv` AS `cue_inv`,`articulos`.`cue_ing` AS `cue_ing`,`articulos`.`cue_cos` AS `cue_cos`,`articulos`.`cue_iva_v` AS `cue_iva_v`,`articulos`.`cue_iva_c` AS `cue_iva_c`,`articulos`.`cue_dev` AS `cue_dev`,`articulos`.`unidad` AS `unidad`,`articulos`.`empaque` AS `empaque`,`articulos`.`can_emp` AS `can_emp`,`articulos`.`uni_emp` AS `uni_emp`,`articulos`.`cant_min` AS `cant_min`,`articulos`.`pp` AS `pp`,`articulos`.`estado` AS `estado`,`articulos`.`con_comi` AS `con_comi`,`articulos`.`importa` AS `importa`,`articulos`.`num_reg` AS `num_reg`,`articulos`.`por_ara` AS `por_ara`,`articulos`.`pos_ara` AS `pos_ara`,`articulos`.`p1` AS `p1`,`articulos`.`p2` AS `p2`,`articulos`.`p3` AS `p3`,`articulos`.`p4` AS `p4`,`articulos`.`p5` AS `p5`,_latin1'0' AS `ctotal`,lpad(month(now()),2,_latin1'0') AS `mes` from `articulos` where (`articulos`.`nivel` <> _utf8'Articulos') union select `a`.`codart` AS `codart`,`a`.`nomart` AS `nomart`,`a`.`desart` AS `desart`,`a`.`nivel` AS `nivel`,`a`.`referencia` AS `referencia`,`a`.`codbar` AS `codbar`,`a`.`cos_uni` AS `cos_uni`,`a`.`cos_pro` AS `cos_pro`,`a`.`margen` AS `margen`,`a`.`precio` AS `precio`,`a`.`iva` AS `iva`,`a`.`exento` AS `exento`,`a`.`excluido` AS `excluido`,`a`.`cue_inv` AS `cue_inv`,`a`.`cue_ing` AS `cue_ing`,`a`.`cue_cos` AS `cue_cos`,`a`.`cue_iva_v` AS `cue_iva_v`,`a`.`cue_iva_c` AS `cue_iva_c`,`a`.`cue_dev` AS `cue_dev`,`a`.`unidad` AS `unidad`,`a`.`empaque` AS `empaque`,`a`.`can_emp` AS `can_emp`,`a`.`uni_emp` AS `uni_emp`,`a`.`cant_min` AS `cant_min`,`a`.`pp` AS `pp`,`a`.`estado` AS `estado`,`a`.`con_comi` AS `con_comi`,`a`.`importa` AS `importa`,`a`.`num_reg` AS `num_reg`,`a`.`por_ara` AS `por_ara`,`a`.`pos_ara` AS `pos_ara`,`a`.`p1` AS `p1`,`a`.`p2` AS `p2`,`a`.`p3` AS `p3`,`a`.`p4` AS `p4`,`a`.`p5` AS `p5`,sum(((((((`c`.`cant1` + `c`.`cant2`) + `c`.`cant3`) + `c`.`cant4`) + `c`.`cant5`) + `c`.`cant6`) + `c`.`cant7`)) AS `ctotal`,lpad(month(now()),2,_latin1'0') AS `mes` from (`articulos` `a` left join `con_inv` `c` on((`a`.`codart` = `c`.`codart`))) where (`c`.`periodo` = lpad(month(now()),2,_latin1'0')) group by `a`.`codart` */;

/*View structure for view vista_deta_cpp */

/*!50001 DROP TABLE IF EXISTS `vista_deta_cpp` */;
/*!50001 DROP VIEW IF EXISTS `vista_deta_cpp` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_deta_cpp` AS select `detacomp01`.`doc` AS `doc`,`detacomp01`.`item` AS `item`,`detacomp01`.`tipo_it` AS `tipo_it`,`detacomp01`.`cod_art` AS `cod_art`,`detacomp01`.`nom_art` AS `nom_art`,`detacomp01`.`num_bod` AS `num_bod`,`detacomp01`.`cantidad` AS `cantidad`,`detacomp01`.`valor` AS `valor`,`detacomp01`.`vtotal` AS `vtotal`,`detacomp01`.`por_iva_g` AS `por_iva_g`,`detacomp01`.`cta_inv` AS `cta_inv`,`detacomp01`.`cta_cos` AS `cta_cos`,`detacomp01`.`cta_gas` AS `cta_gas`,`detacomp01`.`cta_iva` AS `cta_iva`,`detacomp01`.`concep` AS `concep` from `detacomp01` where 1 union select `detacomp02`.`doc` AS `doc`,`detacomp02`.`item` AS `item`,`detacomp02`.`tipo_it` AS `tipo_it`,`detacomp02`.`cod_art` AS `cod_art`,`detacomp02`.`nom_art` AS `nom_art`,`detacomp02`.`num_bod` AS `num_bod`,`detacomp02`.`cantidad` AS `cantidad`,`detacomp02`.`valor` AS `valor`,`detacomp02`.`vtotal` AS `vtotal`,`detacomp02`.`por_iva_g` AS `por_iva_g`,`detacomp02`.`cta_inv` AS `cta_inv`,`detacomp02`.`cta_cos` AS `cta_cos`,`detacomp02`.`cta_gas` AS `cta_gas`,`detacomp02`.`cta_iva` AS `cta_iva`,`detacomp02`.`concep` AS `concep` from `detacomp02` where 1 union select `detacomp03`.`doc` AS `doc`,`detacomp03`.`item` AS `item`,`detacomp03`.`tipo_it` AS `tipo_it`,`detacomp03`.`cod_art` AS `cod_art`,`detacomp03`.`nom_art` AS `nom_art`,`detacomp03`.`num_bod` AS `num_bod`,`detacomp03`.`cantidad` AS `cantidad`,`detacomp03`.`valor` AS `valor`,`detacomp03`.`vtotal` AS `vtotal`,`detacomp03`.`por_iva_g` AS `por_iva_g`,`detacomp03`.`cta_inv` AS `cta_inv`,`detacomp03`.`cta_cos` AS `cta_cos`,`detacomp03`.`cta_gas` AS `cta_gas`,`detacomp03`.`cta_iva` AS `cta_iva`,`detacomp03`.`concep` AS `concep` from `detacomp03` where 1 union select `detacomp04`.`doc` AS `doc`,`detacomp04`.`item` AS `item`,`detacomp04`.`tipo_it` AS `tipo_it`,`detacomp04`.`cod_art` AS `cod_art`,`detacomp04`.`nom_art` AS `nom_art`,`detacomp04`.`num_bod` AS `num_bod`,`detacomp04`.`cantidad` AS `cantidad`,`detacomp04`.`valor` AS `valor`,`detacomp04`.`vtotal` AS `vtotal`,`detacomp04`.`por_iva_g` AS `por_iva_g`,`detacomp04`.`cta_inv` AS `cta_inv`,`detacomp04`.`cta_cos` AS `cta_cos`,`detacomp04`.`cta_gas` AS `cta_gas`,`detacomp04`.`cta_iva` AS `cta_iva`,`detacomp04`.`concep` AS `concep` from `detacomp04` where 1 union select `detacomp05`.`doc` AS `doc`,`detacomp05`.`item` AS `item`,`detacomp05`.`tipo_it` AS `tipo_it`,`detacomp05`.`cod_art` AS `cod_art`,`detacomp05`.`nom_art` AS `nom_art`,`detacomp05`.`num_bod` AS `num_bod`,`detacomp05`.`cantidad` AS `cantidad`,`detacomp05`.`valor` AS `valor`,`detacomp05`.`vtotal` AS `vtotal`,`detacomp05`.`por_iva_g` AS `por_iva_g`,`detacomp05`.`cta_inv` AS `cta_inv`,`detacomp05`.`cta_cos` AS `cta_cos`,`detacomp05`.`cta_gas` AS `cta_gas`,`detacomp05`.`cta_iva` AS `cta_iva`,`detacomp05`.`concep` AS `concep` from `detacomp05` where 1 union select `detacomp06`.`doc` AS `doc`,`detacomp06`.`item` AS `item`,`detacomp06`.`tipo_it` AS `tipo_it`,`detacomp06`.`cod_art` AS `cod_art`,`detacomp06`.`nom_art` AS `nom_art`,`detacomp06`.`num_bod` AS `num_bod`,`detacomp06`.`cantidad` AS `cantidad`,`detacomp06`.`valor` AS `valor`,`detacomp06`.`vtotal` AS `vtotal`,`detacomp06`.`por_iva_g` AS `por_iva_g`,`detacomp06`.`cta_inv` AS `cta_inv`,`detacomp06`.`cta_cos` AS `cta_cos`,`detacomp06`.`cta_gas` AS `cta_gas`,`detacomp06`.`cta_iva` AS `cta_iva`,`detacomp06`.`concep` AS `concep` from `detacomp06` where 1 union select `detacomp07`.`doc` AS `doc`,`detacomp07`.`item` AS `item`,`detacomp07`.`tipo_it` AS `tipo_it`,`detacomp07`.`cod_art` AS `cod_art`,`detacomp07`.`nom_art` AS `nom_art`,`detacomp07`.`num_bod` AS `num_bod`,`detacomp07`.`cantidad` AS `cantidad`,`detacomp07`.`valor` AS `valor`,`detacomp07`.`vtotal` AS `vtotal`,`detacomp07`.`por_iva_g` AS `por_iva_g`,`detacomp07`.`cta_inv` AS `cta_inv`,`detacomp07`.`cta_cos` AS `cta_cos`,`detacomp07`.`cta_gas` AS `cta_gas`,`detacomp07`.`cta_iva` AS `cta_iva`,`detacomp07`.`concep` AS `concep` from `detacomp07` where 1 union select `detacomp08`.`doc` AS `doc`,`detacomp08`.`item` AS `item`,`detacomp08`.`tipo_it` AS `tipo_it`,`detacomp08`.`cod_art` AS `cod_art`,`detacomp08`.`nom_art` AS `nom_art`,`detacomp08`.`num_bod` AS `num_bod`,`detacomp08`.`cantidad` AS `cantidad`,`detacomp08`.`valor` AS `valor`,`detacomp08`.`vtotal` AS `vtotal`,`detacomp08`.`por_iva_g` AS `por_iva_g`,`detacomp08`.`cta_inv` AS `cta_inv`,`detacomp08`.`cta_cos` AS `cta_cos`,`detacomp08`.`cta_gas` AS `cta_gas`,`detacomp08`.`cta_iva` AS `cta_iva`,`detacomp08`.`concep` AS `concep` from `detacomp08` where 1 union select `detacomp09`.`doc` AS `doc`,`detacomp09`.`item` AS `item`,`detacomp09`.`tipo_it` AS `tipo_it`,`detacomp09`.`cod_art` AS `cod_art`,`detacomp09`.`nom_art` AS `nom_art`,`detacomp09`.`num_bod` AS `num_bod`,`detacomp09`.`cantidad` AS `cantidad`,`detacomp09`.`valor` AS `valor`,`detacomp09`.`vtotal` AS `vtotal`,`detacomp09`.`por_iva_g` AS `por_iva_g`,`detacomp09`.`cta_inv` AS `cta_inv`,`detacomp09`.`cta_cos` AS `cta_cos`,`detacomp09`.`cta_gas` AS `cta_gas`,`detacomp09`.`cta_iva` AS `cta_iva`,`detacomp09`.`concep` AS `concep` from `detacomp09` where 1 union select `detacomp10`.`doc` AS `doc`,`detacomp10`.`item` AS `item`,`detacomp10`.`tipo_it` AS `tipo_it`,`detacomp10`.`cod_art` AS `cod_art`,`detacomp10`.`nom_art` AS `nom_art`,`detacomp10`.`num_bod` AS `num_bod`,`detacomp10`.`cantidad` AS `cantidad`,`detacomp10`.`valor` AS `valor`,`detacomp10`.`vtotal` AS `vtotal`,`detacomp10`.`por_iva_g` AS `por_iva_g`,`detacomp10`.`cta_inv` AS `cta_inv`,`detacomp10`.`cta_cos` AS `cta_cos`,`detacomp10`.`cta_gas` AS `cta_gas`,`detacomp10`.`cta_iva` AS `cta_iva`,`detacomp10`.`concep` AS `concep` from `detacomp10` where 1 union select `detacomp11`.`doc` AS `doc`,`detacomp11`.`item` AS `item`,`detacomp11`.`tipo_it` AS `tipo_it`,`detacomp11`.`cod_art` AS `cod_art`,`detacomp11`.`nom_art` AS `nom_art`,`detacomp11`.`num_bod` AS `num_bod`,`detacomp11`.`cantidad` AS `cantidad`,`detacomp11`.`valor` AS `valor`,`detacomp11`.`vtotal` AS `vtotal`,`detacomp11`.`por_iva_g` AS `por_iva_g`,`detacomp11`.`cta_inv` AS `cta_inv`,`detacomp11`.`cta_cos` AS `cta_cos`,`detacomp11`.`cta_gas` AS `cta_gas`,`detacomp11`.`cta_iva` AS `cta_iva`,`detacomp11`.`concep` AS `concep` from `detacomp11` where 1 union select `detacomp12`.`doc` AS `doc`,`detacomp12`.`item` AS `item`,`detacomp12`.`tipo_it` AS `tipo_it`,`detacomp12`.`cod_art` AS `cod_art`,`detacomp12`.`nom_art` AS `nom_art`,`detacomp12`.`num_bod` AS `num_bod`,`detacomp12`.`cantidad` AS `cantidad`,`detacomp12`.`valor` AS `valor`,`detacomp12`.`vtotal` AS `vtotal`,`detacomp12`.`por_iva_g` AS `por_iva_g`,`detacomp12`.`cta_inv` AS `cta_inv`,`detacomp12`.`cta_cos` AS `cta_cos`,`detacomp12`.`cta_gas` AS `cta_gas`,`detacomp12`.`cta_iva` AS `cta_iva`,`detacomp12`.`concep` AS `concep` from `detacomp12` where 1 */;

/*View structure for view vista_ot_cpp */

/*!50001 DROP TABLE IF EXISTS `vista_ot_cpp` */;
/*!50001 DROP VIEW IF EXISTS `vista_ot_cpp` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_ot_cpp` AS select `ot_cpp01`.`item` AS `item`,`ot_cpp01`.`doc` AS `doc`,`ot_cpp01`.`grupo` AS `grupo`,`ot_cpp01`.`tipo` AS `tipo`,`ot_cpp01`.`num` AS `num`,`ot_cpp01`.`doc_afec` AS `doc_afec`,`ot_cpp01`.`dia` AS `dia`,`ot_cpp01`.`periodo` AS `periodo`,`ot_cpp01`.`ciudad` AS `ciudad`,`ot_cpp01`.`concepto` AS `concepto`,`ot_cpp01`.`nitc` AS `nitc`,`ot_cpp01`.`tn` AS `tn`,`ot_cpp01`.`codigo` AS `codigo`,`ot_cpp01`.`descrip` AS `descrip`,`ot_cpp01`.`debito` AS `debito`,`ot_cpp01`.`credito` AS `credito`,`ot_cpp01`.`base` AS `base`,`ot_cpp01`.`total` AS `total`,`ot_cpp01`.`tipo_pago` AS `tipo_pago`,`ot_cpp01`.`cheque` AS `cheque`,`ot_cpp01`.`banco` AS `banco`,`ot_cpp01`.`sucursal` AS `sucursal`,`ot_cpp01`.`ccosto` AS `ccosto`,`ot_cpp01`.`fecha` AS `fecha`,`ot_cpp01`.`elaborado` AS `elaborado`,`ot_cpp01`.`autorizado` AS `autorizado`,`ot_cpp01`.`revisado` AS `revisado`,`ot_cpp01`.`contabilizado` AS `contabilizado`,`ot_cpp01`.`doc_aj` AS `doc_aj`,`ot_cpp01`.`estado` AS `estado`,`ot_cpp01`.`abonado` AS `abonado` from `ot_cpp01` where 1 union select `ot_cpp02`.`item` AS `item`,`ot_cpp02`.`doc` AS `doc`,`ot_cpp02`.`grupo` AS `grupo`,`ot_cpp02`.`tipo` AS `tipo`,`ot_cpp02`.`num` AS `num`,`ot_cpp02`.`doc_afec` AS `doc_afec`,`ot_cpp02`.`dia` AS `dia`,`ot_cpp02`.`periodo` AS `periodo`,`ot_cpp02`.`ciudad` AS `ciudad`,`ot_cpp02`.`concepto` AS `concepto`,`ot_cpp02`.`nitc` AS `nitc`,`ot_cpp02`.`tn` AS `tn`,`ot_cpp02`.`codigo` AS `codigo`,`ot_cpp02`.`descrip` AS `descrip`,`ot_cpp02`.`debito` AS `debito`,`ot_cpp02`.`credito` AS `credito`,`ot_cpp02`.`base` AS `base`,`ot_cpp02`.`total` AS `total`,`ot_cpp02`.`tipo_pago` AS `tipo_pago`,`ot_cpp02`.`cheque` AS `cheque`,`ot_cpp02`.`banco` AS `banco`,`ot_cpp02`.`sucursal` AS `sucursal`,`ot_cpp02`.`ccosto` AS `ccosto`,`ot_cpp02`.`fecha` AS `fecha`,`ot_cpp02`.`elaborado` AS `elaborado`,`ot_cpp02`.`autorizado` AS `autorizado`,`ot_cpp02`.`revisado` AS `revisado`,`ot_cpp02`.`contabilizado` AS `contabilizado`,`ot_cpp02`.`doc_aj` AS `doc_aj`,`ot_cpp02`.`estado` AS `estado`,`ot_cpp02`.`abonado` AS `abonado` from `ot_cpp02` where 1 union select `ot_cpp03`.`item` AS `item`,`ot_cpp03`.`doc` AS `doc`,`ot_cpp03`.`grupo` AS `grupo`,`ot_cpp03`.`tipo` AS `tipo`,`ot_cpp03`.`num` AS `num`,`ot_cpp03`.`doc_afec` AS `doc_afec`,`ot_cpp03`.`dia` AS `dia`,`ot_cpp03`.`periodo` AS `periodo`,`ot_cpp03`.`ciudad` AS `ciudad`,`ot_cpp03`.`concepto` AS `concepto`,`ot_cpp03`.`nitc` AS `nitc`,`ot_cpp03`.`tn` AS `tn`,`ot_cpp03`.`codigo` AS `codigo`,`ot_cpp03`.`descrip` AS `descrip`,`ot_cpp03`.`debito` AS `debito`,`ot_cpp03`.`credito` AS `credito`,`ot_cpp03`.`base` AS `base`,`ot_cpp03`.`total` AS `total`,`ot_cpp03`.`tipo_pago` AS `tipo_pago`,`ot_cpp03`.`cheque` AS `cheque`,`ot_cpp03`.`banco` AS `banco`,`ot_cpp03`.`sucursal` AS `sucursal`,`ot_cpp03`.`ccosto` AS `ccosto`,`ot_cpp03`.`fecha` AS `fecha`,`ot_cpp03`.`elaborado` AS `elaborado`,`ot_cpp03`.`autorizado` AS `autorizado`,`ot_cpp03`.`revisado` AS `revisado`,`ot_cpp03`.`contabilizado` AS `contabilizado`,`ot_cpp03`.`doc_aj` AS `doc_aj`,`ot_cpp03`.`estado` AS `estado`,`ot_cpp03`.`abonado` AS `abonado` from `ot_cpp03` where 1 union select `ot_cpp04`.`item` AS `item`,`ot_cpp04`.`doc` AS `doc`,`ot_cpp04`.`grupo` AS `grupo`,`ot_cpp04`.`tipo` AS `tipo`,`ot_cpp04`.`num` AS `num`,`ot_cpp04`.`doc_afec` AS `doc_afec`,`ot_cpp04`.`dia` AS `dia`,`ot_cpp04`.`periodo` AS `periodo`,`ot_cpp04`.`ciudad` AS `ciudad`,`ot_cpp04`.`concepto` AS `concepto`,`ot_cpp04`.`nitc` AS `nitc`,`ot_cpp04`.`tn` AS `tn`,`ot_cpp04`.`codigo` AS `codigo`,`ot_cpp04`.`descrip` AS `descrip`,`ot_cpp04`.`debito` AS `debito`,`ot_cpp04`.`credito` AS `credito`,`ot_cpp04`.`base` AS `base`,`ot_cpp04`.`total` AS `total`,`ot_cpp04`.`tipo_pago` AS `tipo_pago`,`ot_cpp04`.`cheque` AS `cheque`,`ot_cpp04`.`banco` AS `banco`,`ot_cpp04`.`sucursal` AS `sucursal`,`ot_cpp04`.`ccosto` AS `ccosto`,`ot_cpp04`.`fecha` AS `fecha`,`ot_cpp04`.`elaborado` AS `elaborado`,`ot_cpp04`.`autorizado` AS `autorizado`,`ot_cpp04`.`revisado` AS `revisado`,`ot_cpp04`.`contabilizado` AS `contabilizado`,`ot_cpp04`.`doc_aj` AS `doc_aj`,`ot_cpp04`.`estado` AS `estado`,`ot_cpp04`.`abonado` AS `abonado` from `ot_cpp04` where 1 union select `ot_cpp05`.`item` AS `item`,`ot_cpp05`.`doc` AS `doc`,`ot_cpp05`.`grupo` AS `grupo`,`ot_cpp05`.`tipo` AS `tipo`,`ot_cpp05`.`num` AS `num`,`ot_cpp05`.`doc_afec` AS `doc_afec`,`ot_cpp05`.`dia` AS `dia`,`ot_cpp05`.`periodo` AS `periodo`,`ot_cpp05`.`ciudad` AS `ciudad`,`ot_cpp05`.`concepto` AS `concepto`,`ot_cpp05`.`nitc` AS `nitc`,`ot_cpp05`.`tn` AS `tn`,`ot_cpp05`.`codigo` AS `codigo`,`ot_cpp05`.`descrip` AS `descrip`,`ot_cpp05`.`debito` AS `debito`,`ot_cpp05`.`credito` AS `credito`,`ot_cpp05`.`base` AS `base`,`ot_cpp05`.`total` AS `total`,`ot_cpp05`.`tipo_pago` AS `tipo_pago`,`ot_cpp05`.`cheque` AS `cheque`,`ot_cpp05`.`banco` AS `banco`,`ot_cpp05`.`sucursal` AS `sucursal`,`ot_cpp05`.`ccosto` AS `ccosto`,`ot_cpp05`.`fecha` AS `fecha`,`ot_cpp05`.`elaborado` AS `elaborado`,`ot_cpp05`.`autorizado` AS `autorizado`,`ot_cpp05`.`revisado` AS `revisado`,`ot_cpp05`.`contabilizado` AS `contabilizado`,`ot_cpp05`.`doc_aj` AS `doc_aj`,`ot_cpp05`.`estado` AS `estado`,`ot_cpp05`.`abonado` AS `abonado` from `ot_cpp05` where 1 union select `ot_cpp06`.`item` AS `item`,`ot_cpp06`.`doc` AS `doc`,`ot_cpp06`.`grupo` AS `grupo`,`ot_cpp06`.`tipo` AS `tipo`,`ot_cpp06`.`num` AS `num`,`ot_cpp06`.`doc_afec` AS `doc_afec`,`ot_cpp06`.`dia` AS `dia`,`ot_cpp06`.`periodo` AS `periodo`,`ot_cpp06`.`ciudad` AS `ciudad`,`ot_cpp06`.`concepto` AS `concepto`,`ot_cpp06`.`nitc` AS `nitc`,`ot_cpp06`.`tn` AS `tn`,`ot_cpp06`.`codigo` AS `codigo`,`ot_cpp06`.`descrip` AS `descrip`,`ot_cpp06`.`debito` AS `debito`,`ot_cpp06`.`credito` AS `credito`,`ot_cpp06`.`base` AS `base`,`ot_cpp06`.`total` AS `total`,`ot_cpp06`.`tipo_pago` AS `tipo_pago`,`ot_cpp06`.`cheque` AS `cheque`,`ot_cpp06`.`banco` AS `banco`,`ot_cpp06`.`sucursal` AS `sucursal`,`ot_cpp06`.`ccosto` AS `ccosto`,`ot_cpp06`.`fecha` AS `fecha`,`ot_cpp06`.`elaborado` AS `elaborado`,`ot_cpp06`.`autorizado` AS `autorizado`,`ot_cpp06`.`revisado` AS `revisado`,`ot_cpp06`.`contabilizado` AS `contabilizado`,`ot_cpp06`.`doc_aj` AS `doc_aj`,`ot_cpp06`.`estado` AS `estado`,`ot_cpp06`.`abonado` AS `abonado` from `ot_cpp06` where 1 union select `ot_cpp07`.`item` AS `item`,`ot_cpp07`.`doc` AS `doc`,`ot_cpp07`.`grupo` AS `grupo`,`ot_cpp07`.`tipo` AS `tipo`,`ot_cpp07`.`num` AS `num`,`ot_cpp07`.`doc_afec` AS `doc_afec`,`ot_cpp07`.`dia` AS `dia`,`ot_cpp07`.`periodo` AS `periodo`,`ot_cpp07`.`ciudad` AS `ciudad`,`ot_cpp07`.`concepto` AS `concepto`,`ot_cpp07`.`nitc` AS `nitc`,`ot_cpp07`.`tn` AS `tn`,`ot_cpp07`.`codigo` AS `codigo`,`ot_cpp07`.`descrip` AS `descrip`,`ot_cpp07`.`debito` AS `debito`,`ot_cpp07`.`credito` AS `credito`,`ot_cpp07`.`base` AS `base`,`ot_cpp07`.`total` AS `total`,`ot_cpp07`.`tipo_pago` AS `tipo_pago`,`ot_cpp07`.`cheque` AS `cheque`,`ot_cpp07`.`banco` AS `banco`,`ot_cpp07`.`sucursal` AS `sucursal`,`ot_cpp07`.`ccosto` AS `ccosto`,`ot_cpp07`.`fecha` AS `fecha`,`ot_cpp07`.`elaborado` AS `elaborado`,`ot_cpp07`.`autorizado` AS `autorizado`,`ot_cpp07`.`revisado` AS `revisado`,`ot_cpp07`.`contabilizado` AS `contabilizado`,`ot_cpp07`.`doc_aj` AS `doc_aj`,`ot_cpp07`.`estado` AS `estado`,`ot_cpp07`.`abonado` AS `abonado` from `ot_cpp07` where 1 union select `ot_cpp08`.`item` AS `item`,`ot_cpp08`.`doc` AS `doc`,`ot_cpp08`.`grupo` AS `grupo`,`ot_cpp08`.`tipo` AS `tipo`,`ot_cpp08`.`num` AS `num`,`ot_cpp08`.`doc_afec` AS `doc_afec`,`ot_cpp08`.`dia` AS `dia`,`ot_cpp08`.`periodo` AS `periodo`,`ot_cpp08`.`ciudad` AS `ciudad`,`ot_cpp08`.`concepto` AS `concepto`,`ot_cpp08`.`nitc` AS `nitc`,`ot_cpp08`.`tn` AS `tn`,`ot_cpp08`.`codigo` AS `codigo`,`ot_cpp08`.`descrip` AS `descrip`,`ot_cpp08`.`debito` AS `debito`,`ot_cpp08`.`credito` AS `credito`,`ot_cpp08`.`base` AS `base`,`ot_cpp08`.`total` AS `total`,`ot_cpp08`.`tipo_pago` AS `tipo_pago`,`ot_cpp08`.`cheque` AS `cheque`,`ot_cpp08`.`banco` AS `banco`,`ot_cpp08`.`sucursal` AS `sucursal`,`ot_cpp08`.`ccosto` AS `ccosto`,`ot_cpp08`.`fecha` AS `fecha`,`ot_cpp08`.`elaborado` AS `elaborado`,`ot_cpp08`.`autorizado` AS `autorizado`,`ot_cpp08`.`revisado` AS `revisado`,`ot_cpp08`.`contabilizado` AS `contabilizado`,`ot_cpp08`.`doc_aj` AS `doc_aj`,`ot_cpp08`.`estado` AS `estado`,`ot_cpp08`.`abonado` AS `abonado` from `ot_cpp08` where 1 union select `ot_cpp09`.`item` AS `item`,`ot_cpp09`.`doc` AS `doc`,`ot_cpp09`.`grupo` AS `grupo`,`ot_cpp09`.`tipo` AS `tipo`,`ot_cpp09`.`num` AS `num`,`ot_cpp09`.`doc_afec` AS `doc_afec`,`ot_cpp09`.`dia` AS `dia`,`ot_cpp09`.`periodo` AS `periodo`,`ot_cpp09`.`ciudad` AS `ciudad`,`ot_cpp09`.`concepto` AS `concepto`,`ot_cpp09`.`nitc` AS `nitc`,`ot_cpp09`.`tn` AS `tn`,`ot_cpp09`.`codigo` AS `codigo`,`ot_cpp09`.`descrip` AS `descrip`,`ot_cpp09`.`debito` AS `debito`,`ot_cpp09`.`credito` AS `credito`,`ot_cpp09`.`base` AS `base`,`ot_cpp09`.`total` AS `total`,`ot_cpp09`.`tipo_pago` AS `tipo_pago`,`ot_cpp09`.`cheque` AS `cheque`,`ot_cpp09`.`banco` AS `banco`,`ot_cpp09`.`sucursal` AS `sucursal`,`ot_cpp09`.`ccosto` AS `ccosto`,`ot_cpp09`.`fecha` AS `fecha`,`ot_cpp09`.`elaborado` AS `elaborado`,`ot_cpp09`.`autorizado` AS `autorizado`,`ot_cpp09`.`revisado` AS `revisado`,`ot_cpp09`.`contabilizado` AS `contabilizado`,`ot_cpp09`.`doc_aj` AS `doc_aj`,`ot_cpp09`.`estado` AS `estado`,`ot_cpp09`.`abonado` AS `abonado` from `ot_cpp09` where 1 union select `ot_cpp10`.`item` AS `item`,`ot_cpp10`.`doc` AS `doc`,`ot_cpp10`.`grupo` AS `grupo`,`ot_cpp10`.`tipo` AS `tipo`,`ot_cpp10`.`num` AS `num`,`ot_cpp10`.`doc_afec` AS `doc_afec`,`ot_cpp10`.`dia` AS `dia`,`ot_cpp10`.`periodo` AS `periodo`,`ot_cpp10`.`ciudad` AS `ciudad`,`ot_cpp10`.`concepto` AS `concepto`,`ot_cpp10`.`nitc` AS `nitc`,`ot_cpp10`.`tn` AS `tn`,`ot_cpp10`.`codigo` AS `codigo`,`ot_cpp10`.`descrip` AS `descrip`,`ot_cpp10`.`debito` AS `debito`,`ot_cpp10`.`credito` AS `credito`,`ot_cpp10`.`base` AS `base`,`ot_cpp10`.`total` AS `total`,`ot_cpp10`.`tipo_pago` AS `tipo_pago`,`ot_cpp10`.`cheque` AS `cheque`,`ot_cpp10`.`banco` AS `banco`,`ot_cpp10`.`sucursal` AS `sucursal`,`ot_cpp10`.`ccosto` AS `ccosto`,`ot_cpp10`.`fecha` AS `fecha`,`ot_cpp10`.`elaborado` AS `elaborado`,`ot_cpp10`.`autorizado` AS `autorizado`,`ot_cpp10`.`revisado` AS `revisado`,`ot_cpp10`.`contabilizado` AS `contabilizado`,`ot_cpp10`.`doc_aj` AS `doc_aj`,`ot_cpp10`.`estado` AS `estado`,`ot_cpp10`.`abonado` AS `abonado` from `ot_cpp10` where 1 union select `ot_cpp11`.`item` AS `item`,`ot_cpp11`.`doc` AS `doc`,`ot_cpp11`.`grupo` AS `grupo`,`ot_cpp11`.`tipo` AS `tipo`,`ot_cpp11`.`num` AS `num`,`ot_cpp11`.`doc_afec` AS `doc_afec`,`ot_cpp11`.`dia` AS `dia`,`ot_cpp11`.`periodo` AS `periodo`,`ot_cpp11`.`ciudad` AS `ciudad`,`ot_cpp11`.`concepto` AS `concepto`,`ot_cpp11`.`nitc` AS `nitc`,`ot_cpp11`.`tn` AS `tn`,`ot_cpp11`.`codigo` AS `codigo`,`ot_cpp11`.`descrip` AS `descrip`,`ot_cpp11`.`debito` AS `debito`,`ot_cpp11`.`credito` AS `credito`,`ot_cpp11`.`base` AS `base`,`ot_cpp11`.`total` AS `total`,`ot_cpp11`.`tipo_pago` AS `tipo_pago`,`ot_cpp11`.`cheque` AS `cheque`,`ot_cpp11`.`banco` AS `banco`,`ot_cpp11`.`sucursal` AS `sucursal`,`ot_cpp11`.`ccosto` AS `ccosto`,`ot_cpp11`.`fecha` AS `fecha`,`ot_cpp11`.`elaborado` AS `elaborado`,`ot_cpp11`.`autorizado` AS `autorizado`,`ot_cpp11`.`revisado` AS `revisado`,`ot_cpp11`.`contabilizado` AS `contabilizado`,`ot_cpp11`.`doc_aj` AS `doc_aj`,`ot_cpp11`.`estado` AS `estado`,`ot_cpp11`.`abonado` AS `abonado` from `ot_cpp11` where 1 union select `ot_cpp12`.`item` AS `item`,`ot_cpp12`.`doc` AS `doc`,`ot_cpp12`.`grupo` AS `grupo`,`ot_cpp12`.`tipo` AS `tipo`,`ot_cpp12`.`num` AS `num`,`ot_cpp12`.`doc_afec` AS `doc_afec`,`ot_cpp12`.`dia` AS `dia`,`ot_cpp12`.`periodo` AS `periodo`,`ot_cpp12`.`ciudad` AS `ciudad`,`ot_cpp12`.`concepto` AS `concepto`,`ot_cpp12`.`nitc` AS `nitc`,`ot_cpp12`.`tn` AS `tn`,`ot_cpp12`.`codigo` AS `codigo`,`ot_cpp12`.`descrip` AS `descrip`,`ot_cpp12`.`debito` AS `debito`,`ot_cpp12`.`credito` AS `credito`,`ot_cpp12`.`base` AS `base`,`ot_cpp12`.`total` AS `total`,`ot_cpp12`.`tipo_pago` AS `tipo_pago`,`ot_cpp12`.`cheque` AS `cheque`,`ot_cpp12`.`banco` AS `banco`,`ot_cpp12`.`sucursal` AS `sucursal`,`ot_cpp12`.`ccosto` AS `ccosto`,`ot_cpp12`.`fecha` AS `fecha`,`ot_cpp12`.`elaborado` AS `elaborado`,`ot_cpp12`.`autorizado` AS `autorizado`,`ot_cpp12`.`revisado` AS `revisado`,`ot_cpp12`.`contabilizado` AS `contabilizado`,`ot_cpp12`.`doc_aj` AS `doc_aj`,`ot_cpp12`.`estado` AS `estado`,`ot_cpp12`.`abonado` AS `abonado` from `ot_cpp12` where 1 */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
