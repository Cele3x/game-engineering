# GENERAL

library(ggplot2)
library(tidyverse)
library(hrbrthemes)
library(viridis)
library(extrafont)
library(reshape2)
library(readxl)
library(ggpubr)

# windowsFonts(libertine=windowsFont("Linux Libertine O"))
# par(family='libertine')


# CORE MODULE

core_module <- read_excel("D:/Downloads/data_new.xlsx", range = "D2:AJ100")
core_module <- na.omit(core_module)

competence_headers <- c("Q2", "Q10", "Q15", "Q17", "Q21")
competence_data <- core_module[competence_headers]
 
sensory_headers <- c("Q3", "Q12", "Q18", "Q19", "Q27", "Q30")
sensory_data <- core_module[sensory_headers]
 
flow_headers <- c("Q5", "Q13", "Q25", "Q28", "Q31")
flow_data <- core_module[flow_headers]
 
tension_headers <- c("Q22", "Q24", "Q29")
tension_data <- core_module[tension_headers]
 
challenge_headers <- c("Q11", "Q23", "Q26", "Q32", "Q33")
challenge_data <- core_module[challenge_headers]
 
negative_headers <- c("Q7", "Q8", "Q9", "Q16")
negative_data <- core_module[negative_headers]
 
positive_headers <- c("Q1", "Q4", "Q6", "Q14", "Q20")
positive_data <- core_module[positive_headers]

# par(mfrow=c(2,4))
# boxplot(competence_data, main = "Competence", xlab = "Questions", ylab = "Answers", col = "#8B28A2")
# boxplot(sensory_data, main = "Sensory and Imaginative Immersion", xlab = "Questions", ylab = "Answers", col = "#2C459A", cex.main = "1.1")
# boxplot(flow_data, main = "Flow", xlab = "Questions", ylab = "Answers", col = "#E1992C")
# boxplot(tension_data, main = "Tension/Annoyance", xlab = "Questions", ylab = "Answers", col = "#A9A9A9")
# boxplot(challenge_data, main = "Challenge", xlab = "Questions", ylab = "Answers", col = "#2D5159")
# boxplot(negative_data, main = "Negative Affect", xlab = "Questions", ylab = "Answers", col = "#BF2B23")
# boxplot(positive_data, main = "Positive Affect", xlab = "Questions", ylab = "Answers", col = "#2FA63B")

competence_data <- melt(competence_data)
sensory_data <- melt(sensory_data)
flow_data <- melt(flow_data)
tension_data <- melt(tension_data)
challenge_data <- melt(challenge_data)
negative_data <- melt(negative_data)
positive_data <- melt(positive_data)

