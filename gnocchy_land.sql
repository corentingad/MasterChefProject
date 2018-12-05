-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mer. 05 déc. 2018 à 09:54
-- Version du serveur :  5.7.19
-- Version de PHP :  7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `gnocchy_land`
--

-- --------------------------------------------------------

--
-- Structure de la table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
CREATE TABLE IF NOT EXISTS `ingredients` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Quantite` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `ingredients`
--

INSERT INTO `ingredients` (`Id`, `Nom`, `Quantite`) VALUES
(1, 'Gaspachio ', 150),
(2, 'Salade', 50),
(3, 'Vinaigrette', 50),
(4, 'Gesier ', 50),
(5, 'Patté', 50),
(6, 'Cornichon ', 100),
(7, 'Jambon', 150),
(8, 'Rosette', 100),
(9, 'Chorizo', 100),
(10, 'Melon', 50),
(11, 'Jambon fume', 50),
(12, 'Petit cornichon', 300),
(13, 'Patte croute', 50),
(14, 'Tomate', 75),
(15, 'Huile d\'olive', 100),
(16, 'Sel ', 1000),
(17, 'Poivre', 1000),
(18, 'Riz ', 200),
(19, 'Thon', 50),
(20, 'Mais', 50),
(21, 'Saumon', 80),
(22, 'Pain', 200),
(23, 'Beurre', 50),
(24, 'Gnocchi ', 2000),
(25, 'Persil', 150),
(26, 'Bolognaise', 100),
(27, 'Crème Fraiche', 200),
(28, 'Lardon', 200),
(29, 'Champignon', 200),
(30, 'Oignon', 1000),
(31, 'Curry', 100),
(32, 'Poulet', 400),
(33, 'Fromage Raclette', 300),
(34, 'Fromage de chèvre', 200),
(35, 'Miel', 100),
(36, 'Pesto', 100),
(37, 'Boeuf', 100),
(38, 'Sauce au poivre', 100),
(39, 'Faisant ', 50),
(40, 'Sauce au vin rouge', 50),
(41, 'Légume couscous', 100),
(42, 'Agneau', 100),
(43, 'Merguez ', 100),
(44, 'Epice', 100),
(45, 'Poivron', 100),
(46, 'Glace Vanille', 100),
(47, 'Glace Chocolat', 100),
(48, 'Glace Fraise', 100),
(49, 'Pastèque', 50),
(50, 'Pate a crepe', 100),
(51, 'Creme brule', 100),
(52, 'Nutella', 100),
(53, 'Confiture de fraise', 80),
(54, 'Caramel au beurre sale', 100),
(55, 'Comte', 75),
(56, 'Brie', 75),
(57, 'Tome', 75),
(58, 'Framboise', 80),
(59, 'Tiramisu', 100),
(60, 'Poudre cacao', 100),
(61, 'Petit Speculos', 200),
(62, 'Cafe', 200);

-- --------------------------------------------------------

--
-- Structure de la table `outils`
--

DROP TABLE IF EXISTS `outils`;
CREATE TABLE IF NOT EXISTS `outils` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Quantite` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `outils`
--

INSERT INTO `outils` (`Id`, `Nom`, `Quantite`) VALUES
(1, 'Feux de cuisson', 5),
(2, 'Casseroles', 10),
(3, 'Poeles', 20),
(4, 'Four', 1),
(5, 'Cuillere en bois', 15),
(6, 'Mixeur', 1),
(7, 'Bols a salade', 5),
(8, 'Autocuiseur', 2),
(9, 'Presse-agrumes', 1),
(10, 'Tamis', 1),
(11, 'Entonnoirs', 1),
(12, 'Couteaux de cuisine', 5),
(13, 'Frigo', 1),
(14, 'Lave vaiselle', 1),
(15, 'Machine a laver', 1),
(16, 'Evier', 1);

-- --------------------------------------------------------

--
-- Structure de la table `plat`
--

DROP TABLE IF EXISTS `plat`;
CREATE TABLE IF NOT EXISTS `plat` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Stocke` int(11) NOT NULL,
  `Prêt` tinyint(1) NOT NULL,
  `Dispo` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `plat`
--

INSERT INTO `plat` (`Id`, `Nom`, `Stocke`, `Prêt`, `Dispo`) VALUES
(1, 'Gnocchis a la bolo', 0, 0, 0),
(2, 'Gnoccis a la raclette', 0, 0, 0);

-- --------------------------------------------------------

--
-- Structure de la table `recette`
--

DROP TABLE IF EXISTS `recette`;
CREATE TABLE IF NOT EXISTS `recette` (
  `id_plat` int(11) NOT NULL,
  `id_ingredients` int(11) DEFAULT NULL,
  `id_outils` int(11) DEFAULT NULL,
  `quantite` int(11) NOT NULL DEFAULT '0',
  `ordre` int(11) DEFAULT NULL,
  `Temps` int(255) NOT NULL DEFAULT '0',
  KEY `id_plat` (`id_plat`),
  KEY `id_ingredients` (`id_ingredients`),
  KEY `id_outils` (`id_outils`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `recette`
--

INSERT INTO `recette` (`id_plat`, `id_ingredients`, `id_outils`, `quantite`, `ordre`, `Temps`) VALUES
(1, 24, NULL, 1, NULL, 0),
(1, NULL, 3, 0, 1, 0),
(1, 26, NULL, 1, NULL, 0);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `recette`
--
ALTER TABLE `recette`
  ADD CONSTRAINT `recette_ibfk_1` FOREIGN KEY (`id_plat`) REFERENCES `plat` (`Id`),
  ADD CONSTRAINT `recette_ibfk_2` FOREIGN KEY (`id_ingredients`) REFERENCES `ingredients` (`Id`),
  ADD CONSTRAINT `recette_ibfk_3` FOREIGN KEY (`id_outils`) REFERENCES `outils` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
