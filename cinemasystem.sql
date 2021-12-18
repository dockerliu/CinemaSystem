/*
Navicat MySQL Data Transfer

Source Server         : cinemasystem
Source Server Version : 50650
Source Host           : 192.168.1.95:3306
Source Database       : cinemasystem

Target Server Type    : MYSQL
Target Server Version : 50650
File Encoding         : 65001

Date: 2021-12-18 10:44:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `Movie`
-- ----------------------------
DROP TABLE IF EXISTS `Movie`;
CREATE TABLE `Movie` (
  `MovieId` int(11) NOT NULL AUTO_INCREMENT COMMENT '影片编号',
  `MovieName` varchar(50) DEFAULT NULL COMMENT '电影名称',
  `Poster` varchar(200) DEFAULT NULL COMMENT '宣传海报',
  `Director` varchar(100) DEFAULT NULL COMMENT '导演',
  `Actor` varchar(100) DEFAULT NULL COMMENT '主演',
  `MovieType` varchar(50) DEFAULT NULL COMMENT '影片类型',
  `Duration` varchar(20) DEFAULT NULL COMMENT '时长',
  `Price` varchar(255) DEFAULT NULL COMMENT '价格',
  `IsTop` bit(1) DEFAULT NULL COMMENT '是否上映',
  PRIMARY KEY (`MovieId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Movie
-- ----------------------------
INSERT INTO `Movie` VALUES ('1', '流浪地球', 'Img/WanderingEarth.jpg', '郭帆', '吴京 / 李光洁 / 吴孟达 / 赵今麦 / 隋凯 / 屈菁菁 / 张亦驰 / 杨皓宇 / 阿尔卡基·沙罗格拉茨基 / 李虹辰 / 杨轶 / 姜志刚 / 张欢 / 雷佳音 / 宁浩 / 刘慈欣 / 郭', '科幻', '125分钟', '35', '');
INSERT INTO `Movie` VALUES ('2', '复仇者联盟4：终局之战 Avengers: Endgame (2019)', 'Img/Vingadores.jpg', '安东尼·罗素 / 乔·罗素', '小罗伯特·唐尼 / 克里斯·埃文斯 / 马克·鲁弗洛 / 克里斯·海姆斯沃斯 / 乔什·布洛林', '科幻', '181', '38', '');
INSERT INTO `Movie` VALUES ('3', '速度与激情9 F9: The Fast Saga‎ (2021)', 'Img/Fast9.jpg', '林诣彬', ' 范·迪塞尔 / 约翰·塞纳 / 米歇尔·罗德里格兹 / 乔丹娜·布鲁斯特 / 泰瑞斯·吉布森 ', '动作 / 犯罪', '142', '45', '');

-- ----------------------------
-- Table structure for `PlayHall`
-- ----------------------------
DROP TABLE IF EXISTS `PlayHall`;
CREATE TABLE `PlayHall` (
  `HallId` int(11) NOT NULL COMMENT '放映厅编号',
  `HallName` varchar(50) DEFAULT NULL COMMENT '放映厅名字',
  `SeatList` varchar(255) DEFAULT NULL COMMENT '座位列表',
  `IsValid` bit(1) DEFAULT NULL COMMENT '是否有效',
  PRIMARY KEY (`HallId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of PlayHall
-- ----------------------------
INSERT INTO `PlayHall` VALUES ('0', '一号大厅', 'Xml/1.xml', '');
INSERT INTO `PlayHall` VALUES ('2', '二号大厅', 'Xml/2.xml', '');
INSERT INTO `PlayHall` VALUES ('3', '三号大厅', 'Xml/3.xml', '');
INSERT INTO `PlayHall` VALUES ('4', '四号大厅', 'Xml/4.xml', '');
INSERT INTO `PlayHall` VALUES ('5', '五号大厅', 'Xml/5.xml', '');

-- ----------------------------
-- Table structure for `Schedule`
-- ----------------------------
DROP TABLE IF EXISTS `Schedule`;
CREATE TABLE `Schedule` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '计划编号',
  `MovieID` int(11) DEFAULT NULL COMMENT '影片编号',
  `HallID` int(255) DEFAULT NULL COMMENT '放映厅编号',
  `PlayTime` datetime DEFAULT NULL COMMENT '放映时间',
  `Discount` varchar(255) DEFAULT NULL COMMENT '折扣',
  PRIMARY KEY (`ID`),
  KEY `MovieID` (`MovieID`),
  KEY `PlayHallID` (`HallID`),
  CONSTRAINT `MovieID` FOREIGN KEY (`MovieID`) REFERENCES `Movie` (`MovieId`),
  CONSTRAINT `PlayHallID` FOREIGN KEY (`HallID`) REFERENCES `PlayHall` (`HallId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Schedule
-- ----------------------------
INSERT INTO `Schedule` VALUES ('1', '1', '0', '2021-05-29 15:28:18', '9');
INSERT INTO `Schedule` VALUES ('2', '1', '3', '2021-05-29 19:28:45', '1');
INSERT INTO `Schedule` VALUES ('3', '2', '2', '2021-05-29 15:29:10', '0');
INSERT INTO `Schedule` VALUES ('4', '3', '4', '2021-05-29 18:29:29', '0');

-- ----------------------------
-- Table structure for `Ticket`
-- ----------------------------
DROP TABLE IF EXISTS `Ticket`;
CREATE TABLE `Ticket` (
  `TicketID` int(11) NOT NULL AUTO_INCREMENT,
  `ScheduleID` int(11) DEFAULT NULL,
  `Price` decimal(10,2) NOT NULL COMMENT '价格',
  `SeatNo` varchar(255) DEFAULT NULL COMMENT '位置号',
  `CreateTime` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`TicketID`),
  KEY `Schedule` (`ScheduleID`),
  CONSTRAINT `Schedule` FOREIGN KEY (`ScheduleID`) REFERENCES `Schedule` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Ticket
-- ----------------------------
INSERT INTO `Ticket` VALUES ('1', null, '3.00', '1-2', null);
INSERT INTO `Ticket` VALUES ('2', '1', '3.00', '1-2', '2021-05-29 18:51:15');
INSERT INTO `Ticket` VALUES ('3', '1', '3.00', '1-3', '2021-05-29 18:51:24');
INSERT INTO `Ticket` VALUES ('4', '2', '31.00', '3-4', '2021-05-29 18:51:33');
INSERT INTO `Ticket` VALUES ('5', '3', '38.00', '3-4', '2021-05-29 18:58:59');
INSERT INTO `Ticket` VALUES ('6', '1', '3.00', '2-4', '2021-05-29 19:44:26');
INSERT INTO `Ticket` VALUES ('7', '1', '3.00', '3-4', '2021-05-29 19:46:02');
INSERT INTO `Ticket` VALUES ('8', '2', '31.00', '1-2', '2021-05-29 19:46:41');
