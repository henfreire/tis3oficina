/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE IF NOT EXISTS `oficina` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `oficina`;

CREATE TABLE IF NOT EXISTS `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `cpf` varchar(14) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `endereco` varchar(50) DEFAULT NULL,
  `observacao` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `item_orcamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  `total` double DEFAULT NULL,
  `observacao` varchar(50) DEFAULT NULL,
  `idPeca` int(11) DEFAULT NULL,
  `idServico` int(11) DEFAULT NULL,
  `idOrcamento` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_itemorcamento_pecas` (`idPeca`),
  KEY `FK_itemorcamento_servico` (`idServico`),
  KEY `FK_itemorcamento_orcamento` (`idOrcamento`),
  CONSTRAINT `FK_itemorcamento_orcamento` FOREIGN KEY (`idOrcamento`) REFERENCES `orcamento` (`CodOrc`),
  CONSTRAINT `FK_itemorcamento_pecas` FOREIGN KEY (`idPeca`) REFERENCES `pecas` (`CodPec`),
  CONSTRAINT `FK_itemorcamento_servico` FOREIGN KEY (`idServico`) REFERENCES `servico` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `orcamento` (
  `CodOrc` int(10) NOT NULL AUTO_INCREMENT,
  `QtdeItens` varchar(3) DEFAULT NULL,
  `TotOrc` varchar(7) DEFAULT NULL,
  `IdCliente` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodOrc`),
  KEY `FK_orcamento_cliente` (`IdCliente`),
  CONSTRAINT `FK_orcamento_cliente` FOREIGN KEY (`IdCliente`) REFERENCES `cliente` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `pecas` (
  `CodPec` int(11) NOT NULL AUTO_INCREMENT,
  `NomePec` varchar(100) DEFAULT NULL,
  `QtdePec` int(11) DEFAULT NULL,
  `ValPec` double DEFAULT NULL,
  PRIMARY KEY (`CodPec`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `servico` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `nomeServico` varchar(100) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
