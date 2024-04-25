import {
	Heading,
	VStack,
	StackDivider,
	AbsoluteCenter,
	Center,
	FormControl,
	FormLabel,
	Icon, IconButton, HStack, Collapse, Tag, useDisclosure, Textarea
} from "@chakra-ui/react";
import {Select, SingleValue} from "chakra-react-select";
import {useState} from "react";
import {FaTrash} from "react-icons/fa";

const emptyValue = {"value": "", "label": "start typing or select..."};
const options = [
	{"value": "i123-125azxc-123", "label": "Heroes 3"},
	{"value": "1a5poi-126lzz-123", "label": "Everdell"},
	{"value": "hpoiu-1245z-zxcc", "label": "Eclipse 2ed"},
]


export default function Home() {
	const [value, setValue] = useState({"value": "", "label": ""});
	const { isOpen, onToggle } = useDisclosure()

	const HandleBoardGameSelectionChange = (event: SingleValue<{value: string, label: string }>) => {
		if (event === null){
			setValue(emptyValue)
			isOpen && onToggle()
		} else {
			setValue(event)
			!isOpen && onToggle()
		}
	}

	const HandleButtonClick = () => {
		setValue(emptyValue)
		onToggle()
	}

	return (
		<>
			<VStack width="100vw" height="100vh" spacing={{base: 12, md: 16}} divider={<StackDivider/>} alignItems="center">
				<Heading size="sm">
					<Center>
						"Welcome to your friendly Board Game AI helper - Galthran the App"
					</Center>
				</Heading>

				<AbsoluteCenter>
					<Collapse
						in={isOpen}
						transition={{ exit: { delay: 0.1, staggerDirection: 1 }, enter: { duration: 0.5 } }}
						animateOpacity
					>
						<VStack width={"50vh"}>
							<HStack>
								<IconButton
									variant="ghost"
									colorScheme='blue'
									aria-label='Search database'
									icon={<Icon as={FaTrash}/>}
									onClick={HandleButtonClick}
								/>
								<Tag>{value.label}</Tag>
							</HStack>

							<Textarea placeholder='Here is a sample placeholder'/>
						</VStack>
					</Collapse>

					<Collapse
						in={!isOpen}
						transition={{ exit: { delay: 0.1 }, enter: { duration: 0.5 } }}
						style={{
							overflow: "visible",
						}}
					>
						<FormControl p={-4} width={"50vh"}>
							<FormLabel>
								Select your desired board game...
							</FormLabel>
							<Select
								id="board-game-select"
								useBasicStyles
								options={options}
								placeholder="Select a board game..."
								closeMenuOnSelect
								onChange={HandleBoardGameSelectionChange}
								value={value}
								/>
						</FormControl>
					</Collapse>
				</AbsoluteCenter>
			</VStack>
		</>
	)
}

