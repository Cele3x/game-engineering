# GENERAL

library(ggplot2)
library(tidyverse)
library(hrbrthemes)
library(viridis)
library(extrafont)
library(reshape2)
library(readxl)
library(ggpubr)

logs <- read_excel("D:/Entwicklung/game-engineering/evaluation/logs.xlsx")
filtered_logs <- data.frame(gameLength = logs$gameLength, beesRate = logs$beesKillRatio, spraysRate = logs$spraysCollectRatio, onionsRate = logs$onionsCollectRatio)

logData <- melt(filtered_logs, id = "gameLength")

yLabels <- c(beesRate = "Wasp Kill Ratio", spraysRate = "Spray Collect Ratio", onionsRate = "Onion Collect Ratio")

ggplot(logData, aes(x=gameLength, y=value, color=variable)) + 
	geom_point() +
	geom_smooth() +
	labs(color='') +
	scale_y_continuous(limits = c(0, 1)) +
	scale_color_discrete(labels = yLabels) +
	ylab("Kill/Collect Ratio") +
	xlab("Game Length (in s)") +
	ggtitle("Kill/Collect Ratio by Playtime") +
	theme_ipsum() +
	theme(
		plot.title = element_text(size = 16, hjust = 0.5),
		plot.margin = margin(5, 1, 1, 1, "pt"),
		axis.title.x = element_text(size = 12, hjust = 0.5),
		axis.title.y = element_text(size = 12, hjust = 0.5)
	)