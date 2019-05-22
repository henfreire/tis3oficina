-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.1.38-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              10.1.0.5464
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para oficina
CREATE DATABASE IF NOT EXISTS `oficina` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `oficina`;

-- Copiando estrutura para tabela oficina.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `cpf` varchar(14) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `endereco` varchar(50) DEFAULT NULL,
  `observacao` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela oficina.cliente: ~1 rows (aproximadamente)
DELETE FROM `cliente`;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` (`id`, `nome`, `cpf`, `telefone`, `email`, `endereco`, `observacao`) VALUES
	(1, 'OICNAOsncoi', '12048689647', '31993799016', 'caosij@oascmio.com', 'Riuahsiu', 'iuasbiasub');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;

-- Copiando estrutura para tabela oficina.item_orcamento
CREATE TABLE IF NOT EXISTS `item_orcamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `valor` double DEFAULT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela oficina.item_orcamento: ~0 rows (aproximadamente)
DELETE FROM `item_orcamento`;
/*!40000 ALTER TABLE `item_orcamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `item_orcamento` ENABLE KEYS */;

-- Copiando estrutura para tabela oficina.orcamento
CREATE TABLE IF NOT EXISTS `orcamento` (
  `CodOrc` int(10) NOT NULL AUTO_INCREMENT,
  `QtdeItens` varchar(3) DEFAULT NULL,
  `TotOrc` varchar(7) DEFAULT NULL,
  `IdCliente` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodOrc`),
  KEY `FK_orcamento_cliente` (`IdCliente`),
  CONSTRAINT `FK_orcamento_cliente` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela oficina.orcamento: ~0 rows (aproximadamente)
DELETE FROM `orcamento`;
/*!40000 ALTER TABLE `orcamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `orcamento` ENABLE KEYS */;

-- Copiando estrutura para tabela oficina.pecas
CREATE TABLE IF NOT EXISTS `pecas` (
  `CodPec` int(11) NOT NULL AUTO_INCREMENT,
  `NomePec` varchar(100) DEFAULT NULL,
  `QtdePec` int(11) DEFAULT NULL,
  `ValPec` double DEFAULT NULL,
  PRIMARY KEY (`CodPec`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela oficina.pecas: ~2 rows (aproximadamente)
DELETE FROM `pecas`;
/*!40000 ALTER TABLE `pecas` DISABLE KEYS */;
INSERT INTO `pecas` (`CodPec`, `NomePec`, `QtdePec`, `ValPec`) VALUES
	(24, 'Vela', 1, 65765),
	(25, 'Rebimboca da parafuseta', 11, 0.06);
/*!40000 ALTER TABLE `pecas` ENABLE KEYS */;

-- Copiando estrutura para tabela oficina.servico
CREATE TABLE IF NOT EXISTS `servico` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `nomeServico` varchar(100) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela oficina.servico: ~3 rows (aproximadamente)
DELETE FROM `servico`;
/*!40000 ALTER TABLE `servico` DISABLE KEYS */;
INSERT INTO `servico` (`id`, `nomeServico`, `valor`) VALUES
	(1, 'oi', 188),
	(2, 'Trocar Peneu', 30),
	(3, 'Pintura', 200);
/*!40000 ALTER TABLE `servico` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