core_competence_data_means <- aggregate(value ~ variable, competence_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
core_sensory_data_means <- aggregate(value ~ variable, sensory_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
core_flow_data_means <- aggregate(value ~ variable, flow_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
core_tension_data_means <- aggregate(value ~ variable, tension_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
core_challenge_data_means <- aggregate(value ~ variable, challenge_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
core_negative_data_means <- aggregate(value ~ variable, negative_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
core_positive_data_means <- aggregate(value ~ variable, positive_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))

core1 <- ggplot(competence_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#8B28A2', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=core_competence_data_means, aes(group = 1)) +
	# geom_text(data = core_competence_data_means, aes(label = value, y = value + 0.12)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size=8), 
		plot.title = element_text(size = 11, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Competence") +
	ylab("") +
	xlab("")
	
core2 <- ggplot(sensory_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#2C459A', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=core_sensory_data_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size=8),
		plot.title = element_text(size = 11, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Sensory and Imaginative Immersion") +
	ylab("") +
	xlab("")
	
core3 <- ggplot(flow_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#E1992C', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=core_flow_data_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size=8),
		plot.title = element_text(size = 11, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Flow") +
	ylab("") +
	xlab("")
	
core4 <- ggplot(tension_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#A9A9A9', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=core_tension_data_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size=8),
		plot.title = element_text(size = 11, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Tension/Annoyance") +
	ylab("") +
	xlab("")
	
core5 <- ggplot(challenge_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#2D5159', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=core_challenge_data_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size=8),
		plot.title = element_text(size = 11, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Challenge") +
	ylab("") +
	xlab("")
	
core6 <- ggplot(negative_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#BF2B23', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=core_negative_data_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size=8),
		plot.title = element_text(size = 11, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Negative Affect") +
	ylab("") +
	xlab("")

core7 <- ggplot(positive_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#2FA63B', color="black", alpha=0.5) +
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=core_positive_data_means, aes(group = 1)) +
	stat_boxplot(geom = "errorbar") + 
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size=8),
		plot.title = element_text(size = 11, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Positive Affect") +
	ylab("") +
	xlab("")
	
ggarrange(core1, core2, core3, core4, core5, core6, core7, ncol = 4, nrow = 2)

# GROUPED BY CATEGORY - CORE

means_core_questions <- c("Q1", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8", "Q9", "Q10", "Q11", "Q12", "Q13", "Q14", "Q15", "Q16", "Q17", "Q18", "Q19", "Q20", "Q21", "Q22", "Q23", "Q24", "Q25", "Q26", "Q27", "Q28", "Q29", "Q30", "Q31", "Q32", "Q33")
means_core_types <- c("Positive Affect", "Competence", "Sensory and Imaginative Immersion", "Positive Affect", "Flow", "Positive Affect", "Negative Affect", "Negative Affect", "Negative Affect", "Competence", "Challenge", "Sensory and Imaginative Immersion", "Flow", "Positive Affect", "Competence", "Negative Affect", "Competence", "Sensory and Imaginative Immersion", "Sensory and Imaginative Immersion", "Positive Affect", "Competence", "Tension/Annoyance", "Challenge", "Tension/Annoyance", "Flow", "Challenge", "Sensory and Imaginative Immersion", "Flow", "Tension/Annoyance", "Sensory and Imaginative Immersion", "Flow", "Challenge", "Challenge")
means_core_values <- c(mean(core_module$Q1), mean(core_module$Q2), mean(core_module$Q3), mean(core_module$Q4), mean(core_module$Q5), mean(core_module$Q6), mean(core_module$Q7), mean(core_module$Q8), mean(core_module$Q9), mean(core_module$Q10), mean(core_module$Q11), mean(core_module$Q12), mean(core_module$Q13), mean(core_module$Q14), mean(core_module$Q15), mean(core_module$Q16), mean(core_module$Q17), mean(core_module$Q18), mean(core_module$Q19), mean(core_module$Q20), mean(core_module$Q21), mean(core_module$Q22), mean(core_module$Q23), mean(core_module$Q24), mean(core_module$Q25), mean(core_module$Q26), mean(core_module$Q27), mean(core_module$Q28), mean(core_module$Q29), mean(core_module$Q30), mean(core_module$Q31), mean(core_module$Q32), mean(core_module$Q33))
means_core_data <- data.frame("question" = means_core_questions, "type" = means_core_types, "meanValue" = means_core_values)
core_competence_data_means <- aggregate(value ~ variable, competence_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))

ggplot(means_core_data, aes(x=c("Positive Affect", "Competence", "Sensory \nand \nImaginative \nImmersion", "Positive Affect", "Flow", "Positive Affect", "Negative Affect", "Negative Affect", "Negative Affect", "Competence", "Challenge", "Sensory \nand \nImaginative \nImmersion", "Flow", "Positive Affect", "Competence", "Negative Affect", "Competence", "Sensory \nand \nImaginative \nImmersion", "Sensory \nand \nImaginative \nImmersion", "Positive Affect", "Competence", "Tension/\nAnnoyance", "Challenge", "Tension/\nAnnoyance", "Flow", "Challenge", "Sensory \nand \nImaginative \nImmersion", "Flow", "Tension/\nAnnoyance", "Sensory \nand \nImaginative \nImmersion", "Flow", "Challenge", "Challenge"), y=meanValue)) +
	geom_boxplot(fill=c("#2D5159", "#8B28A2", "#E1992C", "#BF2B23", "#2FA63B", "#2C459A", "#A9A9A9"), color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar", width = 0.3) + 
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		axis.text.x = element_text(size = 10),
		plot.title = element_text(size = 16, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Core Modules") +
	ylab("") +
	xlab("")
	
	
# POST-GAME MODULE

post_module <- read_excel("D:/Downloads/data.xlsx", range = "AK2:BA100")
post_module <- na.omit(post_module)

post_positive_headers <- c("Q1", "Q5", "Q7", "Q8", "Q12", "Q16")
post_positive_data <- post_module[post_positive_headers]

post_negative_headers <- c("Q2", "Q4", "Q6", "Q11", "Q14", "Q15")
post_negative_data <- post_module[post_negative_headers]

post_tiredness_headers <- c("Q10", "Q13")
post_tiredness_data <- post_module[post_tiredness_headers]

post_reality_headers <- c("Q3", "Q9", "Q17")
post_reality_data <- post_module[post_reality_headers]

# par(mfrow=c(2,2))
# boxplot(post_positive_data, main = "Positive Experience", xlab = "Questions", ylab = "Answers", col = "#2FA63B")
# boxplot(post_negative_data, main = "Negative Experience", xlab = "Questions", ylab = "Answers", col = "#BF2B23")
# boxplot(post_tiredness_data, main = "Tiredness", xlab = "Questions", ylab = "Answers", col = "#2C459A")
# boxplot(post_reality_data, main = "Returning to Reality", xlab = "Questions", ylab = "Answers", col = "#E1992C")

post_positive_data <- melt(post_positive_data)
post_negative_data <- melt(post_negative_data)
post_tiredness_data <- melt(post_tiredness_data)
post_reality_data <- melt(post_reality_data)

post_positive_data_means <- aggregate(value ~ variable, post_positive_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
post_negative_data_means <- aggregate(value ~ variable, post_negative_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
post_tiredness_means <- aggregate(value ~ variable, post_tiredness_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))
post_reality_data_means <- aggregate(value ~ variable, post_reality_data, function(x) c(mean = round(mean(x, na.rm=TRUE), 2)))

post1 <- ggplot(post_positive_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#2FA63B', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=post_positive_data_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		plot.title = element_text(size = 12, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Positive Experiences") +
	ylab("") +
	xlab("")

post2 <- ggplot(post_negative_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#BF2B23', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") + 
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=post_negative_data_means, aes(group = 1)) + 
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		plot.title = element_text(size = 12, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Negative Experiences") +
	ylab("") +
	xlab("")
	
post3 <- ggplot(post_tiredness_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#2C459A', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") +  
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=post_tiredness_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		plot.title = element_text(size = 12, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Tiredness") +
	ylab("") +
	xlab("")
	
post4 <- ggplot(post_reality_data, aes(x=variable, y=value)) +
    geom_boxplot(fill='#E1992C', color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar") +  
	stat_summary(fun=mean, colour="darkred", geom="point") +
	geom_line(data=post_reality_data_means, aes(group = 1)) +
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		plot.title = element_text(size = 12, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Returning to Reality") +
	ylab("") +
	xlab("")
	
ggarrange(post1, post2, post3, post4, ncol = 2, nrow = 2)


# GROUPED BY CATEGORY - POST-GAME

means_post_questions <- c("Q1", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8", "Q9", "Q10", "Q11", "Q12", "Q13", "Q14", "Q15", "Q16", "Q17")
means_post_types <- c("Positive Experience", "Negative Experience", "Returning to Reality", "Negative Experience", "Positive Experience", "Negative Experience", "Positive Experience", "Positive Experience", "Returning to Reality", "Tiredness", "Negative Experience", "Positive Experience", "Tiredness", "Negative Experience", "Negative Experience", "Positive Experience", "Returning to Reality")
means_post_values <- c(mean(post_module$Q1, na.rm = TRUE), mean(post_module$Q2, na.rm = TRUE), mean(post_module$Q3, na.rm = TRUE), mean(post_module$Q4, na.rm = TRUE), mean(post_module$Q5, na.rm = TRUE), mean(post_module$Q6, na.rm = TRUE), mean(post_module$Q7, na.rm = TRUE), mean(post_module$Q8, na.rm = TRUE), mean(post_module$Q9, na.rm = TRUE), mean(post_module$Q10, na.rm = TRUE), mean(post_module$Q11, na.rm = TRUE), mean(post_module$Q12, na.rm = TRUE), mean(post_module$Q13, na.rm = TRUE), mean(post_module$Q14, na.rm = TRUE), mean(post_module$Q15, na.rm = TRUE), mean(post_module$Q16, na.rm = TRUE), mean(post_module$Q17, na.rm = TRUE))
means_post_game_data <- data.frame("question" = means_post_questions, "type" = means_post_types, "meanValue" = means_post_values)

ggplot(means_post_game_data, aes(x=type, y=meanValue)) +
	geom_boxplot(fill=c("#BF2B23", "#2FA63B", "#E1992C", "#2C459A"), color="black", alpha=0.5) +
	stat_boxplot(geom = "errorbar", width = 0.3) + 
	scale_y_continuous(limits = c(1, 5)) +
    scale_fill_viridis(discrete = TRUE, alpha=0.6, option="A") +
    theme_ipsum() +
    theme(
		legend.position = "none",
		plot.title = element_text(size = 16, hjust = 0.5),
		plot.margin = margin(5, 0, 0, 0, "pt"),
	) +
    ggtitle("Post-Game Modules") +
	ylab("") +
	xlab("")






