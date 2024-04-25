import {Divider, HStack, Text} from "@chakra-ui/react";
import {PropsWithChildren} from "react";

export interface DividerTextProps extends PropsWithChildren {
	text?: string
	py?: string
	px?: string
}

export default function DividerText( {
	text = "",
	py = "8",
	px = "8"
}: DividerTextProps) : JSX.Element {
	return (
		<HStack spacing={{base: 12, md: 16}} width="50vw" py={py} px={px}>
			<Divider borderWidth="8" borderColor="gray.400"/>
			<Text color={"gray.400"}>{text}</Text>
			<Divider borderWidth="8" borderColor="gray.400"/>
		</HStack>
	)
}